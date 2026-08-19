using System.Collections;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public enum DoorState
    {
        Closed,
        Opening,
        Open,
        Closing
    }

    public enum OpenAxis
    {
        X,
        Y,
        Z
    }

    [Header("Door Parts")]
    [SerializeField] private DoorPart[] doorParts;

    private Vector3[] closedPositions;
    private Vector3[] openPositions;

    private DoorState currentState =
        DoorState.Closed;

    public DoorState CurrentState
    {
        get
        {
            return currentState;
        }
    }

    private void Awake()
    {
        if (doorParts == null || doorParts.Length == 0)
        {
            Debug.LogWarning(
                "No door parts have been assigned to " +
                gameObject.name
            );

            return;
        }

        closedPositions =
            new Vector3[doorParts.Length];

        openPositions =
            new Vector3[doorParts.Length];

        for (int i = 0; i < doorParts.Length; i++)
        {
            if (doorParts[i] == null)
            {
                continue;
            }

            if (doorParts[i].doorObject == null)
            {
                continue;
            }

            closedPositions[i] =
                doorParts[i].doorObject.localPosition;

            Vector3 movement =
                GetMovementDirection(doorParts[i]);

            openPositions[i] =
                closedPositions[i] +
                movement;
        }
    }

    private Vector3 GetMovementDirection(
        DoorPart doorPart)
    {
        float direction = 1.0f;

        Vector3 axis = Vector3.zero;

        if (doorPart.openAxis == OpenAxis.X)
        {
            axis = Vector3.right;
        }

        if (doorPart.openAxis == OpenAxis.Y)
        {
            axis = Vector3.up;
        }

        if (doorPart.openAxis == OpenAxis.Z)
        {
            axis = Vector3.forward;
        }

        return axis *
            direction *
            doorPart.openDistance;
    }

    public void ToggleDoor()
    {
        if (currentState == DoorState.Closed)
        {
            OpenDoor();
            return;
        }

        if (currentState == DoorState.Opening)
        {
            CloseDoor();
            return;
        }

        if (currentState == DoorState.Open)
        {
            CloseDoor();
            return;
        }

        if (currentState == DoorState.Closing)
        {
            OpenDoor();
            return;
        }
    }

    public void OpenDoor()
    {
        if (doorParts == null ||
            doorParts.Length == 0)
        {
            return;
        }

        StopAllCoroutines();

        StartCoroutine(OpenDoorRoutine());
    }

    public void CloseDoor()
    {
        if (doorParts == null ||
            doorParts.Length == 0)
        {
            return;
        }

        StopAllCoroutines();

        StartCoroutine(CloseDoorRoutine());
    }

    private IEnumerator OpenDoorRoutine()
    {
        currentState =
            DoorState.Opening;

        bool finished = false;

        while (!finished)
        {
            finished = true;

            for (int i = 0;
                i < doorParts.Length;
                i++)
            {
                if (doorParts[i] == null)
                {
                    continue;
                }

                if (doorParts[i].doorObject == null)
                {
                    continue;
                }

                float speed =
                    doorParts[i].openSpeed;

                doorParts[i].doorObject.localPosition =
                    Vector3.MoveTowards(
                        doorParts[i].doorObject.localPosition,
                        openPositions[i],
                        speed * Time.deltaTime
                    );

                if (
                    doorParts[i].doorObject.localPosition !=
                    openPositions[i]
                )
                {
                    finished = false;
                }
            }

            yield return null;
        }

        currentState =
            DoorState.Open;
    }

    private IEnumerator CloseDoorRoutine()
    {
        currentState =
            DoorState.Closing;

        bool finished = false;

        while (!finished)
        {
            finished = true;

            for (int i = 0;
                i < doorParts.Length;
                i++)
            {
                if (doorParts[i] == null)
                {
                    continue;
                }

                if (doorParts[i].doorObject == null)
                {
                    continue;
                }

                float speed =
                    doorParts[i].openSpeed;

                doorParts[i].doorObject.localPosition =
                    Vector3.MoveTowards(
                        doorParts[i].doorObject.localPosition,
                        closedPositions[i],
                        speed * Time.deltaTime
                    );

                if (
                    doorParts[i].doorObject.localPosition !=
                    closedPositions[i]
                )
                {
                    finished = false;
                }
            }

            yield return null;
        }

        currentState =
            DoorState.Closed;
    }
}