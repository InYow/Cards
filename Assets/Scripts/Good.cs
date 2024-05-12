using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Good : MonoBehaviour, IPointerClickHandler,IPointerEnterHandler
{
    public float speed;
    public GameObject card;
    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        Hole hole = CardPool._Instance.GetEmptyHole();
        if (hole == null)
        {
            return;
        }
        Vector2 targetPos = hole.gameObject.transform.position;
        Debug.Log(targetPos);
        StartCoroutine(IEAddToPool(targetPos, speed,hole));
    }

    private IEnumerator IEAddToPool(Vector2 Pos, float speed,Hole hole)
    {
        while ((Pos - (Vector2)transform.position).magnitude > 5)
        {
            transform.position = transform.position + (Vector3)(Pos - (Vector2)transform.position).normalized * speed * Time.deltaTime;
            yield return null;
        }
        Instantiate(card,hole.gameObject.transform);
        Shop._Instance.gameObject.SetActive(false);
        Destroy(gameObject);
    }
    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        Shop_Finger._Instance.SetTatget(this.gameObject);
    }
}
