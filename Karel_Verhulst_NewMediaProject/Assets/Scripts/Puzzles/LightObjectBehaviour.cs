using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightObjectBehaviour : MonoBehaviour
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

    [SerializeField]
    private GameObject _light = null;
    

    public GameObject Light
    {
        get { return _light; }
        set { _light = value; }
    }


    private float _timer;

    private bool _isPuzzleFixed = false;

    private void OnTriggerEnter(Collider other)
    {
        _timer = _maxTimer;
    }

    private void OnTriggerStay(Collider other)
    {
        _isPuzzleFixed = this.GetComponentInParent<LightItInTheRightOrderBehaviour>().IsPuzzleFinished;

        if (other.tag == "Player" && !_isPuzzleFixed)
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
