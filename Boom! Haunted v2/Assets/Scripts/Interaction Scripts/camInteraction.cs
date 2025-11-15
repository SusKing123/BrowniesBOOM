using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camInteraction : MonoBehaviour, IInteractable
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
