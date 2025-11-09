using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laptopInteraction : MonoBehaviour, IInteractable
{
    public AudioSource sound;

    public void Interact()
    {
        sound = GetComponent<AudioSource>();
        sound.Play();
    }
}
