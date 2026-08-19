using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WorkType
{
    Instinct, // Basically any work that involves harming something physically. 
    Insight, // Basically any work that involves understanding or perceiving something in a new way. Holding a notepad often will do and scribbling it down.
    Attachment, // Basically any work that involves forming a bond with something or someone. 
    Repression // Basically any work that involves suppressing or controlling something.
}
public enum WorkState
{
   Idle, // Employee is not in the room working
   Working, // Employee in the room is working on the abnormality. 
   Complete // Employee has to exit the abnormality room to reset.
}