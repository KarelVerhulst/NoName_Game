using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnBehaviour : MonoBehaviour
{
    /*
     * if the character died you can choose where he is going to respawn
     */

    [SerializeField]
    private Transform _respawnPostion = null;

    [SerializeField]
    private bool _useTrigger = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out BaseCharacterBehaviour character))
        {
            if (_useTrigger)
            {
                //if you use the trigger the characters health is zero -> dead animation is playing
               
                 other.GetComponentInParent<HealthBehaviour>().Health = 0;
                other.GetComponentInParent<HealthBehaviour>().RespawnPoint = _respawnPostion;
            }
            else
            {
                other.GetComponentInParent<HealthBehaviour>().RespawnPoint = _respawnPostion;
            }
        }
    }
}
