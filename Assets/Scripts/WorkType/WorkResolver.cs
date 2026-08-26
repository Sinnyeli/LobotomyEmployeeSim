using UnityEngine;

public class WorkResolver : MonoBehaviour
{
    // Tool -> Action -> Work Resolver -> Abnormality Controller
    public void ResolveWork(
        WorkAction workAction,
        AbnormalityController abnormality)
    {
        if (workAction == null || abnormality == null)
        {
            return;
        }

        if (workAction.contributions == null)
        {
            return;
        }

        Debug.Log(
            "Resolving Work: " +
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