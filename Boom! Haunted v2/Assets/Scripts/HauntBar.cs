using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HauntBar : MonoBehaviour
{
    [SerializeField] private Image hauntBarSprite;

    private Camera camera;

    private void Start()
    {
        camera = Camera.main;
    }

    public void UpdateHauntingBar(float fullBar, float currentBar)
    {
        hauntBarSprite.fillAmount = currentBar / fullBar;
    }

    private void Update()
    {
        //transform.rotation = Quaternion.LookRotation(transform.position - camera.transform.position);
    }
}
