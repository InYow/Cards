using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemChoose : MonoBehaviour
{
    public static ItemChoose _Instance;
    private string folderPath = "Prefab/Item"; // 文件夹路径
    public GameObject[] prefabs; // 存储加载的预制体
    public Transform targetTrs;

    void LoadItems()
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
        LoadItems();
    }
    [ContextMenu("生成护身符")]
    public void InitItem()
    {
        for (int i = 0; i < 3; i++)
        {
            Debug.Log("生成护身符");
            Instantiate(RandomInitCard(), targetTrs);
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
