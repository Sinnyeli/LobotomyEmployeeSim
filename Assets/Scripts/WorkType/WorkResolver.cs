using UnityEngine;

public class WorkResolver : MonoBehaviour
{// Deliver result to abnormality
    public void ResolveWork(
        WorkAction workAction,
        AbnormalityController abnormality)
    {
        if (workAction == null)
        {
            Debug.LogWarning(
                "WorkResolver: WorkAction is null."
            );

            return;
        }

        if (abnormality == null)
        {
            Debug.LogWarning(
                "WorkResolver: Abnormality is null."
            );

            return;
        }

        if (workAction.contributions == null ||
            workAction.contributions.Length == 0)
        {
            Debug.LogWarning(
                "WorkResolver: WorkAction has no contributions."
            );

            return;
        }

        Debug.Log(
            "Resolving: " +
            workAction.actionName
        );

        foreach (
            WorkContribution contribution
            in workAction.contributions)
        {
            if (contribution == null)
            {
                continue;
            }

            abnormality.ReceiveWork(
                contribution
            );
        }
    }
}