using UnityEngine;

public class WorkRaycast : MonoBehaviour
{ // Basically checks. If raycast hits abnormality, it'll send abnormality this specific work type.
// If it misses, then it won't send anything. (return null statement)
    [Header("Raycast")]
    [SerializeField] private float range = 10f;
    [SerializeField] private LayerMask workLayer;

    [Header("Work")]
    [SerializeField] private WorkResolver workResolver;


    public void TryWork(WorkAction workAction)
    {
        if (workAction == null)
        {
            Debug.LogWarning(
                "WorkRaycast: WorkAction is missing."
            );

            return;
        }

        if (workResolver == null)
        {
            Debug.LogWarning(
                "WorkRaycast: WorkResolver is missing."
            );

            return;
        }


        Ray ray = new Ray(
            transform.position,
            transform.forward
        );


        if (!Physics.Raycast(
            ray,
            out RaycastHit hit,
            range,
            workLayer))
        {
            return;
        }


        AbnormalityController abnormality =
            hit.collider.GetComponentInParent<
                AbnormalityController
            >();


        if (abnormality == null)
        {
            return;
        }


        workResolver.ResolveWork(
            workAction,
            abnormality
        );
    }
}