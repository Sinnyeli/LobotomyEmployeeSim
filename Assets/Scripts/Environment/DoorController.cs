using System.Collections;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    [Header("Door Parts")]
    [SerializeField] private Transform leftDoor;
    [SerializeField] private Transform rightDoor;

    [Header("Open Offsets")]
    [SerializeField] private Vector3 leftOpenOffset;
    [SerializeField] private Vector3 rightOpenOffset;

    [Header("Settings")]
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float autoCloseDelay = 5f;

    private Vector3 leftClosedPosition;
    private Vector3 rightClosedPosition;

    private Vector3 leftOpenPosition;
    private Vector3 rightOpenPosition;

    private bool isOpen;

    private Coroutine moveRoutine;
    private Coroutine autoCloseRoutine;

    private void Awake()
    {
        leftClosedPosition = leftDoor.localPosition;
        rightClosedPosition = rightDoor.localPosition;

        leftOpenPosition =
            leftClosedPosition + leftOpenOffset;

        rightOpenPosition =
            rightClosedPosition + rightOpenOffset;
    }

    public void OpenDoor()
    {
        if (isOpen)
        {
            return;
        }

        isOpen = true;

        if (moveRoutine != null)
        {
            StopCoroutine(moveRoutine);
        }

        moveRoutine =
            StartCoroutine(
                MoveDoors(
                    leftOpenPosition,
                    rightOpenPosition));

        if (autoCloseRoutine != null)
        {
            StopCoroutine(autoCloseRoutine);
        }

        autoCloseRoutine =
            StartCoroutine(AutoCloseRoutine());
    }

    public void CloseDoor()
    {
        if (!isOpen)
        {
            return;
        }

        isOpen = false;

        if (moveRoutine != null)
        {
            StopCoroutine(moveRoutine);
        }

        moveRoutine =
            StartCoroutine(
                MoveDoors(
                    leftClosedPosition,
                    rightClosedPosition));
    }

    private IEnumerator AutoCloseRoutine()
    {
        yield return new WaitForSeconds(autoCloseDelay);

        CloseDoor();
    }

    private IEnumerator MoveDoors(
        Vector3 leftTarget,
        Vector3 rightTarget)
    {
        while (
            Vector3.Distance(leftDoor.localPosition, leftTarget) > 0.01f ||
            Vector3.Distance(rightDoor.localPosition, rightTarget) > 0.01f)
        {
            leftDoor.localPosition =
                Vector3.MoveTowards(
                    leftDoor.localPosition,
                    leftTarget,
                    moveSpeed * Time.deltaTime);

            rightDoor.localPosition =
                Vector3.MoveTowards(
                    rightDoor.localPosition,
                    rightTarget,
                    moveSpeed * Time.deltaTime);

            yield return null;
        }

        leftDoor.localPosition = leftTarget;
        rightDoor.localPosition = rightTarget;
    }
}