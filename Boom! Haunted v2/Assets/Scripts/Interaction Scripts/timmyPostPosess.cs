using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class timmyPostPosess : MonoBehaviour
{
    public AudioSource sound;
    public GameObject timmy;

    private void Start()
    {
        StartCoroutine(waitForLine());
    }

    IEnumerator waitForLine()
    {
        yield return new WaitForSeconds(1f);
        sound = GetComponent<AudioSource>();
        sound.Play();   
    }
}
