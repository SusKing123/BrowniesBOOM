using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camInteraction : MonoBehaviour, IInteractable
{
    public AudioSource sound;
    public GameObject bulb;
    private bool haunted = false;
    public HauntBar haunt;

    public void Interact()
    {
        sound = GetComponent<AudioSource>();
        if (!haunted)
        {
            sound.Play();
            StartCoroutine(waitToPlay());
            haunt.UpdateHauntingBar();
            haunted = true;
        }
    }

    IEnumerator waitToPlay()
    {
        yield return new WaitForSeconds(4f);
        bulb.SetActive(true);
        yield return new WaitForSeconds(.2f);
        bulb.SetActive(false);
        yield return new WaitForSeconds(.2f);
        bulb.SetActive(true);
        yield return new WaitForSeconds(.2f);
        bulb.SetActive(false);

    }
}