using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Good : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public float speed;
    private GameObject card;
    public float distance;
    public GameObject Card
    {
        get
        {
            return card;
        }
        set
        {
            card = value;
            image = GetComponent<Image>();
            image.sprite = Card.GetComponent<Card>().cardData.sprite;
        }
    }
    public Image image; void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        Hole hole = CardPool._Instance.GetEmptyHole();
        if (hole == null)
        {
            return;
        }
        Debug.Log("点击了");
        GameObject.Find("加入神符").GetComponent<AudioSource>().Play();
        Vector2 targetPos = hole.gameObject.transform.position;
        Debug.Log(targetPos);
        StartCoroutine(IEAddToPool(targetPos, speed, hole));
    }

    private IEnumerator IEAddToPool(Vector2 Pos, float speed, Hole hole)
    {
        while ((Pos - (Vector2)transform.position).magnitude > distance/Time.deltaTime)
        {
            transform.position = transform.position + (Vector3)(Pos - (Vector2)transform.position).normalized * speed * Time.deltaTime;
            yield return null;
        }
        Instantiate(Card, hole.gameObject.transform);
        Shop._Instance.animator.Play("close");
        //Destroy(Shop._Instance.gameObject);
        //Destroy(gameObject);
    }
    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        Shop_Finger._Instance.SetTatget(this.gameObject);
        //信息面板
        Infoer.infoer.SetText(Card.GetComponent<Card>());
        Infoer.infoer.transform.position = transform.position;
        Infoer.infoer.gameObject.SetActive(true);
    }
    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        Infoer.infoer.gameObject.SetActive(false);
    }
}
