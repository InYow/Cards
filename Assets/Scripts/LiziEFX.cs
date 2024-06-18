using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class LiziEFX : MonoBehaviour
{
    public int number;
    public Lizi LiziPrb;
    public List<Lizi> lizis;
    public Vector3 destination;
    public bool moving;
    public float speed;
    public float destroyDistance;
    public float time = 0.2f;
    public int sort;
    public Canvas canvas;

    public void Init()
    {
        canvas.sortingOrder = sort;
        int a = number;
        moving = false;
        while (a > 0)
        {
            a--;
            Lizi lizi = Instantiate(LiziPrb, transform);
            lizis.Add(lizi);
            float x = Random.Range(-1f, 1f);
            float y = Mathf.Sqrt(1 - x * x);
            float z = Random.Range(0, 2);
            if (z == 0)
            {
                y *= -1;
            }
            lizi.dic = new(x, y);
        }
    }

    private void Update()
    {
        time -= Time.deltaTime;
        if (time < 0f)
        {
            Move();
        }
        if (moving)
        {
            Vector3 dic = destination - transform.position;
            if (dic.magnitude < destroyDistance)
            {
                Destroy(gameObject);
            }
            dic = dic.normalized;
            transform.localPosition += dic * speed * Time.deltaTime;
        }
    }
    [ContextMenu("日你妈")]
    public void Move()
    {
        GameObject GO = GameObject.Find("RNM");
        MoveToDestination(GO.transform.position);
    }
    public void MoveToDestination(Vector3 des)
    {
        destination = des;
        moving = true;
        foreach (var item in lizis)
        {
            item.moveback = true;
        }
    }
}
