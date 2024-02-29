using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

public class FirstProtester : MonoBehaviour
{
    [SerializeField] private int lifeVal = 2;
    [SerializeField] private float speedVal = 13.0f;
    [SerializeField] GameManager Manager;
    [SerializeField] GameObject BloodEffect;
    //[SerializeField] TextMeshProUGUI DeadTerroristsText;

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.TryGetComponent<Bullet>(out var bullet))
        {
            var bloodEffect = Instantiate(BloodEffect, collision.gameObject.transform.position, BloodEffect.transform.rotation);
            bloodEffect.GetComponent<ParticleSystem>().Play();
            Destroy(collision.gameObject);
            GetComponent<AudioSource>().Play();
            lifeVal--;
        }
    }

    private void Update()
    {
        if(lifeVal == 0)
        {
            //Manager.DeadTerrorists++;
            //DeadTerroristsText.text = $"Loses: {Manager.DeadTerrorists}";
            Destroy(gameObject);
        }
        else
        {
            transform.Translate(Vector3.right * (-speedVal) * Time.deltaTime);
        }
    }
}
