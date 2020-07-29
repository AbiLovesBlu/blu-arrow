using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileMovement : MonoBehaviour
{
    private Rigidbody2D arrow;
    private readonly float deltaY = 2.5f; // Y-Axis from the finger position
    public float moveSpeed = 20f;

    void Start()
    {
        arrow = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        {
            if (arrow != null)
            {
                MobileInput();
            }
            else
            {
                Debug.LogWarning("Rigid body not attached to Arrow" + gameObject.name);
            }
        }

    }

    public void MobileInput()
    {

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            if (touchPosition.y < 2.6)
            {
                touchPosition.y += deltaY;
                touchPosition.z = 0;
                Vector3 directon = (touchPosition - transform.position);
                arrow.velocity = new Vector2(directon.x, directon.y) * moveSpeed;

                if (touch.phase == TouchPhase.Ended)
                {
                    arrow.velocity = Vector2.zero;
                }
            }
        }
    }

}