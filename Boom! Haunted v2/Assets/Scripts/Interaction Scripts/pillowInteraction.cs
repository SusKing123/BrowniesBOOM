using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pillowInteraction : MonoBehaviour, IInteractable
{
    public AudioSource sound;
    private bool haunted = false;
    public HauntBar haunt;

    public void Interact()
    {
        sound = GetComponent<AudioSource>();
        Debug.Log("test 1");
        // apply force to launch across room
        if (!haunted)
        {
            Debug.Log("test 2");
            sound.Play();
            haunt.UpdateHauntingBar();
            haunted = true;
        }
    }
}
