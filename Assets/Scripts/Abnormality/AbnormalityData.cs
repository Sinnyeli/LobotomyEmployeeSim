using System.Collections;
using UnityEngine;
// Scriptable Object for Abnormality Data (assigned here because it is associated with room.)

[CreateAssetMenu(
    fileName = "New Abnormality",
    menuName = "Game/Abnormality Data"
)]
public class AbnormalityData : ScriptableObject
{
    [Header("Basic Information")]
    public string abnormalityName;

    [TextArea(3, 6)]
    public string description;

    [Header("Classification")]
    public string abnormalityCode;

    [Header("Prefab")]
    public GameObject abnormalityPrefab;

    [Header("Work Response")]
    public AbnormalityWorkResponse[] workResponses;

    public float GetWorkMultiplier(WorkType workType) // Returns multiplier so other scripts can use it to calculate work contribution. 
    // Basically it's literally here so it's called upon instead of having each script just fetch this information from scratch and store it. 
{
    if (workResponses == null)
    {
        return 1.0f;
    }


    for (int i = 0; i < workResponses.Length; i++)
    {
        if (workResponses[i] == null)
        {
            continue;
        }


        if (workResponses[i].workType == workType)
        {
            return workResponses[i].multiplier;
        }
    }


    return 1.0f;
}
}