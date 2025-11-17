using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.RestService;
using UnityEngine;


public class postersInteraction : MonoBehaviour
{
    public AudioSource sound;
    private bool played = false;

    private void OnTriggerEnter(Collider other)
    {
        if(played == false)
        {
            sound = GetComponent<AudioSource>();
            sound.Play();
            Debug.Log("hi");
            played = true;
        }
    }
}
