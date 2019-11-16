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

    private float _timer;

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

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
