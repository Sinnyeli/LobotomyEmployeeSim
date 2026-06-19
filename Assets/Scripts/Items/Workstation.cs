using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Workstation : MonoBehaviour, IInteractable
{
  public void Interact(HandType hand)
    {
        Debug.Log("Used workstation with " + hand + " hand.");
    }
}
