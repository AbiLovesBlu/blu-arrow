using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBlockBar : MonoBehaviour
{
    private float speed = 5f;
    void Start()
    {
        speed = PlayerPrefs.GetFloat("speed_block");
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, -1, 0) * speed * Time.deltaTime);
        if (transform.position.y <= -10)
        {
            Destroy(gameObject);
        }
    }
}
