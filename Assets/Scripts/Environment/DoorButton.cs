using UnityEngine;

public class DoorButton : MonoBehaviour, IInteractable
{
    [SerializeField] private DoorController door;

    public void Interact(HandType hand)
    {
        door.OpenDoor();
    }
}