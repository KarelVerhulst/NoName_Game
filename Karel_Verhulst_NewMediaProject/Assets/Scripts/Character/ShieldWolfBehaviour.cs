using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldWolfBehaviour : MonoBehaviour
{
    /*
     * deflect a bullet on the wolfshield
     */
    [SerializeField]
    private Transform _shootPosition = null;
    [SerializeField]
    private GameObject _projectile = null;

    private void OnTriggerEnter(Collider other)
    {
        //change this with layermask
        if (other.tag == "EnemyBullet")
        {
            //shoot
            GameObject bullet = Instantiate(_projectile, _shootPosition.position, this.transform.rotation) as GameObject;
            bullet.GetComponent<WolfBullet>().ShootPostion = _shootPosition.forward;
        }
    }

}
