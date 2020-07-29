using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockTailSpawn : MonoBehaviour
{
    public GameObject glowTail;
    float timer;
    void Start()
    {
        timer = 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        int numberTail = Random.Range(1, 3);
        timer -= Time.deltaTime; // Delay the generation
        if (timer <= 0)
        {
            //for (int i = 0; i < numberTail; i++)
            //{
            // Get the current position of the arrow
            Vector3 positionArrow = GameObject.Find("ArrowHead").transform.position;
            // Generate Tail in Random
            float posXTailSpan = positionArrow.x + Random.Range(-0.3f, +0.3f);
            float posYTailSpan = positionArrow.y + Random.Range(-0.18f, -0.75f);
            Vector3 TailPosition = new Vector3(posXTailSpan, posYTailSpan, 0f);

            Instantiate(glowTail, TailPosition, transform.rotation);
            //}
            timer = 0.1f;
        }
    }
}
