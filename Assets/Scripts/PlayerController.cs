using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 50.0f;
    //[SerializeField] private GameObject leftBound;
    //[SerializeField] private GameObject rightBound;
    private float horizontalInput;
    private float verticalInput;

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * horizontalInput * moveSpeed * Time.deltaTime);
        if (transform.position.z > 44.5f && transform.position.z < 98.6f)
        {
            transform.Translate(Vector3.left * verticalInput * moveSpeed * Time.deltaTime);
        } else
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 75.0f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent<FirstProtester>(out var firstProtester))
        {
            Destroy(gameObject);
        }
    }
}
