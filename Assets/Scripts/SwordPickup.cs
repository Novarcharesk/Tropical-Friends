using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordPickup : MonoBehaviour
{
    private bool hasBeenPickedUp = false;

    private Collider swordCollider;
    private Renderer swordRenderer;

    private void Start()
    {
        swordCollider = GetComponent<Collider>();
        swordRenderer = GetComponent <Renderer>();

        // Initially, the sword is hidden and non-interactable
        swordCollider.enabled = false;
        swordRenderer.enabled = false;
    }

    public void PickUpSword()
    {
        // Called when the player picks up the sword
        hasBeenPickedUp = true;
        swordCollider.enabled = true;
        swordRenderer.enabled = true;
    }

    public bool HasSwordBeenPickedUp()
    {
        return hasBeenPickedUp;
    }
}