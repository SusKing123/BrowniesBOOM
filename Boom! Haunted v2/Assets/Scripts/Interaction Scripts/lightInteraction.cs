using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightInteraction : MonoBehaviour, IInteractable
{
    public AudioSource sound;
    public GameObject bulb;
    private bool played = false;

    public void Interact()
    {
        sound = GetComponent<AudioSource>(); // get audio listener
        if(bulb.activeSelf)// if it is active
        {
            bulb.SetActive(false); // deactivate it
            if(!played)
            {
                sound.Play();
                played = true;
            }
        }
        else
        {
            bulb.SetActive(true);
        }
    }
}
