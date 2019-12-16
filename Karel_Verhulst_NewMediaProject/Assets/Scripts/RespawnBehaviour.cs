using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnBehaviour : MonoBehaviour
{
    [SerializeField]
    private Transform _respawnPostion = null;

    [SerializeField]
    private bool _useTrigger = false;

    private void OnTriggerEnter(Collider other)
    {
        if (_useTrigger)
        {
            if (other.TryGetComponent(out BaseCharacterBehaviour character))
            {
                other.GetComponentInParent<HealthBehaviour>().Health = 0;
                other.GetComponentInParent<HealthBehaviour>().RespawnPoint = _respawnPostion;
            }
        }
        else
        {
            if (other.TryGetComponent(out BaseCharacterBehaviour character))
            {
                other.GetComponentInParent<HealthBehaviour>().RespawnPoint = _respawnPostion;
            }
        }
        
    }
}
