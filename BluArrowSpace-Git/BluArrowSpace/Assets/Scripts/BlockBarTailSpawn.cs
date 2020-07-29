using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockBarTailSpawn : MonoBehaviour
{
    public GameObject TailGlowObject;
    private Vector3 positionBlock;
    private GameObject[] blockTotal;
    float timer = 0f;
    //void Start()
    //{

    //}

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("blockBar") != null)
        {
            positionBlock = GameObject.FindGameObjectWithTag("blockBar").transform.position;
            blockTotal = GameObject.FindGameObjectsWithTag("blockBar");
            int lengthBlock = blockTotal.Length;
            for (int i=0; i<lengthBlock; i++)
            {
                positionBlock = blockTotal[i].transform.position;
                //AddTail(positionBlock);
                timer -= Time.deltaTime; // Delay the generation
                if (timer <= 0)
                {
                    float posXTailSpan = positionBlock.x + Random.Range(-0.65f, 0.65f);
                    float posYTailSpan = positionBlock.y;
                    Vector3 TailPosition = new Vector3(posXTailSpan, posYTailSpan, 0f);
                    Instantiate(TailGlowObject, TailPosition, transform.rotation);
                    timer = 0.25f;
                }
            }
            
        }
    }
}