using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CutsceneText : MonoBehaviour
{
    string[] text = new string[6];

    public Text storyText;
    public Buttons buttons;
    public GameObject fade;

    int textPos = 0;

    public float[] textTime = new float[6];
    public float delay = 2;
    public float fadeTime;
    public float timeBetween;

    // Start is called before the first frame update
    void Start()
    {
        text[0] = "You did it!\nBlue is safe thanks to you!";
        text[1] = "But not all marine life is as lucky.";
        text[2] = "Every year, millions of sea creatures die due to pollution, overfishing and climate change.";
        text[3] = "Do not lose hope!\nTogether we can change this!";
        text[4] = "Recycling, reducing waste and having stricter fishing laws can stop this. ";
        text[5] = "You saved Blue,\nyou can help save his friends!";

        storyText.text = text[0];
        StartCoroutine(Fade(textTime[0], textTime[1], textTime[2], textTime[3], textTime[4], textTime[5], fadeTime, timeBetween));
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Fade(float time1, float time2, float time3, float time4, float time5, float time6, float fadeTime, float timeB)
    {
        yield return new WaitForSeconds(time1);
        StartCoroutine(FadeTextToZeroAlpha(fadeTime, storyText));
        yield return new WaitForSeconds(fadeTime);
        ChangeText();
        yield return new WaitForSeconds(timeB);
        StartCoroutine(FadeTextToFullAlpha(fadeTime, storyText));
        yield return new WaitForSeconds(time2);
        StartCoroutine(FadeTextToZeroAlpha(fadeTime, storyText));
        yield return new WaitForSeconds(fadeTime);
        ChangeText();
        yield return new WaitForSeconds(timeB);
        StartCoroutine(FadeTextToFullAlpha(fadeTime, storyText));
        yield return new WaitForSeconds(time3);
        StartCoroutine(FadeTextToZeroAlpha(fadeTime, storyText));
        yield return new WaitForSeconds(fadeTime);
        ChangeText();
        yield return new WaitForSeconds(timeB);
        StartCoroutine(FadeTextToFullAlpha(fadeTime, storyText));
        yield return new WaitForSeconds(time4);
        StartCoroutine(FadeTextToZeroAlpha(fadeTime, storyText));
        yield return new WaitForSeconds(fadeTime);
        ChangeText();
        yield return new WaitForSeconds(timeB);
        StartCoroutine(FadeTextToFullAlpha(fadeTime, storyText));
        yield return new WaitForSeconds(time5);
        StartCoroutine(FadeTextToZeroAlpha(fadeTime, storyText));
        yield return new WaitForSeconds(fadeTime);
        ChangeText();
        yield return new WaitForSeconds(timeB);
        StartCoroutine(FadeTextToFullAlpha(fadeTime, storyText));
        yield return new WaitForSeconds(time6);

        Instantiate(fade, Vector3.zero, Quaternion.identity);
        yield return new WaitForSeconds(delay);
        buttons.Credits();
    }

    void ChangeText()
    {
        textPos += 1;
        storyText.text = text[textPos];
    }

    public IEnumerator FadeTextToFullAlpha(float t, Text i)
    {
        i.color = new Color(i.color.r, i.color.g, i.color.b, 0);
        while (i.color.a < 1.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a + (Time.deltaTime / t));
            yield return null;
        }
    }

    public IEnumerator FadeTextToZeroAlpha(float t, Text i)
    {
        i.color = new Color(i.color.r, i.color.g, i.color.b, 1);
        while (i.color.a > 0.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a - (Time.deltaTime / t));
            yield return null;
        }
    }
}
