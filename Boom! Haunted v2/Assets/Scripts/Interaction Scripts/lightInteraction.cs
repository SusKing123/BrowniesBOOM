using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightInteraction : MonoBehaviour, IInteractable
{
    public AudioSource sound;
    public GameObject bulb;
    private bool haunted = false;
    public HauntBar haunt;

    public void Interact()
    {
        sound = GetComponent<AudioSource>(); // get audio listener
        if(bulb.activeSelf)// if it is active
        {
            bulb.SetActive(false); // deactivate it
            if(!haunted)
            {
                sound.Play();
                haunt.UpdateHauntingBar();
                haunted = true;
            }
        }
        else
        {
            bulb.SetActive(true);
        }
    }
}
