using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

public class Shop : MonoBehaviour
{
    public GameObject UIGO;
    private bool waitForUIActionCoroutine;// 移除神符的操作
    public static Shop _Instance;
    public List<Good> goods;
    private string folderPath = "Prefab/Card"; // 文件夹路径
    private GameObject[] prefabs; // 存储加载的预制体
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
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        LoadPrefabs();
        foreach (var item in goods)
        {
            item.Card = RandomInitCard();
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            Destroy(gameObject);
        }
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
                    UIGO.SetActive(true);
                    // 执行后续逻辑
                    ExecutePostAction();
                    return;
                }
            }
        }
        if (UIGO.activeSelf == false && waitForUIActionCoroutine && Input.GetMouseButtonDown(1))
        {
            // 取消
            waitForUIActionCoroutine = false;
            UIGO.SetActive(true);
        }
    }
    //重投商店
    [ContextMenu("重投")]
    public void Refresh()
    {
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
    //销毁神符
    [ContextMenu("销毁")]
    public void RemoveCard()
    {
        //启动协程
        waitForUIActionCoroutine = true;
        UIGO.SetActive(false);
    }
    IEnumerator WaitForUIAction()
    {
        Debug.Log("等待玩家点击特定UI元素...");

        // 无限等待，直到协程被手动停止
        yield return new WaitUntil(() => false);
    }

    void ExecutePostAction()
    {
        // 在这里执行后续的逻辑
        Debug.Log("执行后续的逻辑...");
        //扣钱，移除操作；
    }
}
