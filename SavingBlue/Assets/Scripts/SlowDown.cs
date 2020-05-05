using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowDown : MonoBehaviour
{
    MovementFish fishMove;
    public CircleCollider2D cc;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        fishMove = collision.GetComponent<MovementFish>();
        if(fishMove != null)
        {
            fishMove.Slower();
        }
    }
    IEnumerator SetInactive()
    {
        cc.enabled = false;
        yield return new WaitForSeconds(2f);
        cc.enabled = true;
    }
}
