using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DoorPart
{
    public Transform doorObject;

    public DoorController.OpenAxis openAxis =
        DoorController.OpenAxis.X;



    public float openDistance = 1.0f;

    public float openSpeed = 2.0f;
}