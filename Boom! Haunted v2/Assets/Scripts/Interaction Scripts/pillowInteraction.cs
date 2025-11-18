using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pillowInteraction : MonoBehaviour, IInteractable
{
    public AudioSource sound;
    private bool haunted, thrown = false;
    public HauntBar haunt;
    private Rigidbody rb;

    public float launchForce = 10f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        sound = GetComponent<AudioSource>();
        
    }
    public void Interact()
    {
        if (!haunted)
        {
            sound.Play();
            haunt.UpdateHauntingBar();
            haunted = true;
            StopAllCoroutines();
            StartCoroutine(waitToLaunch());
        }
        else
        {
            launchPillow();
        }
        
    }

    IEnumerator waitToLaunch()
    {
        yield return new WaitForSeconds(2f);
        launchPillow();
    }

    void launchPillow()
    {
        Vector3 baseDir;
        Vector3 randomOffset;
        Vector3 finalDir;
        if (!thrown)
        {
            finalDir = (transform.right + Vector3.up).normalized;
            launchForce = 20;
            thrown = true;
        }
        else
        {
            baseDir = (transform.forward + Vector3.up).normalized;
            randomOffset = Random.insideUnitSphere * 2f;
            finalDir = (baseDir + randomOffset).normalized;
            launchForce = 10;
        }
            
        rb.AddForce(finalDir * launchForce, ForceMode.Impulse);

        Vector3 randomTorque = Random.insideUnitSphere * 20f;
        rb.AddTorque(randomTorque, ForceMode.Impulse);
    }
}
