using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelPlusOne : MonoBehaviour
{
    [SerializeField] private GameObject playerToInstantiate;
    [SerializeField] private float lifeTime = 35.0f;
    [SerializeField] private float barrelSpeed = 7.0f;
    [SerializeField] private int pointsLife = 3;
    [SerializeField] private GameObject[] lifeDigits;
    [SerializeField] GameObject SparksEffect;
    [SerializeField] GameObject ExplosionEffect;
    private int lifeIndex = 2;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent<Bullet>(out var bullet))
        {
            var sparksEffect = Instantiate(SparksEffect, other.gameObject.transform.position, SparksEffect.transform.rotation);
            sparksEffect.GetComponent<ParticleSystem>().Play();
            pointsLife--;
        }
    }
    private void Update()
    {
        if (pointsLife == 0)
        {
            var explosionEffect = Instantiate(ExplosionEffect, transform.position, ExplosionEffect.transform.rotation);
            explosionEffect.GetComponent<ParticleSystem>().Play();
            Destroy(gameObject);
            GameObject[] soldiers = GameObject.FindGameObjectsWithTag("Player");
            if(soldiers.Length <= 2)
            {
                Instantiate(playerToInstantiate, new Vector3(soldiers[soldiers.Length - 1].transform.position.x - 15.0f, playerToInstantiate.transform.position.y, playerToInstantiate.transform.position.z), playerToInstantiate.transform.rotation);
            }
        }
        transform.Translate(Vector3.right * (-barrelSpeed) * Time.deltaTime);
    }
}
