using UnityEngine;

public class Gun : HoldableItems
{
    [Header("Gun Stats")]
    [SerializeField] private int magazineSize = 12;
    [SerializeField] private float fireRate = 0.2f;
    [SerializeField] private float reloadTime = 2f;
    [SerializeField] private float range = 100f;
    [SerializeField] private int damage = 10;

    private int currentAmmo;
    private float nextFireTime;

    private void Start()
    {
        currentAmmo = magazineSize;
    }

    public override void Use()
    {
        if (Time.time < nextFireTime)
        {
            return;
        }

        if (currentAmmo <= 0)
        {
            Debug.Log("Out of ammo.");
            return;
        }

        Fire();

        currentAmmo--;

        nextFireTime =
            Time.time + fireRate;
    }

    private void Fire()
    {
        Debug.Log("Bang!");

        // Raycast later
    }
}