using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Current : MonoBehaviour
{
    public float x = 0;
    public float y = 1;
    public float strength = 10;
    Transform move;
    Vector3 dir = new Vector3(0, 1, 0);
    // Start is called before the first frame update
    void Start()
    {
         
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D collider)
    {
        if(collider.tag == "Player")
        {
            move = collider.transform;
            Debug.Log(move.name);
            move.position += dir * strength * Time.deltaTime;
        }
        
    }
}
