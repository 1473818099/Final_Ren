using System;
using System.Collections;
using System.Dynamic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Camera playerCamera;
    // Shooting
    public bool isShooting, readyToShoot;
    bool allowReset = true;
    public float shootingDelay = 2f;

    // Burst
    public int bulletsPerBurst = 3;
    public int burstBulletsleft;

    // Spread
    public float spreadIntensity;

    // Bullet
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public float bulletVelocity = 30;
    public float bulletPrefabLifeTime = 3f;

    // Audio
    public AudioClip ShotSound;
    private AudioSource audioSource;

    // Shotting mode
    public enum ShootingMode
    {
        Single,
        Burst,
        Auto
    }

    public ShootingMode currentShootingMode;

    private void Awake()
    {
        readyToShoot = true;
        burstBulletsleft = bulletsPerBurst;
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (currentShootingMode == ShootingMode.Auto)
        {
            // Auto mode
            isShooting = Input.GetKey(KeyCode.Mouse0);

        }
        else if (currentShootingMode == ShootingMode.Single)
        {
            // Single mode
            isShooting = Input.GetKeyDown(KeyCode.Mouse0);
        }

        if (readyToShoot && isShooting)
        {
            burstBulletsleft = bulletsPerBurst;
            FireWeapon();
        }
    }
    private void FireWeapon()
    {
        FireWeapon(allowReset);

    }

    private void FireWeapon(bool allowReset)
    {
        readyToShoot = false;
        Vector3 shootingDirection = CalculateDirectionAndSpread().normalized;



        // Instantiate the bullet
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, Quaternion.identity);

        // Pointing the bullet to face the shooting direction
        bullet.transform.forward = shootingDirection;

        // Add Force to bullet prefab
        bullet.GetComponent<Rigidbody>().AddForce(shootingDirection * bulletVelocity, ForceMode.Impulse);
        
        // Destroy the bullet
        StartCoroutine(DestroyBulletAfterTime(bullet, bulletPrefabLifeTime));

        // Checking if shooting done
        if(allowReset)
        {
            Invoke("ReserShot", shootingDelay);
            allowReset = false;   
        }

        // Burst Mode
        if (currentShootingMode == ShootingMode.Burst && burstBulletsleft > 1)
        {
            burstBulletsleft--;
            Invoke("FireWeapon", shootingDelay);

        }
    }


    private void ReserShot()
    {
        readyToShoot = true;
        allowReset = true;
    }
    public Vector3 CalculateDirectionAndSpread()
    {
        // Shooting from the middle of the screen to check where are we pointing at
        Ray ray = playerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        Vector3 targetPoint;
        if (Physics.Raycast(ray, out hit))
        {
            // Hitting Something
            targetPoint = hit.point;
        }
        else
        {
            // Shooting at the air
            targetPoint = ray.GetPoint(100);
        }
        Vector3 direction = targetPoint - bulletSpawn.position;
    

        float x = UnityEngine.Random.Range(-spreadIntensity, spreadIntensity);
        float y = UnityEngine.Random.Range(-spreadIntensity, spreadIntensity);

        // Returning the direction and spread
        return direction + new Vector3(x, y, 0);
    }


    private IEnumerator DestroyBulletAfterTime(GameObject bullet, float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(bullet);
    }
}
