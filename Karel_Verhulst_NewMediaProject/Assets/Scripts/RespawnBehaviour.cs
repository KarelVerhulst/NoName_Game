using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnBehaviour : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<BaseCharacterBehaviour>())
        {
            other.GetComponentInParent<HealthBehaviour>().Health = 0;
        }
    }
}
