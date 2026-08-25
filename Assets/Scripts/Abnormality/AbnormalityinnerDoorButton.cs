using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbnormalityinnerDoorButton : MonoBehaviour, IInteractable
{
      [SerializeField] private AbnormalityRoom room;


    public void Interact(HandType hand)
    {
        Debug.Log("Extraction Button Interacted");


        if (room == null)
        {
            Debug.LogWarning(
                "Extraction Button: Room is NULL"
            );

            return;
        }


        Debug.Log(
            "Current Room State: " +
            room.CurrentState
        );


        if (
            room.CurrentState ==
            AbnormalityRoom.RoomState.Reviewing)
        {
            Debug.Log("Changing to Extraction");

            room.ChangeState(
                AbnormalityRoom.RoomState.Extraction
            );

            return;
        }


        if (
            room.CurrentState ==
            AbnormalityRoom.RoomState.Extraction)
        {
            Debug.Log("Changing to Reviewing");

            room.ChangeState(
                AbnormalityRoom.RoomState.Reviewing
            );

            return;
        }
    }
}
