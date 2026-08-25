using UnityEngine;

public class WorkManager : MonoBehaviour
{
    [SerializeField] private WorkAction selectedWorkAction;


    public WorkAction SelectedWorkAction
    {
        get
        {
            return selectedWorkAction;
        }
    }


    public void SelectWorkAction(
        WorkAction workAction)
    {
        if (workAction == null)
        {
            Debug.LogWarning(
                "Cannot select a null Work Action."
            );

            return;
        }

        selectedWorkAction = workAction;

        Debug.Log(
            "Selected Work Action: " +
            workAction.actionName
        );
    }


    public void ClearWorkAction()
    {
        selectedWorkAction = null;
    }
}