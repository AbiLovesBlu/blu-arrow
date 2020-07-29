using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBoardMovement : MonoBehaviour
{
    private Rigidbody2D arrow;
    public float moveSpeed = 1500f;

    void Start()
    {
        arrow = GetComponent<Rigidbody2D>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (arrow != null)
        {
            KeyboardInput();
        }
        else
        {
            Debug.LogWarning("Rigid body not attached to Arrow" + gameObject.name);
        }
    }

    private void KeyboardInput()
    {
        float xInput = Input.GetAxis("Horizontal");
        float yInput = Input.GetAxis("Vertical");

        float xforce = xInput * moveSpeed * Time.deltaTime;
        float yforce = yInput * moveSpeed * Time.deltaTime;

        Vector2 force = new Vector2(xforce, yforce);

        arrow.AddForce(force);
    }
}
