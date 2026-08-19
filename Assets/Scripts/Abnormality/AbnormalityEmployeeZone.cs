using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbnormalityEmployeeZone : MonoBehaviour
{
    [SerializeField] private AbnormalityRoom abnormalityRoom;

    private void OnTriggerEnter(Collider other)
    {
        Player player = other.GetComponent<Player>();

        if (player == null)
        {
            return;
        }

        if (abnormalityRoom == null)
        {
            Debug.LogWarning(
                "Abnormality Room is not assigned."
            );

            return;
        }

        //abnormalityRoom.PlayerEnteredRoom(player);
    }

    private void OnTriggerExit(Collider other)
    {
        Player player = other.GetComponent<Player>();

        if (player == null)
        {
            return;
        }

        if (abnormalityRoom == null)
        {
            return;
        }

        //abnormalityRoom.PlayerExitedRoom(player);
    }
}