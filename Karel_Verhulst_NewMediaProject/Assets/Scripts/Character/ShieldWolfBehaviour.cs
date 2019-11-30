using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldWolfBehaviour : MonoBehaviour
{
    [SerializeField]
    private Transform _shootPosition = null;
    [SerializeField]
    private GameObject _projectile = null;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "EnemyBullet")
        {
            GameObject bullet = Instantiate(_projectile, _shootPosition.position, Quaternion.identity) as GameObject;
            bullet.GetComponent<WolfBullet>().ShootPostion = _shootPosition.forward;

           
            /*
                https://unity3d.college/2017/07/03/using-vector3-reflect-to-cheat-ball-bouncing-physics-in-unity/
            */
        }
    }

}
