using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class phoneController : MonoBehaviour, IInteractable
{
    public AudioSource sound;


    public void Interact()
    {
        sound = GetComponent<AudioSource>();
        sound.Play();
        Debug.Log("This is the phone interaction!");

    }
}
