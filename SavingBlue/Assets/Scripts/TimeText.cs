using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeText : MonoBehaviour
{
    private string timeText = "Your time: ";
    private Text textBox;
    // Start is called before the first frame update
    void Start()
    {
        timeText = timeText + PlayerPrefs.GetString("Time");
        textBox = GetComponent<Text>();
        textBox.text = timeText;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
