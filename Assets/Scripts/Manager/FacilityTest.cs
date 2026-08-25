using UnityEngine;

public class FacilityTest : MonoBehaviour
{
    [SerializeField] private FacilityManager facilityManager;
    [SerializeField] private AbnormalityData testAbnormality;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            facilityManager.AssignAbnormality(
                0,
                testAbnormality
            );
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            facilityManager.RemoveAbnormality(0);
        }
    }
}