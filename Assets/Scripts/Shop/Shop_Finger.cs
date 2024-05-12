using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop_Finger : MonoBehaviour
{
    public static Shop_Finger _Instance;
    public GameObject targetObj;
    public float speed;
    public bool moving;
    public float error;
    private void Awake()
    {
        if(_Instance==null)
        {
            _Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    private void Update()
    {
        if (moving)
        {
            //ÒÆ¶¯Î»ÖÃ
            Vector2 dic = (Vector2)(targetObj.transform.position - transform.position);
            dic = dic.normalized;
            Vector3 dic3 = new(dic.x, dic.y, 0f);
            transform.position = transform.position + dic3 * speed * Time.deltaTime;
            if((transform.position-targetObj.transform.position).magnitude< error)
            {
                moving = false;
            }
        }
    }
    public void SetTatget(GameObject obj)
    {
        targetObj = obj;
        moving = true;
    }
}
