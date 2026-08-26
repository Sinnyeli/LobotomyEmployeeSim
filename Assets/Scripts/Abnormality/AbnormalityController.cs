using UnityEngine;

public class AbnormalityController : MonoBehaviour
{
    [Header("Work Progress")]
    [SerializeField] private WorkProgress[] workProgress;

    private Abnormality abnormality;

    private bool workCompleted;


    public bool WorkCompleted
    {
        get
        {
            return workCompleted;
        }
    }


    public AbnormalityData Data
    {
        get
        {
            if (abnormality == null)
            {
                return null;
            }

            return abnormality.Data;
        }
    }


    private void Awake()
    {
        abnormality =
            GetComponent<Abnormality>();

        InitializeWorkProgress();
    }


    private void InitializeWorkProgress()
    {
        workProgress = new WorkProgress[4];

        workProgress[0] = new WorkProgress
        {
            workType = WorkType.Instinct,
            requiredAmount = 10f
        };

        workProgress[1] = new WorkProgress
        {
            workType = WorkType.Insight,
            requiredAmount = 10f
        };

        workProgress[2] = new WorkProgress
        {
            workType = WorkType.Attachment,
            requiredAmount = 10f
        };

        workProgress[3] = new WorkProgress
        {
            workType = WorkType.Repression,
            requiredAmount = 10f
        };
    }


    public void ReceiveWork(
        WorkContribution contribution)
    {
        if (workCompleted)
        {
            return;
        }

        if (contribution == null)
        {
            return;
        }

        if (Data == null)
        {
            Debug.LogWarning(
                "AbnormalityData is missing."
            );

            return;
        }


        float multiplier =
            Data.GetWorkMultiplier(
                contribution.workType
            );


        float finalAmount =
            contribution.amount * multiplier;


        AddWorkProgress(
            contribution.workType,
            finalAmount
        );
    }


    private void AddWorkProgress(
        WorkType workType,
        float amount)
    {
        WorkProgress progress =
            GetWorkProgress(workType);


        if (progress == null)
        {
            return;
        }


        progress.Add(amount);


        Debug.Log(
            workType +
            " Progress: " +
            progress.currentAmount +
            " / " +
            progress.requiredAmount
        );


        if (progress.IsComplete)
        {
            CompleteWork();
        }
    }


    private WorkProgress GetWorkProgress(
        WorkType workType)
    {
        if (workProgress == null)
        {
            return null;
        }


        foreach (WorkProgress progress
                 in workProgress)
        {
            if (progress != null &&
                progress.workType == workType)
            {
                return progress;
            }
        }


        return null;
    }


    private void CompleteWork()
    {
        if (workCompleted)
        {
            return;
        }


        workCompleted = true;


        Debug.Log(
            "WORK COMPLETE!"
        );


        DepositReward();
    }


    private void DepositReward()
    {
        // Reward system will be implemented later.
         // Reward system. 
        // If work progress = positive, more boxes. bad, less boxes. 
        // Once work is complete, reward is deposited. Quitting midway resets everything from the room and does not deposit the box. 

        Debug.Log(
            "Reward deposited."
        );
    }

 public void ResetWork()
{
    workCompleted = false;

    InitializeWorkProgress();

    Debug.Log("Work session reset.");
}
}
    