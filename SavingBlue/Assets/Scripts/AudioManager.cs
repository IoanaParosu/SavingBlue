using Unity.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public Sound[] sounds;

    void Awake()
    {
        if (AudioManager.instance == null)
        {
            AudioManager.instance = this;
            DontDestroyOnLoad(this.gameObject);

           
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public  void Start()
    {
        foreach (Sound s in sounds)
        {
            s.audioSrc = gameObject.AddComponent<AudioSource>();
            s.audioSrc.clip = s.clip;
            s.audioSrc.volume = s.volume;
            s.audioSrc.pitch = s.pitch;
            s.audioSrc.loop = s.Loop;
        }
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);

        if(s != null)
        s.audioSrc.Play();
        else
        {
            Debug.Log("PLay: " +name);
             
        }
        
    }
    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s != null)
            s.audioSrc.Stop();
        else
        {
            Debug.Log("Stop: " + name);

        }
    }

    public void OnHover()
    {
        Play("ButtonHover");
    }
    public void ChangeVolume(string name, float volume)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.audioSrc.volume = volume;
    }

    public void ChangePitch(string name, float pitch)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.audioSrc.pitch = pitch;
    }
}