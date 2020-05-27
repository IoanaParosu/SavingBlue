using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdibleCluster : MonoBehaviour
{
    public GameObject[] edibles = new GameObject[5];
    GameObject holder;
    int iHolder;
    public float foodAmount;
    int[] edibleSeed = new int[] {0,0,0,0,0};
    string pattern;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < foodAmount; i++)
        {
            edibleSeed[i] = 1;
        }
        
        for (int i = 0; i < edibleSeed.Length - 1; i++)
        {
            int rand = Random.Range(0, edibleSeed.Length - i);
            iHolder = edibleSeed[rand];
            edibleSeed[rand] = edibleSeed[i];
            edibleSeed[i] = iHolder;
        }
        for (int i = 0; i < edibleSeed.Length; i++)
        {
            pattern += edibleSeed[i];
        }
        //Debug.Log(pattern);
        for (int i = 0; i < edibleSeed.Length; i++)
        {
            edibles[i].GetComponent<PickupRand>().SetSeed(edibleSeed[i]);
        }
    }
}
