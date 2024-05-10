using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class InfoChecker : MonoBehaviour
{
    public static InfoChecker infoChecker;
    public enum Dric
    {
        left = 1,
        right
    }
    public InfoInspector InfoPrb;
    public InfoInspector old_Info;
    public Transform left_Trans;
    public InfoInspector new_Info;
    public Transform right_Trans;
    [Header("旋转")]
    public float speed;
    public Transform center_Trans;
    public bool rotating;
    private void Awake()
    {
        if (infoChecker == null)
            infoChecker = this;
        else
            Destroy(this.gameObject);
        rotating = false;
    }
    public InfoInspector CreateInfoIpt(ItemInfo itemInfo)
    {
        return CreateInfoIpt(Dric.left, itemInfo);
    }
    public InfoInspector CreateInfoIpt(Dric dric, ItemInfo itemInfo)
    {
        if (rotating)
            return null;
        InfoInspector info = null;
        switch (dric)
        {
            case Dric.left:
                info = Instantiate(InfoPrb, left_Trans.position, left_Trans.rotation);
                break;
            case Dric.right:
                info = Instantiate(InfoPrb, right_Trans.position, right_Trans.rotation);
                break;
            default:
                goto case Dric.left;
        }
        info.transform.SetParent(this.transform);
        info.SetInfo(itemInfo);
        //旋转
        StartCoroutine(Rotate(info, old_Info));
        rotating = true;
        return info;
    }
    private IEnumerator Rotate(InfoInspector new_Info, InfoInspector old_Info)
    {
        while (!Mathf.Approximately(new_Info.gameObject.transform.up.y, 1f) || !Mathf.Approximately(old_Info.gameObject.transform.up.x, -1f))
        {
            if (!Mathf.Approximately(new_Info.gameObject.transform.up.y, 1f))
            {
                new_Info.gameObject.transform.RotateAround(center_Trans.position, Vector3.forward, speed * Time.deltaTime);
            }
            if (!Mathf.Approximately(old_Info.gameObject.transform.up.x, -1f))
            {
                old_Info.gameObject.transform.RotateAround(center_Trans.position, Vector3.forward, speed * Time.deltaTime);
            }
            yield return null;
        }
        Destroy(old_Info.gameObject, 0.2f);
        this.old_Info = new_Info;
        rotating = false;
    }
}
