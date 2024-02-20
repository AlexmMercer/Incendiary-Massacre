using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 50.0f;
    //[SerializeField] private GameObject leftBound;
    //[SerializeField] private GameObject rightBound;
    private float horizontalInput;

    // Update is called once per frame
    void Update()
    {
            horizontalInput = Input.GetAxis("Horizontal");
            transform.Translate(Vector3.forward * horizontalInput * moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent<FirstProtester>(out var firstProtester))
        {
            Destroy(gameObject);
        }
    }
}
