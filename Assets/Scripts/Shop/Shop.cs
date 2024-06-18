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
    private bool waitForUIActionCoroutine;// �Ƴ�����Ĳ���
    public static Shop _Instance;
    public Good goodPrb;
    public Transform gOODS;
    public List<Good> goods;
    private string folderPath = "Prefab/Card"; // �ļ���·��
    private GameObject[] prefabs; // �洢���ص�Ԥ����
    [Header("�Ƴ�����")]
    public Button removeBtn;//�Ƴ�����İ�ť
    public TextMeshProUGUI removeTextGUI;//�Ƴ����������˵��
    [Header("ˢ�·���")]
    public Image refreshBtnImage;
    public Button refreshBtn;
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
                //ˢ��
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
        //ˢ��
        if (RoundManager._Instance.remainRefreshTimes == 0)
        {
            refreshBtn.interactable = false;
        }
        refreshBtnImage.sprite = RoundManager._Instance.spriteList[RoundManager._Instance.remainRefreshTimes];
        //
        string str = $"�Ƴ����� <#ff0000>({(int)RoundManager._Instance.removeGold}���)</color>";
        if (ItemManager.Instance.FindItemWithID(6) != null)
        {
            str = $"�Ƴ����� <#ff0000>({(int)(RoundManager._Instance.removeGold * 0.5f)}���)</color>";
        }
        removeTextGUI.text = str;
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
            Good G = Instantiate(goodPrb, gOODS);
            goods.Add(G);
            i--;
        }
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
        // ��������
        if (waitForUIActionCoroutine && Input.GetMouseButtonDown(0))
        {
            // ���������UIԪ��
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
                    Debug.Log($"ѡ��{card.cardData.cardName}");
                    // ����Э�̲����������߼�
                    waitForUIActionCoroutine = false;
                    UIGO.SetActive(true);
                    // ִ�к����߼�
                    ExecutePostAction();
                    card.CardDestroy();
                    return;
                }
            }
        }
        if (UIGO.activeSelf == false && waitForUIActionCoroutine && Input.GetMouseButtonDown(1))
        {
            // ȡ��
            waitForUIActionCoroutine = false;
            UIGO.SetActive(true);
        }
    }
    //��Ͷ�̵�
    [ContextMenu("��Ͷ")]
    public void Refresh()
    {
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
    //�������
    [ContextMenu("����")]
    public void RemoveCard()
    {
        //����Э��
        if (RoundManager._Instance.Gold >= 5)//�Ƴ�ʱ������ӣ��ᵼ����עһö��ҡ�
        {
            RoundManager._Instance.Gold -= 4;
            waitForUIActionCoroutine = true;
            UIGO.SetActive(false);
            Debug.Log("��ҳ���");
        }
        else
        {
            //�����壬��Ҳ���
        }

        //�����06
        if (ItemManager.Instance.FindItemWithID(6))
        {
            if (RoundManager._Instance.Gold > RoundManager._Instance.removeGold * 0.5f)
            {
                RoundManager._Instance.Gold -= (int)(RoundManager._Instance.removeGold * 0.5f);
                RoundManager._Instance.removeGold += RoundManager._Instance.removeIncreaseGold;
                //����Э��
                waitForUIActionCoroutine = true;
                UIGO.SetActive(false);
            }
        }
        else if (RoundManager._Instance.Gold > RoundManager._Instance.removeGold)
        {
            RoundManager._Instance.Gold -= RoundManager._Instance.removeGold;
            RoundManager._Instance.removeGold += RoundManager._Instance.removeIncreaseGold;
            //����Э��
            waitForUIActionCoroutine = true;
            UIGO.SetActive(false);
        }
    }
    IEnumerator WaitForUIAction()
    {
        Debug.Log("�ȴ���ҵ���ض�UIԪ��...");

        // ���޵ȴ���ֱ��Э�̱��ֶ�ֹͣ
        yield return new WaitUntil(() => false);
    }

    void ExecutePostAction()
    {
        // ������ִ�к������߼�
        //��Ǯ���Ƴ�������
    }
}
