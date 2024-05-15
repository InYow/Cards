using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Shop : MonoBehaviour
{
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
        if(_Instance==null)
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
            item.card = RandomInitCard();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            Destroy(gameObject);
        }
 
    }
}
