using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class postersInteraction : MonoBehaviour
{
    public AudioSource sound;
    private bool played = false;

    private void OnTriggerEnter(Collider other)
    {
        if(played == false && other.CompareTag("Player"))
        {
            sound = GetComponent<AudioSource>();
            sound.Play();
            played = true;
        }
    }
}
