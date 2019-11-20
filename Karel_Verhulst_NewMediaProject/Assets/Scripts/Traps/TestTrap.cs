using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTrap : MonoBehaviour
{
    [SerializeField]
    private Transform _shootObject = null;
    [SerializeField]
    private Transform projectilePosition = null;
    [SerializeField]
    private GameObject projectile = null;
    [SerializeField]
    private float _maxTimer = 1;

    [SerializeField]
    private GameObject _shield = null;
    [SerializeField]
    private bool _useShieldOnTrap = false;

    private float _timer;
    
    private void OnTriggerEnter(Collider other)
    {
        _timer = _maxTimer;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            _shootObject.LookAt(other.transform);
            _shootObject.eulerAngles = new Vector3(0, _shootObject.transform.eulerAngles.y, 0);

            ShootObject();

            if (_useShieldOnTrap)
            {
                if (other.GetComponent<DragonBehaviour>())
                {
                    _shield.SetActive(true);
                }
                else
                {
                    _shield.SetActive(false);
                }
            }
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            if (_useShieldOnTrap)
            {
                _shield.SetActive(false);
            }
        }
    }

    private void ShootObject()
    {
        _timer -= Time.deltaTime;
        
        if (_timer <= 0)
        {
            GameObject bullet = Instantiate(projectile, projectilePosition.position, Quaternion.identity) as GameObject;
            bullet.GetComponent<BulletBehaviour>().ShootPostion = projectilePosition.forward;
                
            _timer = _maxTimer;
        }
        
    }
}
