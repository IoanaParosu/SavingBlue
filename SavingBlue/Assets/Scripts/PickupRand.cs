using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupRand : MonoBehaviour
{
    public GameObject food;
    public GameObject plastic;
    // Start is called before the first frame update
    public void SetSeed(int seed)
    {
        if (seed == 0)
        {
            SpawnPlastic();
        }
        else if (seed == 1)
        {
            SpawnFood();
        }
        Destroy(gameObject);
    }

    public void SpawnFood()
    {
        Instantiate(food, transform.position, Quaternion.identity);
    }

    public void SpawnPlastic()
    {
        Instantiate(plastic, transform.position, Quaternion.identity);
    }
}
