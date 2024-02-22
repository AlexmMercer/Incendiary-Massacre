using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstProtester : MonoBehaviour
{
    [SerializeField] private int lifeVal = 2;
    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.TryGetComponent<Bullet>(out var bullet))
        {
            Destroy(collision.gameObject);
            lifeVal--;
        }
    }

    private void Update()
    {
        if(lifeVal == 0)
        {
            Destroy(gameObject);
        }
        else
        {
            transform.Translate(Vector3.right * (-18.0f) * Time.deltaTime);
        }
    }
}
