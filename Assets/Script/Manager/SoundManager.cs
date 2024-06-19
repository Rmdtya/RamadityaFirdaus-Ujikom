using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;    
    public AudioClip buttonclik;
    public AudioClip eatsfx;
    public AudioClip soundgameover;
    public AudioClip food;
    private AudioSource audiosource;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        audiosource = GetComponent<AudioSource>();
    }

    public void PlayEatSound()
    {
        audiosource.PlayOneShot(eatsfx);
    }

    public void PlayFood()
    {
        audiosource.PlayOneShot(food);
    }

    public void PlaySoundGameOver()
    {
        audiosource.PlayOneShot(soundgameover);
    }

    public void ClickButton()
    {
        audiosource.PlayOneShot(buttonclik);
    }
}
