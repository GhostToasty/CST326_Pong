using System;
using NUnit.Framework.Internal.Execution;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip paddleAudio;
    public AudioClip winAudio;
    public AudioClip backgroundMusic;

    
    public AudioSource paddleRightAudioSource;
    public AudioSource paddleLeftAudioSource;
    public AudioSource winRightAudioSource;
    public AudioSource winLeftAudioSource;
    public AudioSource backgroundMusicSource;

    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        backgroundMusicSource.clip = backgroundMusic;
        backgroundMusicSource.playOnAwake = true;
        backgroundMusicSource.loop = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playPaddleRight(float audioPitch)
    {
        paddleRightAudioSource.clip = paddleAudio;
        paddleRightAudioSource.pitch = audioPitch;
        paddleRightAudioSource.Play();
    }

    public void playPaddleLeft(float audioPitch)
    {
        paddleLeftAudioSource.clip = paddleAudio;
        paddleLeftAudioSource.pitch = audioPitch;
        paddleLeftAudioSource.Play();


    }

    public void playWinRight()
    {
        // winRightAudioSource.clip = winAudio;
        winRightAudioSource.PlayOneShot(winAudio);
    }

    public void playWinLeft()
    {
        // winLeftAudioSource.clip = winAudio;
        winLeftAudioSource.PlayOneShot(winAudio);
    }

}
