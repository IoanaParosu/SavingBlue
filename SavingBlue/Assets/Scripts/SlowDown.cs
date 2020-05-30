using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowDown : MonoBehaviour
{
    MovementFish fishMove;
    public PolygonCollider2D cc;
    bool slowed;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        fishMove = collision.GetComponentInParent<MovementFish>();
        if(fishMove != null && slowed == false)
        {
            fishMove.Slower();
            StartCoroutine(SetInactive());
            Debug.Log("COLlIDED");
        }
    }
    IEnumerator SetInactive()
    {
        slowed = true;
        cc.enabled = false;
        yield return new WaitForSeconds(10f);
        slowed = false;
        cc.enabled = true;
    }
}
