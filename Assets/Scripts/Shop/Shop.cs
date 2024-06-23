using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public GameObject UIGO;
    private bool waitForUIActionCoroutine;// 移除神符的操作
    public static Shop _Instance;
    public GameObject goodPrb;
    public Transform gOODS;
    public List<Good> goods;
    private string folderPath = "Prefab/Card"; // 文件夹路径
    private GameObject[] prefabs; // 存储加载的预制体
    [Header("移除服务")]
    public Button removeBtn;//移除服务的按钮
    public TextMeshProUGUI removeTextGUI;//移除服务的文字说明
    [Header("刷新服务")]
    public Image refreshBtnImage;
    public Button refreshBtn;
    public Animator animator;
    void LoadPrefabs()
    {
        Object[] loadedPrefabs = Resources.LoadAll(folderPath, typeof(GameObject));

        prefabs = new GameObject[loadedPrefabs.Length];

        for (int i = 0; i < loadedPrefabs.Length; i++)
        {
            prefabs[i] = (GameObject)loadedPrefabs[i];
        }
    }
    private GameObject RandomInitCard()
    {
        int randomIndex = UnityEngine.Random.Range(0, prefabs.Length);
        GameObject selectedPrefab = prefabs[randomIndex];
        return selectedPrefab;

    }
    private void Awake()
    {
        if (_Instance == null)
        {
            _Instance = this;
            if (ItemManager.Instance.FindItemWithID(4) != null)
            {
                removeBtn.interactable = false;
                //刷新
                if (RoundManager._Instance.remainRefreshTimes == 0)
                {
                    refreshBtn.interactable = false;
                }
                refreshBtnImage.sprite = RoundManager._Instance.spriteList[RoundManager._Instance.remainRefreshTimes];
                //
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        GameObject.Find("商店过渡").GetComponent<AudioSource>().Play();
        //刷新
        if (RoundManager._Instance.remainRefreshTimes == 0)
        {
            refreshBtn.interactable = false;
        }
        refreshBtnImage.sprite = RoundManager._Instance.spriteList[RoundManager._Instance.remainRefreshTimes];
        //
        ShowRemoveBtnText();
        //
        LoadPrefabs();
        int i = 3;
        if (ItemManager.Instance.FindItemWithID(2) != null)
            i = 4;
        if (ItemManager.Instance.FindItemWithID(4) != null)
        {
            removeBtn.interactable = false;
        }
        while (i > 0)
        {
            GameObject GO = Instantiate(goodPrb, gOODS); ;
            Good G = GO.GetComponentInChildren<Good>();
            goods.Add(G);
            i--;
        }
        foreach (var item in goods)
        {
            item.Card = RandomInitCard();
        }
    }

    public void ShowRemoveBtnText()
    {
        string str = $" <#ff0000>移除服务({(int)RoundManager._Instance.removeGold }金币)</color>";
        if (ItemManager.Instance.FindItemWithID(6) != null)
        {
            str = $" <#ff0000>移除服务({(int)(RoundManager._Instance.removeGold * 0.5f) }金币)</color>";
        }
        removeTextGUI.text = str;
    }

    void Update()
    {
/*        if (Input.GetKeyDown(KeyCode.S))
        {
            Destroy(gameObject);
        }
*/
        // 检测鼠标点击
        if (waitForUIActionCoroutine && Input.GetMouseButtonDown(0))
        {
            // 检测点击到的UI元素
            PointerEventData pointerData = new PointerEventData(EventSystem.current)
            {
                position = Input.mousePosition
            };

            List<RaycastResult> results = new List<RaycastResult>();
            EventSystem.current.RaycastAll(pointerData, results);

            foreach (RaycastResult result in results)
            {
                //Debug.Log(result.gameObject.name);
                Card card = result.gameObject.GetComponent<Card>();
                if (card != null)
                {
                    Debug.Log($"选择{card.cardData.cardName}");
                    // 结束协程并继续后续逻辑
                    waitForUIActionCoroutine = false;
                    RoundManager._Instance.isRemoving = false;
                    UIGO.SetActive(true);
                    // 执行后续逻辑
                    ExecutePostAction(card);
                    return;
                }
            }
        }
        if (UIGO.activeSelf == false && waitForUIActionCoroutine && Input.GetMouseButtonDown(1))
        {
            // 取消
            waitForUIActionCoroutine = false;
            RoundManager._Instance.isRemoving = false;
            UIGO.SetActive(true);
        }
    }

    //跳过商店
    [ContextMenu("跳过")]
    public void Skip()
    {
        GameObject.Find("跳过").GetComponent<AudioSource>().Play();
        Destroy(gameObject);
    }

    //重投商店
    [ContextMenu("重投")]
    public void Refresh()
    {
        GameObject.Find("刷新").GetComponent<AudioSource>().Play();
        if (RoundManager._Instance.remainRefreshTimes > 0)
        {
            RoundManager._Instance.remainRefreshTimes--;
            refreshBtnImage.sprite = RoundManager._Instance.spriteList[RoundManager._Instance.remainRefreshTimes];
            foreach (var item in goods)
            {
                GameObject GO;
                do
                {
                    GO = RandomInitCard();
                } while (GO == item.Card);
                item.Card = GO;
            }
        }
        if (RoundManager._Instance.remainRefreshTimes == 0)
        {
            refreshBtn.interactable = false;
        }
    }
    //销毁神符
    [ContextMenu("销毁")]
    public void RemoveCard()
    {
        //有神符06
        if (ItemManager.Instance.FindItemWithID(6))
        {
            if (RoundManager._Instance.Gold >= (int)(RoundManager._Instance.removeGold * 0.5f) - 1)
            {
                RoundManager._Instance.Gold -= (int)(RoundManager._Instance.removeGold * 0.5f) - 1;
                RoundManager._Instance.removeGold += RoundManager._Instance.removeIncreaseGold;
                //启动协程
                waitForUIActionCoroutine = true;
                RoundManager._Instance.isRemoving = true;
                UIGO.SetActive(false);

            }
        }
        else if (RoundManager._Instance.Gold >= (int)RoundManager._Instance.removeGold )
        {
            RoundManager._Instance.Gold -= (int) RoundManager._Instance.removeGold ;
            RoundManager._Instance.removeGold += RoundManager._Instance.removeIncreaseGold;
            //启动协程
            waitForUIActionCoroutine = true;
            RoundManager._Instance.isRemoving = true;
            UIGO.SetActive(false);
        }
    }
    IEnumerator WaitForUIAction()
    {
        Debug.Log("等待玩家点击特定UI元素...");

        // 无限等待，直到协程被手动停止
        yield return new WaitUntil(() => false);
    }

    void ExecutePostAction(Card card)
    {
        // 在这里执行后续的逻辑
        Debug.Log("执行后续的逻辑...");
        //扣钱，移除操作；
        GameObject.Find("删除").GetComponent<AudioSource>().Play();
        card.CardDestroy();
    }
    public void DestroyThisGO()
    {
        Destroy(gameObject);
    }
}
