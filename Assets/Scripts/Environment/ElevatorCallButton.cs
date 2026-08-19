using UnityEngine;

public class ElevatorCallButton : MonoBehaviour, IInteractable
{
    [SerializeField] private ElevatorController elevator;
    [SerializeField] private int floorIndex;

    public void Interact(HandType hand)
    {
        if (elevator == null)
        {
            Debug.LogWarning(
                "Elevator is not assigned to this call button.");

            return;
        }

        elevator.CallElevator(floorIndex);
    }
}