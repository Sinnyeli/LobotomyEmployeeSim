using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorController : MonoBehaviour
{
     [Header("Elevator")]
    [SerializeField] private Transform elevatorPlatform;
    [SerializeField] private DoorController innerDoor;
    
     [Header("Floors")]
     [SerializeField]
    private List<ElevatorFloor> floorPoints = new List<ElevatorFloor>();

    [Header("Elevator Object")]
    [SerializeField]
    private GameObject elevatorObject;

    [SerializeField]
    private float moveSpeed = 3f;

    private bool isMoving = false;

    public int CurrentFloor { get; private set; }

    public void MoveToFloor(int floorIndex)
    {
        if (isMoving)
        {
            return;
        }

        if (floorIndex == CurrentFloor)
        {
            return;
        }

        StartCoroutine(
            MoveRoutine(
                floorPoints[floorIndex].floorPoint.position));
    }

    private IEnumerator MoveRoutine(Vector3 targetPosition)
    {
            // Close the doors first.
    if (innerDoor != null)
    {
        innerDoor.CloseDoor();
    }

    if (floorPoints[CurrentFloor].outerDoor != null)
    {
        floorPoints[CurrentFloor].outerDoor.CloseDoor();
    }

    // Wait until the inner door is completely closed.
    if (innerDoor != null)
    {
        while (
            innerDoor.CurrentState !=
            DoorController.DoorState.Closed)
        {
            yield return null;
        }
    }

    // Wait until the outer door is completely closed.
    if (floorPoints[CurrentFloor].outerDoor != null)
    {
        while (
            floorPoints[CurrentFloor].outerDoor.CurrentState !=
            DoorController.DoorState.Closed)
        {
            yield return null;
        }
    }

        Debug.Log("Elevator moving to position: " + targetPosition);

        while (
            Vector3.Distance(
                elevatorObject.transform.position,
                targetPosition) > 0.01f)
        {
            elevatorObject.transform.position =
                Vector3.MoveTowards(
                    elevatorObject.transform.position,
                    targetPosition,
                    moveSpeed * Time.deltaTime);

            yield return null;
        }

        Debug.Log("Elevator reached position: " + targetPosition);
        CurrentFloor = floorPoints.IndexOf(
            floorPoints.Find(
                point => point.floorPoint.position == targetPosition));
        elevatorObject. transform.position = targetPosition;
        Debug.Log("Current floor: " + CurrentFloor);
        isMoving = false;
        OpenDoors();
    }

    private void OpenDoors()
    {
        // Open the elevator's inner door.
        if (innerDoor != null)
        {
            innerDoor.OpenDoor();
        }

        // Open the outer door on the current floor.
        if (floorPoints[CurrentFloor].outerDoor != null)
        {
            floorPoints[CurrentFloor].outerDoor.OpenDoor();
        }
    }

    private void CloseDoors()
    {
        // Close the elevator's inner door.
        if (innerDoor != null)
        {
            innerDoor.CloseDoor();
        }

        // Close the outer door on the current floor.
        if (floorPoints[CurrentFloor].outerDoor != null)
        {
            floorPoints[CurrentFloor].outerDoor.CloseDoor();
            Debug.Log("Closing outer door on floor: " + CurrentFloor);  
        }
    }

    public void CallElevator (int floorIndex)
    {
        if (isMoving)
        {
            return;
        }
        if (floorIndex < 0 || floorIndex >= floorPoints.Count)
        {   
        Debug.LogWarning("You forgot to add elevator floor, dumbass.");
        return;
        }
        if (floorIndex == CurrentFloor)
        {
            OpenDoors();
            return;
        }

        StartCoroutine(
            MoveRoutine(
                floorPoints[floorIndex].floorPoint.position));
    }

    private IEnumerator MoveToCalledFloor(int targetFloor)
{
    isMoving = true;

    CloseDoors();

    yield return new WaitForSeconds(1f);

    Vector3 targetPosition =
        floorPoints[targetFloor].floorPoint.position;

    while (
        Vector3.Distance(
            elevatorPlatform.position,
            targetPosition) > 0.01f)
    {
        elevatorPlatform.position =
            Vector3.MoveTowards(
                elevatorPlatform.position,
                targetPosition,
                moveSpeed * Time.deltaTime);

        yield return null;
    }

    elevatorPlatform.position = targetPosition;

    CurrentFloor = targetFloor;

    isMoving = false;

    OpenDoors();
}
}