using UnityEngine;

[CreateAssetMenu(
    fileName = "New Work Action",
    menuName = "Game/Work Action"
)]
public class WorkAction : ScriptableObject
{// Basically what action is being performed when using tool. 
    // Tool => Work Action => Work Resolver
    [Header("Action")]
    public string actionName;

    [Header("Work")]
    public WorkContribution[] contributions;
}
