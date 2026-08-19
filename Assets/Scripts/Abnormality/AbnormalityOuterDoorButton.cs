using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AbnormalityOuterDoorButton : MonoBehaviour, IInteractable
{
    [SerializeField] private AbnormalityRoom abnormalityRoom;

    public void Interact(HandType hand)
    {
        if (abnormalityRoom == null)
        {
            Debug.LogWarning(
                "Abnormality Room is not assigned."
            );

            return;
        }

        abnormalityRoom.ToggleOuterDoor();
    }
}