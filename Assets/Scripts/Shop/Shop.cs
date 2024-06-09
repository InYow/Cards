using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

public class Shop : MonoBehaviour
{
    public GameObject UIGO;
    private bool waitForUIActionCoroutine;// �Ƴ�����Ĳ���
    public static Shop _Instance;
    public List<Good> goods;
    private string folderPath = "Prefab/Card"; // �ļ���·��
    private GameObject[] prefabs; // �洢���ص�Ԥ����
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
    //�������
    [ContextMenu("����")]
    public void RemoveCard()
    {
        //����Э��
        waitForUIActionCoroutine = true;
        UIGO.SetActive(false);
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
        Debug.Log("ִ�к������߼�...");
        //��Ǯ���Ƴ�������
    }
}
