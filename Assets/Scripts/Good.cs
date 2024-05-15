using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Good : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public float speed;
    public GameObject card;
    public Image image;
    private void Start()
    {
        image = GetComponent<Image>();
        image.sprite = card.GetComponent<Card>().cardData.sprite;
    }
    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        Hole hole = CardPool._Instance.GetEmptyHole();
        if (hole == null)
        {
            return;
        }
        Debug.Log("点击了");
        Vector2 targetPos = hole.gameObject.transform.position;
        Debug.Log(targetPos);
        StartCoroutine(IEAddToPool(targetPos, speed, hole));
    }

    private IEnumerator IEAddToPool(Vector2 Pos, float speed, Hole hole)
    {
        while ((Pos - (Vector2)transform.position).magnitude > 5)
        {
            transform.position = transform.position + (Vector3)(Pos - (Vector2)transform.position).normalized * speed * Time.deltaTime;
            yield return null;
        }
        Instantiate(card, hole.gameObject.transform);
        Destroy(Shop._Instance.gameObject);
        //Destroy(gameObject);
    }
    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        Shop_Finger._Instance.SetTatget(this.gameObject);
        //信息面板
        Infoer.infoer.SetText(card.GetComponent<Card>());
        Infoer.infoer.transform.position = transform.position;
        Infoer.infoer.gameObject.SetActive(true);
    }
    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        Infoer.infoer.gameObject.SetActive(false);
    }
}
