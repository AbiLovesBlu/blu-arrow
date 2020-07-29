using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockBarGlowTail : MonoBehaviour
{
    private readonly float speed = 2f;
    float deltaY;
    // Start is called before the first frame update
    void Start()
    {
        float tailDistance = Random.Range(0.45f, 0.65f);
        Vector3 positionGlow = transform.position;
        deltaY = positionGlow.y + tailDistance;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, 1, 0) * speed * Time.deltaTime);
        if (transform.position.y >= deltaY)
        {
            Destroy(gameObject);
        }
    }
}
