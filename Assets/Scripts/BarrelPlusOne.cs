using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelPlusOne : MonoBehaviour
{
    [SerializeField] private GameObject playerToInstantiate;
    [SerializeField] private float lifeTime = 35.0f;
    [SerializeField] private int pointsLife = 3;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent<Bullet>(out var bullet))
        {
            pointsLife--;
        }
    }
    private void Update()
    {
        if (pointsLife == 0)
        {
            Destroy(gameObject);
            GameObject[] soldiers = GameObject.FindGameObjectsWithTag("Player");
            if(soldiers.Length <= 5)
            {
                Instantiate(playerToInstantiate, new Vector3(soldiers[soldiers.Length - 1].transform.position.x - 15.0f, playerToInstantiate.transform.position.y, playerToInstantiate.transform.position.z), playerToInstantiate.transform.rotation);
            }
        }
        transform.Translate(Vector3.right * (-35.0f) * Time.deltaTime);
    }
}
