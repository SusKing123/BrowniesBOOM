using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class phoneController : MonoBehaviour, IInteractable
{
    public AudioSource sound;
    private bool haunted = false;
    public HauntBar haunt;


    public void Interact()
    {
        if(!haunted)
        {
            sound = GetComponent<AudioSource>();
            sound.Play();
            haunt.UpdateHauntingBar();
            haunted = true;
        }
    }
}
