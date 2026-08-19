using UnityEngine;

public class AbnormalityRoom : MonoBehaviour
{
    [Header("Entrance")]
    [SerializeField] private DoorController entranceDoor;
    [SerializeField] private DoorController abnormalityDoor;

    [Header("Breach")]
    [SerializeField] private bool isBreaching = false;


public void ToggleOuterDoor()
    {
        if (entranceDoor == null)
        {
            Debug.LogWarning(
                "Outer Door is not assigned."
            );

            return;
        }

        // During a breach, the safety lock is disabled.
        if (isBreaching)
        {
            entranceDoor.ToggleDoor();
            return;
        }

        // If the Abnormality Door is open or opening,
        // the Outer Door cannot open.
        if (IsAbnormalityDoorOpen())
        {
            Debug.Log(
                "Outer Door cannot open. " +
                "Abnormality Door is open."
            );

            return;
        }

        entranceDoor.ToggleDoor();
    }

public void ToggleInnerDoor()
    {
        if (abnormalityDoor == null)
        {
            Debug.LogWarning(
                "Inner Door is not assigned."
            );

            return;
        }

        // During a breach, the safety lock is disabled.
        if (isBreaching)
        {
            abnormalityDoor.ToggleDoor();
            return;
        }

        // If the Abnormality Door is open or opening,
        // the Outer Door cannot open.
        if (IsOuterDoorOpen())
        {
            Debug.Log(
                "Inner Door cannot open. " +
                "Outer Door is open."
            );

            return;
        }

        abnormalityDoor.ToggleDoor();
    }

    // --------------------------------------------------
    // CHECK ABNORMALITY DOOR
    // --------------------------------------------------

    private bool IsAbnormalityDoorOpen()
    {
        if (abnormalityDoor == null)
        {
            return false;
        }

        if (
            abnormalityDoor.CurrentState ==
            DoorController.DoorState.Open)
        {
            return true;
        }

        if (
            abnormalityDoor.CurrentState ==
            DoorController.DoorState.Opening)
        {
            return true;
        }

        return false;
    }
private bool IsOuterDoorOpen()
    {
        if (entranceDoor == null)
        {
            return false;
        }

        if (
            entranceDoor.CurrentState ==
            DoorController.DoorState.Open)
        {
            return true;
        }

        if (
            entranceDoor.CurrentState ==
            DoorController.DoorState.Opening)
        {
            return true;
        }

        return false;
    }

    // --------------------------------------------------
    // BREACH
    // --------------------------------------------------

    public void SetBreaching(bool value)
    {
        isBreaching = value;
    }


}