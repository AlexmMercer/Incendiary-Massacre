using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FirstProtester : MonoBehaviour
{
    [SerializeField] private int lifeVal = 2;
    [SerializeField] private float speedVal = 13.0f;
    [SerializeField] GameManager Manager;
    [SerializeField] TextMeshProUGUI DeadTerroristsText;
    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.TryGetComponent<Bullet>(out var bullet))
        {
            Destroy(collision.gameObject);
            GetComponent<AudioSource>().Play();
            lifeVal--;
        }
    }

    private void Update()
    {
        if(lifeVal == 0)
        {
            Manager.DeadTerrorists++;
            DeadTerroristsText.text = $"Loses: {Manager.DeadTerrorists}";
            Destroy(gameObject);
        }
        else
        {
            transform.Translate(Vector3.right * (-speedVal) * Time.deltaTime);
        }
    }
}
