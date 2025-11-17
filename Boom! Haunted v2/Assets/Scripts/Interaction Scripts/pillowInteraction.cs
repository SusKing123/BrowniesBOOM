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
        if (!thrown)
        {
            baseDir = (transform.right + Vector3.up).normalized;
            thrown = true;
        }
        else
            baseDir = (transform.forward + Vector3.up).normalized;

        Vector3 randomOffset = Random.insideUnitSphere * 2f;
        Vector3 finalDir = (baseDir + randomOffset).normalized;

        rb.AddForce(finalDir * launchForce, ForceMode.Impulse);

        Vector3 randomTorque = Random.insideUnitSphere * 20f;
        rb.AddTorque(randomTorque, ForceMode.Impulse);
    }
}
