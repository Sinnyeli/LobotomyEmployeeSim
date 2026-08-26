using System;

[Serializable]
public class WorkProgress
{
    public WorkType workType;

    public float currentAmount;

    public float requiredAmount = 10f;

    public bool IsComplete
    {
        get
        {
            return currentAmount >= requiredAmount;
        }
    }

    public void Add(float amount)
    {
        currentAmount += amount;

        if (currentAmount > requiredAmount)
        {
            currentAmount = requiredAmount;
        }
    }
}