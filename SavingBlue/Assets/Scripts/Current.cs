using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Current : MonoBehaviour
{
    public float x = 0;
    public float y = 1;

    public Transform startPoint;
    public Transform endPoint;

    public float strength = 10;

    private float heading;

    Transform move;
    
    Vector3 dir = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        var heading = endPoint.position - startPoint.position;
        var distance = heading.magnitude;
        dir = heading / distance;
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
