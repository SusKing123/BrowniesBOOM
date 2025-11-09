using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class mirrorInteraction : MonoBehaviour, IInteractable
{
    public AudioSource sound;

    public void Interact()
    {
        sound = GetComponent<AudioSource>();
        sound.Play();
    }
}
