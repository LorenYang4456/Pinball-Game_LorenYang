using System;
using UnityEngine;

public class SoundTriggerOnHit : MonoBehaviour
{
    public AudioSource audioSource;

    void OnTriggerEnter2D(Collider2D other)
    {
        audioSource.Play();
    }
}
