using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Everything Sound related is managed here
 * Class uses Singleton for easier use 
 */
public class SoundManager : MonoBehaviour
{
    public AudioSource success;
    public AudioSource failure;
    public AudioSource alreadyKnown;

    public static SoundManager Instance = null;
    
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);
    }

    public void playSuccess()
    {
        success.Play();
    }

    public void playFailure()
    {
        failure.Play();
    }

    public void playAlreadyKnown()
    {
        alreadyKnown.Play();
    }

}
