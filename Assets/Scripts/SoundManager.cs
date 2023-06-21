using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance { get; private set; }
    private AudioSource source;
    public AudioSource background;
    public float baseBackgroundLevel;

    private void Awake()
    {
        background.volume = baseBackgroundLevel;
        source = GetComponent<AudioSource>();
        instance = this;
    }

    public void PlaySound(AudioClip sound, float volume = 1f)
    {
        source.volume = volume;
        source.PlayOneShot(sound);
    }

    public void setBackgroundLevelLow()
    {
        background.volume = 0.25f * baseBackgroundLevel;
    }

    public void setBackgroundLevelNormal()
    {
        background.volume = baseBackgroundLevel;
    }
}
