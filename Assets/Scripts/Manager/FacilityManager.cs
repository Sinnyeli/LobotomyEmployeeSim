using UnityEngine;

public class FacilityManager : MonoBehaviour
{
    [System.Serializable]
    public class RoomAssignment
    {
        public AbnormalityRoom room;

        public bool isAvailable = true;

        public AbnormalityData assignedAbnormality;
    }

    [Header("Containment Rooms")]
    [SerializeField] private RoomAssignment[] rooms;


    // --------------------------------------------------
    // ASSIGN ABNORMALITY
    // --------------------------------------------------

    public bool AssignAbnormality(
        int roomIndex,
        AbnormalityData abnormality)
    {
        if (!IsValidRoomIndex(roomIndex))
        {
            return false;
        }

        if (abnormality == null)
        {
            Debug.LogWarning(
                "Cannot assign a null abnormality."
            );

            return false;
        }

        RoomAssignment assignment =
            rooms[roomIndex];

        if (!assignment.isAvailable)
        {
            Debug.LogWarning(
                "Room is not available."
            );

            return false;
        }

        if (assignment.room == null)
        {
            Debug.LogWarning(
                "Room reference is missing."
            );

            return false;
        }

        assignment.assignedAbnormality =
            abnormality;

        assignment.isAvailable = false;

        assignment.room.AssignAbnormality(
            abnormality
        );

        return true;
    }


    // --------------------------------------------------
    // REMOVE ABNORMALITY
    // --------------------------------------------------

    public bool RemoveAbnormality(
        int roomIndex)
    {
        if (!IsValidRoomIndex(roomIndex))
        {
            return false;
        }

        RoomAssignment assignment =
            rooms[roomIndex];

        if (assignment.room == null)
        {
            return false;
        }

        assignment.assignedAbnormality =
            null;

        assignment.isAvailable = true;

        assignment.room.RemoveAbnormality();

        return true;
    }


    // --------------------------------------------------
    // ROOM AVAILABILITY
    // --------------------------------------------------

    public bool IsRoomAvailable(
        int roomIndex)
    {
        if (!IsValidRoomIndex(roomIndex))
        {
            return false;
        }

        return rooms[roomIndex].isAvailable;
    }


    // --------------------------------------------------
    // GET ASSIGNED ABNORMALITY
    // --------------------------------------------------

    public AbnormalityData GetAssignedAbnormality(
        int roomIndex)
    {
        if (!IsValidRoomIndex(roomIndex))
        {
            return null;
        }

        return rooms[roomIndex].assignedAbnormality;
    }


    // --------------------------------------------------
    // GET ROOM
    // --------------------------------------------------

    public AbnormalityRoom GetRoom(
        int roomIndex)
    {
        if (!IsValidRoomIndex(roomIndex))
        {
            return null;
        }

        return rooms[roomIndex].room;
    }


    // --------------------------------------------------
    // FIND AVAILABLE ROOM
    // --------------------------------------------------

    public int GetAvailableRoom()
    {
        for (int i = 0; i < rooms.Length; i++)
        {
            if (rooms[i].isAvailable)
            {
                return i;
            }
        }

        return -1;
    }


    // --------------------------------------------------
    // VALIDATION
    // --------------------------------------------------

    private bool IsValidRoomIndex(
        int roomIndex)
    {
        if (rooms == null ||
            rooms.Length == 0)
        {
            return false;
        }

        if (roomIndex < 0 ||
            roomIndex >= rooms.Length)
        {
            return false;
        }

        return true;
    }
}