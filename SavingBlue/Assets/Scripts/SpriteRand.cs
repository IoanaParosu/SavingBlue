using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteRand : MonoBehaviour
{
    public Sprite[] spriteBox;
    public SpriteRenderer spr;
    // Start is called before the first frame update
    void Start()
    {
        spr.sprite = spriteBox[Random.Range(0, spriteBox.Length)];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
