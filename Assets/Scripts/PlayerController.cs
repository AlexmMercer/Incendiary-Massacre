using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 50.0f;
    [SerializeField] private GameObject leftBound;
    [SerializeField] private GameObject rightBound;
    private float horizontalInput;

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x >= leftBound.transform.position.x)
        {
            transform.position = leftBound.transform.position - new Vector3(5, 0, 0);
        } else if(transform.position.x <= rightBound.transform.position.x)
        {
            transform.position = rightBound.transform.position + new Vector3(5, 0, 0);
        } else
        {
            horizontalInput = Input.GetAxis("Horizontal");
            transform.Translate(Vector3.forward * horizontalInput * moveSpeed * Time.deltaTime);
        }
    }
}
