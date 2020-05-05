using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fin : MonoBehaviour
{
    bool shouldRotate;
    public Transform fin;
    public float playerInput;
    // Start is called before the first frame update
    void Start()
    {
        shouldRotate = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (fin.transform.rotation.z <= 0.15f || fin.transform.rotation.z >= 0.99f)
        {
            Debug.Log("Im False NOWW");
            shouldRotate = false;
        }
        else
        {
            shouldRotate = true;
        }

        // Get player input from triggers (L2 ranges from -0.01 to -1, R2 ranges from 0.01 to 1)
        playerInput = Input.GetAxis("Mouse X");
        // Checks if player input was L2, if so rotate player clockwise and move forward the same speed as the input value
        if (playerInput < 0)
        {

            
            RotateFin(playerInput);
        }
        // Checks if player input was R2, if so rotate player counterclockwise and move forward the same speed as the input value
        else if (playerInput > 0)
        {

           
            RotateFin(playerInput);
        }
        //TestTest
    }


    void RotateFin(float input)
    {
        if (shouldRotate)
        {
            fin.transform.eulerAngles = new Vector3(fin.transform.eulerAngles.x, fin.transform.eulerAngles.y, fin.transform.eulerAngles.z + playerInput * 3);
            Debug.Log(fin.transform.rotation.z);
        }
    }
}
