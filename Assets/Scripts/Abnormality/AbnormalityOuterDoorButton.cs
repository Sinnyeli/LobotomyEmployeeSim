using UnityEngine;

public class AbnormalityOuterDoorButton : MonoBehaviour, IInteractable
{
    public enum ButtonType
    {
        Entrance,
        Exit
    }

    [SerializeField] private AbnormalityRoom room;
    [SerializeField] private ButtonType buttonType;


    public void Interact(HandType hand)
    {
        if (room == null)
        {
            return;
        }

        if (buttonType == ButtonType.Entrance)
        {
            HandleEntranceButton();
        }

        if (buttonType == ButtonType.Exit)
        {
            HandleExitButton();
        }
    }


    private void HandleEntranceButton()
    {
        if (!room.HasAbnormality())
        {
            return;
        }

        if (
            room.CurrentState ==
            AbnormalityRoom.RoomState.Closed)
        {
            room.ChangeState(
                AbnormalityRoom.RoomState.Entering
            );

            return;
        }

        if (
            room.CurrentState ==
            AbnormalityRoom.RoomState.Entering)
        {
            room.ChangeState(
                AbnormalityRoom.RoomState.Closed
            );

            return;
        }
    }


    private void HandleExitButton()
    {
        if (
            room.CurrentState ==
            AbnormalityRoom.RoomState.Reviewing)
        {
            room.ChangeState(
                AbnormalityRoom.RoomState.Exiting
            );

            return;
        }

        if (
            room.CurrentState ==
            AbnormalityRoom.RoomState.Exiting)
        {
            room.ChangeState(
                AbnormalityRoom.RoomState.Reviewing
            );

            return;
        }
    }
}