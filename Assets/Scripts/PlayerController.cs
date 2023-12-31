using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody rb;
    private Animator animator;

    private GameObject interactedObject; // The object the player is currently interacting with

    private SwordPickup swordPickup; // Reference to the SwordPickup script

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        swordPickup = GetComponentInChildren<SwordPickup>(); // Assumes the sword is a child of the player
    }

    private void Update()
    {
        // Player movement
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(horizontalInput, 0f, verticalInput).normalized;

        if (moveDirection != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(moveDirection);
        }

        rb.velocity = moveDirection * moveSpeed;

        // Player attack
        if (Input.GetKeyDown(KeyCode.R) && swordPickup.HasSwordBeenPickedUp())
        {
            // Implement attack logic here
            Attack();
        }

        // Interact with objects
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (interactedObject != null)
            {
                // Get the item name from the tag of the interacted object
                string itemName = interactedObject.tag;

                // Add the item to the inventory and despawn it
                InventoryManager.Instance.AddToInventory(itemName);
                Destroy(interactedObject);
                interactedObject = null;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // When the player enters the trigger zone of an interactable object
        if (other.CompareTag("InteractableObject"))
        {
            interactedObject = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // When the player exits the trigger zone of an interactable object
        if (other.gameObject == interactedObject)
        {
            interactedObject = null;
        }
    }

    private void Attack()
    {
        // Implement your attack logic here
        // Example: Play attack animation and deal damage to enemies
    }
}