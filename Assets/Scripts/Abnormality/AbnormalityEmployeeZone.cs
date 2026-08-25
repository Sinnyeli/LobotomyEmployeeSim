using UnityEngine;

public class AbnormalityEmployeeZone : MonoBehaviour
{
    [SerializeField] private AbnormalityRoom room;


     private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
        {
            return;
        }

        room.PlayerEntered();
    }


    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player"))
        {
            return;
        }

        room.PlayerExited();
    }
}