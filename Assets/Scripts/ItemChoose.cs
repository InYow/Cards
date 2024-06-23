using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemChoose : MonoBehaviour
{
    public static ItemChoose _Instance;
    private string folderPath = "Prefab/Item"; // 文件夹路径
    public List<GameObject> prefabs; // 存储加载的预制体
    public Transform targetTrs;
    public List<int> choosedPrb=new();
    void LoadItems()
    {
        Object[] loadedPrefabs = Resources.LoadAll(folderPath, typeof(GameObject));

        prefabs = new List<GameObject>();

        for (int i = 0; i < loadedPrefabs.Length; i++)
        {
            prefabs.Add((GameObject)loadedPrefabs[i]);
        }
    }
    private GameObject RandomInitItem()
    {
        //处理出要随机的集合
        List<GameObject> prefabsWant = new();
        //剔除已经拥有的
        foreach (var item in prefabs)
        {
            Item i = ItemManager.Instance.FindItemWithID(item.GetComponent<Item>().itemID);
            //还未拥有该item
            if (i == null)
            {
                prefabsWant.Add(item);
            }
        }

        int randomIndex = -1;
        randomIndex = UnityEngine.Random.Range(0, prefabsWant.Count);
        GameObject selectedPrefab = prefabsWant[randomIndex];
        return selectedPrefab;
    }
    public bool CampareItem(Item item1,Item item2)
    {
        if(item1.itemID==item2.itemID)
        {
            return true;
        }
        else
        {
            return false;
        }
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
        LoadItems();
    }
    [ContextMenu("生成护身符")]
    public void InitItem()
    {
        List<GameObject> GOS = new();
        //提取要生成的护身符
        for (int i = 0; i < 2; i++)
        {
            Debug.Log("生成护身符");
            GameObject ToInstantiate;
            do
            {
                ToInstantiate = RandomInitItem();
            }
            while (GOS.Contains(ToInstantiate));
            GOS.Add(ToInstantiate);
        }
        //生成护身符
        foreach (var item in GOS)
        {
            Instantiate(item, targetTrs);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    [ContextMenu("关闭")]
    public void Close()
    {
        for (int i = 0; i < targetTrs.childCount; i++)
        {
            Destroy(targetTrs.GetChild(i).gameObject);
        }
        gameObject.SetActive(false);
    }
    [ContextMenu("打开")]
    public void Open()
    {
        gameObject.SetActive(true);
        InitItem();
    }
}
