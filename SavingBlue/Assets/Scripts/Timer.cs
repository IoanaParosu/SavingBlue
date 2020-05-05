using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timerText;
    public float seconds, minutes;
    bool stoptimer = false;
    // Start is called before the first frame update
    void Start()
    {
        timerText = GetComponent<Text>() as Text;
    }

    // Update is called once per frame
    void Update()
    {
        if (stoptimer == false)
        {
            minutes = (int)(Time.time / 60f);
            seconds = (int)(Time.time % 60f);
            timerText.text = minutes.ToString("00") + ":" + seconds.ToString("00");
        }
    }
    public void StopTimer()
    {
        stoptimer = true;
    }
    public void SaveTime()
    {
        string finalTime = minutes.ToString("00") + ":" + seconds.ToString("00");
        PlayerPrefs.SetString("Time", finalTime);
    }
}
