using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Player Information")]
    [SerializeField] private int playerID;

    [Header("Current State")]
    [SerializeField] private PlayerLocation currentLocation;
    [SerializeField] private PlayerStatus currentStatus;

    public int PlayerID
    {
        get
        {
            return playerID;
        }
    }

    public PlayerLocation CurrentLocation
    {
        get
        {
            return currentLocation;
        }
    }

    public PlayerStatus CurrentStatus
    {
        get
        {
            return currentStatus;
        }
    }

    public void SetLocation(PlayerLocation location)
    {
        currentLocation = location;
    }

    public void SetStatus(PlayerStatus status)
    {
        currentStatus = status;
    }
}
public enum PlayerStatus
{
    Idle,
    Working,
    Dead
}


public class PlayerLocation : MonoBehaviour
{
    public string LocationName;
}