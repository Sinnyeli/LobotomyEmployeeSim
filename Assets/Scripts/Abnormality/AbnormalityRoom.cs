using UnityEngine;

public class AbnormalityRoom : MonoBehaviour
{
    public enum RoomState
    {
        Inactive,
        Closed,
        Entering,
        Reviewing,
        Extraction,
        Exiting,
        Breaching
    }


    [Header("Abnormality")]
    [SerializeField] private Transform abnormalitySpawnPoint;

    private AbnormalityData assignedAbnormality;
    private GameObject abnormalityInstance;


    [Header("Doors")]
    [SerializeField] private DoorController outerDoor;
    [SerializeField] private DoorController abnormalityDoor;


    [Header("Room State")]
    [SerializeField] private RoomState currentState =
        RoomState.Inactive;


    [Header("Players")]
    [SerializeField] private int playersInside = 0;


    // --------------------------------------------------
    // PROPERTIES
    // --------------------------------------------------

    public RoomState CurrentState
    {
        get
        {
            return currentState;
        }
    }


    public AbnormalityData AssignedAbnormality
    {
        get
        {
            return assignedAbnormality;
        }
    }


    // --------------------------------------------------
    // START
    // --------------------------------------------------

    private void Start()
    {
        if (outerDoor != null)
        {
            outerDoor.OnDoorClosed += OnOuterDoorClosed;
        }

        if (assignedAbnormality == null)
        {
            ChangeState(RoomState.Inactive);
        }
        else
        {
            SpawnAbnormality();

            ChangeState(RoomState.Closed);
        }
    }


    private void OnDestroy()
    {
        if (outerDoor != null)
        {
            outerDoor.OnDoorClosed -= OnOuterDoorClosed;
        }
    }


    // --------------------------------------------------
    // ASSIGN ABNORMALITY
    // --------------------------------------------------

    public void AssignAbnormality(
        AbnormalityData abnormality)
    {
        if (abnormality == null)
        {
            Debug.LogWarning(
                "Cannot assign a null abnormality."
            );

            return;
        }


        if (abnormalityInstance != null)
        {
            Destroy(abnormalityInstance);

            abnormalityInstance = null;
        }


        assignedAbnormality = abnormality;


        SpawnAbnormality();


        ChangeState(RoomState.Closed);
    }


    // --------------------------------------------------
    // REMOVE ABNORMALITY
    // --------------------------------------------------

    public void RemoveAbnormality()
    {
        if (abnormalityInstance != null)
        {
            Destroy(abnormalityInstance);

            abnormalityInstance = null;
        }


        assignedAbnormality = null;


        playersInside = 0;


        ChangeState(RoomState.Inactive);
    }


    // --------------------------------------------------
    // SPAWN ABNORMALITY
    // --------------------------------------------------

    private void SpawnAbnormality()
    {
        if (assignedAbnormality == null)
        {
            return;
        }


        if (assignedAbnormality.abnormalityPrefab == null)
        {
            Debug.LogWarning(
                "Abnormality prefab is missing for " +
                assignedAbnormality.abnormalityName
            );

            return;
        }


        if (abnormalitySpawnPoint == null)
        {
            Debug.LogWarning(
                "Abnormality spawn point is missing."
            );

            return;
        }


        abnormalityInstance = Instantiate(
            assignedAbnormality.abnormalityPrefab,
            abnormalitySpawnPoint.position,
            abnormalitySpawnPoint.rotation
        );


        abnormalityInstance.transform.SetParent(
            abnormalitySpawnPoint
        );
    }


    // --------------------------------------------------
    // PLAYER TRACKING
    // --------------------------------------------------

    public void PlayerEntered()
    {
        playersInside++;


        if (
            currentState ==
            RoomState.Entering)
        {
            ChangeState(
                RoomState.Reviewing
            );
        }
    }


    public void PlayerExited()
    {
        playersInside--;


        if (playersInside < 0)
        {
            playersInside = 0;
        }


        if (
            playersInside == 0 &&
            currentState == RoomState.Exiting)
        {
            ChangeState(
                RoomState.Closed
            );
        }
    }


    public bool HasPlayersInside()
    {
        if (playersInside > 0)
        {
            return true;
        }

        return false;
    }


    public int GetPlayerCount()
    {
        return playersInside;
    }


    // --------------------------------------------------
    // ABNORMALITY CHECK
    // --------------------------------------------------

    public bool HasAbnormality()
    {
        if (assignedAbnormality == null)
        {
            return false;
        }

        return true;
    }


    // --------------------------------------------------
    // STATE CHANGE
    // --------------------------------------------------

    public void ChangeState(RoomState newState)
    {
        if (currentState == newState)
        {
            return;
        }


        ExitState(currentState);


        currentState = newState;


        EnterState(currentState);
    }


    // --------------------------------------------------
    // ENTER STATE
    // --------------------------------------------------

    private void EnterState(RoomState state)
    {
        if (state == RoomState.Inactive)
        {
            EnterInactiveState();
        }


        if (state == RoomState.Closed)
        {
            EnterClosedState();
        }


        if (state == RoomState.Entering)
        {
            EnterEnteringState();
        }


        if (state == RoomState.Reviewing)
        {
            EnterReviewingState();
        }


        if (state == RoomState.Extraction)
        {
            EnterExtractionState();
        }


        if (state == RoomState.Exiting)
        {
            EnterExitingState();
        }


        if (state == RoomState.Breaching)
        {
            EnterBreachingState();
        }
    }


    // --------------------------------------------------
    // EXIT STATE
    // --------------------------------------------------

    private void ExitState(RoomState state)
    {
        if (state == RoomState.Inactive)
        {
            ExitInactiveState();
        }


        if (state == RoomState.Closed)
        {
            ExitClosedState();
        }


        if (state == RoomState.Entering)
        {
            ExitEnteringState();
        }


        if (state == RoomState.Reviewing)
        {
            ExitReviewingState();
        }


        if (state == RoomState.Extraction)
        {
            ExitExtractionState();
        }


        if (state == RoomState.Exiting)
        {
            ExitExitingState();
        }


        if (state == RoomState.Breaching)
        {
            ExitBreachingState();
        }
    }


    // --------------------------------------------------
    // INACTIVE
    // --------------------------------------------------

    private void EnterInactiveState()
    {
        CloseOuterDoor();
        CloseAbnormalityDoor();
    }


    private void ExitInactiveState()
    {
    }


    // --------------------------------------------------
    // CLOSED
    // --------------------------------------------------

    private void EnterClosedState()
    {
        CloseOuterDoor();
        CloseAbnormalityDoor();
    }


    private void ExitClosedState()
    {
    }


    // --------------------------------------------------
    // ENTERING
    // --------------------------------------------------

    private void EnterEnteringState()
    {
        OpenOuterDoor();
        CloseAbnormalityDoor();
    }


    private void ExitEnteringState()
    {
    }


    // --------------------------------------------------
    // REVIEWING
    // --------------------------------------------------

    private void EnterReviewingState()
    {
        CloseOuterDoor();
        CloseAbnormalityDoor();
    }


    private void ExitReviewingState()
    {
    }


    // --------------------------------------------------
    // EXTRACTION
    // --------------------------------------------------

    private void EnterExtractionState()
    {
        CloseOuterDoor();
        OpenAbnormalityDoor();
    }


    private void ExitExtractionState()
    {
    }


    // --------------------------------------------------
    // EXITING
    // --------------------------------------------------

    private void EnterExitingState()
    {
        CloseAbnormalityDoor();
        OpenOuterDoor();
    }


    private void ExitExitingState()
    {
    }


    // --------------------------------------------------
    // BREACHING
    // --------------------------------------------------

    private void EnterBreachingState()
    {
        OpenOuterDoor();
        OpenAbnormalityDoor();
    }


    private void ExitBreachingState()
    {
    }


    // --------------------------------------------------
    // OUTER DOOR CALLBACK
    // --------------------------------------------------

    private void OnOuterDoorClosed()
{
    if (currentState == RoomState.Inactive)
    {
        return;
    }


    if (currentState == RoomState.Entering)
    {
        if (HasPlayersInside())
        {
            ChangeState(
                RoomState.Reviewing
            );
        }
        else
        {
            ChangeState(
                RoomState.Closed
            );
        }

        return;
    }


    if (currentState == RoomState.Exiting)
    {
        if (HasPlayersInside())
        {
            ChangeState(
                RoomState.Reviewing
            );
        }
        else
        {
            ChangeState(
                RoomState.Closed
            );
        }

        return;
    }
}


    // --------------------------------------------------
    // DOORS
    // --------------------------------------------------

    private void OpenOuterDoor()
    {
        if (outerDoor == null)
        {
            return;
        }


        outerDoor.OpenDoor();
    }


    private void CloseOuterDoor()
    {
        if (outerDoor == null)
        {
            return;
        }


        outerDoor.CloseDoor();
    }


    private void OpenAbnormalityDoor()
    {
        if (abnormalityDoor == null)
        {
            return;
        }


        abnormalityDoor.OpenDoor();
    }


    private void CloseAbnormalityDoor()
    {
        if (abnormalityDoor == null)
        {
            return;
        }


        abnormalityDoor.CloseDoor();
    }
}