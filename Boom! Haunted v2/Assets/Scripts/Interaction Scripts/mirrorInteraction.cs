using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class mirrorInteraction : MonoBehaviour, IInteractable
{
    public AudioSource sound;
    private bool haunted = false;
    public HauntBar haunt;

    public void Interact()
    {
        sound = GetComponent<AudioSource>();
        sound.Play();
        if(!haunted)
        {
            haunt.UpdateHauntingBar();
            haunted = true;
        }
    }
}
