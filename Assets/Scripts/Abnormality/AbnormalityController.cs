using UnityEngine;

public class AbnormalityController : MonoBehaviour
{
    [Header("Abnormality")]
    [SerializeField] private AbnormalityData abnormalityData;


    public void ReceiveWork(
        WorkContribution contribution)
    {
        if (contribution == null) // if there is no contribution return
        {
            return;
        }


        if (abnormalityData == null) // There really shouldn't be an abnormality without data, but just in case, we should check for it.
        {
            Debug.LogWarning(
                "AbnormalityData is missing."
            );

            return;
        }

// Get the multiplier for the work type from the abnormality data
        float multiplier =
            abnormalityData.GetWorkMultiplier(
                contribution.workType
            );

// Calculate the final amount of work to apply based on the contribution and multiplier
        float finalAmount =
            contribution.amount * multiplier;


        Debug.Log(
            abnormalityData.abnormalityName +
            " received " +
            contribution.workType +
            " work."
        );


        Debug.Log(
            "Base Amount: " +
            contribution.amount
        );


        Debug.Log(
            "Multiplier: " +
            multiplier
        );


        Debug.Log(
            "Final Amount: " +
            finalAmount
        );


        ApplyWork(
            contribution.workType,
            finalAmount
        );
    }


    private void ApplyWork(
        WorkType workType,
        float amount)
    {
        Debug.Log(
            "Applied " +
            amount +
            " " +
            workType +
            " work."
        );
    }
}