using UnityEngine;

public class ElevatorButton : MonoBehaviour, IInteractable

{
    [SerializeField]
    private ElevatorController elevator;

    [SerializeField]
    private int floorIndex;

    public void Interact(HandType hand)
    {
        if (elevator == null)
        {
            Debug.LogWarning("Elevator is not assigned to this button.");
            return;
        }

        elevator.MoveToFloor(floorIndex);
    }

}