using System;
using UnityEngine;

public class SoundOnHit : MonoBehaviour
{
    public AudioSource audioSource;
    
    void OnCollisionEnter2D(Collision2D other)
    {
        audioSource.Play();
    }
}
