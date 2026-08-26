using UnityEngine;

public class WorkRaycast : MonoBehaviour
{
    [Header("Raycast")]
    [SerializeField] private float range = 10f;
    [SerializeField] private LayerMask workLayer;

    [Header("Work")]
    [SerializeField] private WorkResolver workResolver;


    public void TryWork(WorkAction workAction)
    {
        // ============================================
        // TEST 2 - WORK ACTION
        // ============================================

        Debug.Log(
            "[WORK TEST 2] Player is attempting WorkAction."
        );


        if (workAction == null)
        {
            Debug.LogError(
                "[WORK TEST 2 FAILED] Bare Hand WorkAction is NULL."
            );

            return;
        }


        Debug.Log(
            "[WORK TEST 2] WorkAction: " +
            workAction.name
        );


        // ============================================
        // TEST 1 - RAYCAST
        // ============================================

        Ray ray = new Ray(
            transform.position,
            transform.forward
        );


        Debug.DrawRay(
            transform.position,
            transform.forward * range,
            Color.red,
            1f
        );


        Debug.Log(
            "[WORK TEST 1] WorkRaycast is firing."
        );


        if (!Physics.Raycast(
            ray,
            out RaycastHit hit,
            range,
            workLayer))
        {
            Debug.Log(
                "[WORK TEST 1 FAILED] Raycast hit nothing."
            );

            return;
        }


        Debug.Log(
            "[WORK TEST 1] Raycast hit: " +
            hit.collider.name
        );


        // ============================================
        // TEST 3 - ABNORMALITY
        // ============================================

        AbnormalityController abnormality =
            hit.collider.GetComponentInParent<
                AbnormalityController
            >();


        if (abnormality == null)
        {
            Debug.LogError(
                "[WORK TEST 3 FAILED] " +
                "Raycast hit an object, but it is NOT an Abnormality."
            );

            return;
        }


        Debug.Log(
            "[WORK TEST 3] Abnormality identified: " +
            abnormality.name
        );


        // ============================================
        // TEST 4 - WORK RESOLVER
        // ============================================

        if (workResolver == null)
        {
            Debug.LogError(
                "[WORK TEST 4 FAILED] " +
                "WorkResolver reference is NULL."
            );

            return;
        }


        Debug.Log(
            "[WORK TEST 4] Calling WorkResolver."
        );


        workResolver.ResolveWork(
            workAction,
            abnormality
        );


        Debug.Log(
            "[WORK TEST 4] WorkResolver finished."
        );
    }
}