using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockBarSpawn : MonoBehaviour
{
    public GameObject blockbarObject;
    private readonly float maxXPosition = 3.64f;
    private float speedBlock;
    private int numBlocks;
    private float distance;

    float timer;
    void Start()
    {
        timer = 1f;
        speedBlock = 5f;
        numBlocks = 3;
        distance = 6f;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime; // Delay the generation
        if (timer <= 0)
        {
            // Randomize the Block Object generator
            float[] choices = { -maxXPosition, -(maxXPosition / 2), 0, (maxXPosition / 2), maxXPosition };
            int numBlockRan = Random.Range(0, numBlocks);
            List<int> choiceList = new List<int>() { -1, -1, -1, -1, -1 };
            // Create non-repetivie Random number 
            for (int j = Random.Range(0, numBlockRan); j <= numBlockRan; j++)
            {
                int Rand = Random.Range(0, 5);
                while (choiceList.Contains(Rand))
                {
                    Rand = Random.Range(0, 5);
                }
                choiceList[j] = Rand;
            }
            choiceList.RemoveAll(i => i == -1);
            for (int i = 0; i < choiceList.Count; i++)
            {
                float posObjSpan = choices[choiceList[i]];
                float yDeviation = Random.Range(-1f,1f);
                Vector3 blockPostion = new Vector3(posObjSpan,(transform.position.y + yDeviation), transform.position.z);
                // Develop the block
                Instantiate(blockbarObject, blockPostion, transform.rotation);
                // Update the speed of the block as game accelerates
                speedBlock += 0.05f; // Varies the speed of the game
                distance += 0.001f; // Change the distace to keep constant objects generated per 
                if (speedBlock > 50f)
                {
                    speedBlock = 50f;
                }
                PlayerPrefs.SetFloat("speed_block", speedBlock);
                timer = distance / speedBlock;  // Update the timer
            }
        }
    }
}
