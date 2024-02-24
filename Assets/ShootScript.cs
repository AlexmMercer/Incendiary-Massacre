using System.Collections;
using UnityEngine;

public class ShootScript : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] GameObject shootPos;
    [SerializeField] ParticleSystem shootEffect;
    [SerializeField] private float shotForce = 50.0f;
    [SerializeField] private float shootInterval = 1.0f;

    private float lastShootTime;

    private void Start()
    {
        lastShootTime = 0.0f;
    }

    private void Update()
    {
        if (shootInterval <= lastShootTime)
        {
            moveBullet();
            lastShootTime = 0.0f;
        }
        lastShootTime += Time.deltaTime;
    }

    void moveBullet()
    {
        shootEffect.Play();
        GameObject bullet = Instantiate(bulletPrefab, shootPos.transform.position, bulletPrefab.transform.rotation);
        bullet.transform.SetParent(null);
        bullet.GetComponent<Rigidbody>().AddRelativeForce(Vector3.up * shotForce);
    }
}