using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private Camera playerCamera;
    [SerializeField] private float interactRange = 3f;

    private PlayerInput inputHandler;
    private PlayerHands playerHands;

    private void Awake()
    {
        inputHandler = GetComponent<PlayerInput>();
        playerHands = GetComponent<PlayerHands>();
    }

    private void Update()
    {
        if (inputHandler.LeftClickPressed)
        {
              //  Debug.Log("Left Click");
            HandleHand(HandType.Left);
            inputHandler.ResetLeftClick();
        }

        if (inputHandler.RightClickPressed)
        {
               // Debug.Log("Right Click");
            HandleHand(HandType.Right);
            inputHandler.ResetRightClick();
        }
    }

    private void HandleHand(HandType hand)
    {
        HoldableItems heldItem =
            playerHands.GetItem(hand);

        if (heldItem != null)
        {
            heldItem.Use();
            return;
        }

        InteractWithWorld(hand);
    }

    private void InteractWithWorld(HandType hand)
    {
         //Debug.Log("Raycasting");
        Ray ray =
            playerCamera.ViewportPointToRay(
                new Vector3(0.5f, 0.5f, 0f));

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactRange))
        {
            //Debug.Log("Hit: " + hit.collider.name);
            IInteractable interactable =
                hit.collider.GetComponent<IInteractable>();

            if (interactable != null)
            {
                interactable.Interact(hand);
                Debug.Log("Interacted with: " + hit.collider.name);
            }
        }
    }
}