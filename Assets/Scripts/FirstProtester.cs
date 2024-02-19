using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstProtester : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.TryGetComponent<Bullet>(out var bullet))
        {
            Debug.Log("?? ??????????? ???????!");
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }

    private void Update()
    {
        transform.Translate(Vector3.right * (-15.0f) * Time.deltaTime);
    }
}
