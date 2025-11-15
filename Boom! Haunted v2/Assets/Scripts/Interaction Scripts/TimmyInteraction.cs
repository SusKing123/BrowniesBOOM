using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimmyInteraction : MonoBehaviour, IInteractable
{
    public AudioSource sound;
    private Collider tBox;
    public HauntBar haunt;

    // Start is called before the first frame update
    void Start()
    {
        tBox = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        if(haunt.currHaunt <= 5)
        {
            tBox.enabled = true;
        }
    }

    public void Interact()
    {
        SceneManager.LoadScene("Level2");
    }
}
