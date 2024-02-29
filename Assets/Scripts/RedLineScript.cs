using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedLineScript : MonoBehaviour
{
    [SerializeField] private int protestersAchievedNum = 0;
    public int ProtestersAchievedNum { get { return protestersAchievedNum; } }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent<FirstProtester>(out var firstProtester))
        {
            protestersAchievedNum++;
        }
    }
}
