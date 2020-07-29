using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowBoundaries : MonoBehaviour
{
    private Rigidbody2D arrow;
    private readonly float xLim = 4.05f;
    private readonly float yLim = 7f;
    void Start()
    {
        arrow = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        {
            if (arrow != null)
            {
                LimitBoundries();
            }
            else
            {
                Debug.LogWarning("Rigid body not attached to Arrow" + gameObject.name);
            }
        }

    }

    private void LimitBoundries()
    {
        Vector3 position = arrow.transform.position;
        if (position.x > xLim)
        {
            position.x = xLim;
        }
        if (position.x < -xLim)
        {
            position.x = -xLim;
        }
        if (position.y > yLim)
        {
            position.y = yLim;
        }
        if (position.y < -yLim)
        {
            position.y = -yLim;
        }
        arrow.transform.position = position;
    }
}
