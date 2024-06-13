using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lizi : MonoBehaviour
{
    public Vector2 dic;
    public float speed;
    public AnimationCurve animationCurve;
    public float minspeed;
    public float maxspeed;
    public bool moveback;
    public float time;
    private float _time;
    // Start is called before the first frame update
    void Start()
    {
        moveback = false;
        speed = Random.Range(minspeed, maxspeed);
    }

    // Update is called once per frame
    void Update()
    {
        if (moveback)
        {
            Vector3 movedic = (Vector3.zero - transform.localPosition).normalized;
            transform.localPosition += movedic * speed * Time.deltaTime;
        }
        else
        {
            _time += Time.deltaTime;
            if (_time < time)
            {
                float speedin = animationCurve.Evaluate(_time);
                transform.localPosition += (Vector3)dic * speed * speedin * Time.deltaTime;
            }
        }
    }
}
