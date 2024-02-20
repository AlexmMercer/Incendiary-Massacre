using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelPlusTwo : MonoBehaviour
{
    [SerializeField] private GameObject playerToInstantiate;
    [SerializeField] private float lifeTime = 35.0f;
    [SerializeField] private int pointsLife = 4;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<Bullet>(out var bullet))
        {
            pointsLife--;
        }
    }
    private void Update()
    {
        if (pointsLife == 0)
        {
            Destroy(gameObject);
            Instantiate(playerToInstantiate, new Vector3(playerToInstantiate.transform.position.x - 30.0f, playerToInstantiate.transform.position.y, playerToInstantiate.transform.position.z), playerToInstantiate.transform.rotation);
            Instantiate(playerToInstantiate, new Vector3(playerToInstantiate.transform.position.x - 60.0f, playerToInstantiate.transform.position.y, playerToInstantiate.transform.position.z), playerToInstantiate.transform.rotation);
        }
        transform.Translate(Vector3.right * (-35.0f) * Time.deltaTime);
    }
}
