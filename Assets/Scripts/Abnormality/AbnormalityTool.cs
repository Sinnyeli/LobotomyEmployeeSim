using UnityEngine;

public class AbnormalityTool : MonoBehaviour, IInteractable
{// Basically tool that performs work action. 

    [Header("Work")]
    [SerializeField] private WorkAction workAction;


    public WorkAction GetWorkAction()
    {
        return workAction;
    }


    public void Interact(HandType hand)
    {
        Debug.Log(
            "Interacted with tool: " +
            gameObject.name
        );

        // Pickup logic will go here.
    }


    public void Use(
        AbnormalityController abnormality,
        WorkResolver resolver)
    {
        if (resolver == null)
        {
            Debug.LogWarning(
                "AbnormalityTool: WorkResolver is missing."
            );

            return;
        }


        if (abnormality == null)
        {
            Debug.LogWarning(
                "AbnormalityTool: Abnormality is missing."
            );

            return;
        }


        if (workAction == null)
        {
            Debug.LogWarning(
                "AbnormalityTool: WorkAction is missing."
            );

            return;
        }


        resolver.ResolveWork(
            workAction,
            abnormality
        );
    }
}