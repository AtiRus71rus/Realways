using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class __ScrollRect : MonoBehaviour, IDragHandler, IBeginDragHandler
{

    public Rigidbody2D green;   // здесь будет ссылка на компонент Transform зеленой панели.
    public float speed = 0.5f;

    public bool isZoom;

    public bool isLeftDno;
    public bool isRightDno;


    public Vector2 noZoom = new Vector2(-3.45f, 3.34f);
    public Vector2 zoom = new Vector2(1.275f, -1.336f);


    void Start()
    {
        //green = transform.GetChild(0); // получаем ссылку на Transform зеленой панели.
    }

    private void LateUpdate()
    {
        //Debug.Log("0: " + green.transform.GetChild(0).position.x);
        //Debug.Log("1: " + green.transform.GetChild(green.transform.childCount - 1).position.x);

        Vector3 one = green.transform.GetChild(0).position;
        Vector3 two = green.transform.GetChild(green.transform.childCount - 1).position;

        if (isZoom)
        {
            if (one.x > zoom.x || two.x < zoom.y)
            {
                isleft = one.x > zoom.x;
                isLeftDno= one.x > zoom.x;
                isRightDno = two.x < zoom.y;
                green.Sleep();
            }
            else
            {
                //isleft = false;
                green.WakeUp();
            }


        }
        else
        {
            if (one.x > noZoom.x || two.x < noZoom.y)
            {
                isleft = one.x > zoom.x;
                isLeftDno = one.x > noZoom.x;
                isRightDno = two.x < noZoom.y;
                green.Sleep();
            }
            else
            {
                //isleft = false;
                green.WakeUp();
            }
        }
    }
    public void OnBeginDrag(PointerEventData eventData)
    {

    }
    bool isleft = false;
    public void OnDrag(PointerEventData eventData)
    {
        if (Mathf.Abs(eventData.delta.x) > Mathf.Abs(eventData.delta.y))
        {
            if (eventData.delta.x > 0)
            {
                if (isLeftDno)
                {
                    green.GetComponent<Rigidbody2D>().WakeUp();
                    isleft = false;
                    green.AddForce(green.transform.right * eventData.delta.x * speed);
                    isLeftDno = false;
                    return;
                }

                if (isleft)
                {
                    green.GetComponent<Rigidbody2D>().Sleep();
                    green.GetComponent<Rigidbody2D>().WakeUp();
                    isleft = !isleft;
                }
            }
            else
            {
                if (isRightDno)
                {
                    green.GetComponent<Rigidbody2D>().WakeUp();
                    isleft = true;
                    green.AddForce(green.transform.right * eventData.delta.x * speed);
                    isRightDno = false;

                    return;
                }

                if (!isleft)
                {
                    green.GetComponent<Rigidbody2D>().Sleep();
                    green.GetComponent<Rigidbody2D>().WakeUp();
                    isleft = !isleft;

                }
            }



            green.AddForce(green.transform.right * eventData.delta.x * speed);
        }
        else
            green.velocity = new Vector2(green.velocity.x * 0.5f, green.velocity.y);


    }
}
