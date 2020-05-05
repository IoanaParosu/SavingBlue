using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private Vector2 spawnPos1 = new Vector2(0, 0);
    private Vector2 spawnPos2 = new Vector2(0, 0);
    private float maxHeight = 164.4f, maxWidth = 8.889f, minHeight = -5, minWidth = -8.889f;
    public float spawnAmount;

    public GameObject food;
    public GameObject plastic;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < spawnAmount; i++)
        {
            spawnPos1.x = Random.Range(minWidth, maxWidth);
            spawnPos1.y = Random.Range(minHeight, maxHeight);
            spawnPos2.x = Random.Range(minWidth, maxWidth);
            spawnPos2.y = Random.Range(minHeight, maxHeight);

            Instantiate(food, spawnPos1, Quaternion.identity);
            Instantiate(plastic, spawnPos2, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
