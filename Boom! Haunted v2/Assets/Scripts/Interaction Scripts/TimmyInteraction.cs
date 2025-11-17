using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimmyInteraction : MonoBehaviour, IInteractable
{
    public AudioSource sound;
    public GameObject timmy;
    public HauntBar haunt;
    private bool changed = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!changed)
        {
            changeTag();
        }
    }

    public void Interact()
    {
        sound = GetComponent<AudioSource>();
        sound.Play();
        StartCoroutine(waitForLine());
    }

    void changeTag()
    {
        if (timmy.tag == "noHaunt")
        {
            timmy.tag = "Haunt";
        }
    }
    IEnumerator waitForLine()
    {
        yield return new WaitForSeconds(11.7f);
        SceneManager.LoadScene("Level2");
    }
}
