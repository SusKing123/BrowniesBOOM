using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IInteractable
{
    public void Interact();
}

public class InteractionsController : MonoBehaviour
{
    public Transform InteractorSource;
    public float InteractRange;
    public GameObject UI;
    private bool lookHaunt = false;

    // Update is called once per frame
    void Update()
    {
        bool haunting = false;
        Ray r = new Ray(InteractorSource.position, InteractorSource.forward);
        if (Physics.Raycast(r, out RaycastHit hitInfo, InteractRange))
        {
            if(hitInfo.collider.CompareTag("Haunt"))
            {
                haunting = true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactObj))
                    {
                        interactObj.Interact();
                    }
                }
            }
        }

        if (haunting && !lookHaunt)
        {
            UI.SetActive(true);
            lookHaunt = true;
        }
        else if (!haunting && lookHaunt)
        {
            UI.SetActive(false);
            lookHaunt = false;
        }

    }
}
