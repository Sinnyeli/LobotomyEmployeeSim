using UnityEngine;

public class TestGun : MonoBehaviour
{
    [Header("Projectile")]
    [SerializeField] private GameObject projectilePrefab;

    [SerializeField] private Transform projectileSpawnPoint;

    [SerializeField] private float projectileSpeed = 30f;


    [Header("Work")]
    [SerializeField] private WorkRaycast workRaycast;

    [SerializeField] private WorkAction workAction;


    public void Fire()
    {
        FireProjectile();

        PerformWork();
    }


    private void FireProjectile()
    {
        if (projectilePrefab == null ||
            projectileSpawnPoint == null)
        {
            Debug.LogWarning(
                "Gun projectile setup is incomplete."
            );

            return;
        }


        GameObject projectile =
            Instantiate(
                projectilePrefab,
                projectileSpawnPoint.position,
                projectileSpawnPoint.rotation
            );


        Rigidbody rb =
            projectile.GetComponent<Rigidbody>();


        if (rb != null)
        {
            rb.velocity =
                projectileSpawnPoint.forward *
                projectileSpeed;
        }
    }


    private void PerformWork()
    {
        if (workRaycast == null)
        {
            return;
        }


        if (workAction == null)
        {
            return;
        }


        workRaycast.TryWork(
            workAction
        );
    }
}