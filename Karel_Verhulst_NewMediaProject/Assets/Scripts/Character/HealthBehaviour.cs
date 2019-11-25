using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBehaviour : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _arrayOfHealth = null;

    [SerializeField]
    private Transform _respawnPostion = null;

    private float _waitTimer = 3f;

    public int Health { get; set; }
    // Start is called before the first frame update
    void Start()
    {
        Health = _arrayOfHealth.Length;
    }

    private void Update()
    {
        if (Health <= 0)
        {
            _waitTimer -= Time.deltaTime;

            foreach (GameObject item in _arrayOfHealth)
            {
                item.GetComponent<Image>().color = Color.gray;
            }

            if (_waitTimer <= 0)
            {
                foreach (GameObject item in _arrayOfHealth)
                {
                    item.GetComponent<Image>().color = Color.green;
                }
                Health = _arrayOfHealth.Length;

                this.GetComponentInChildren<BaseCharacterBehaviour>().transform.position = _respawnPostion.position;

                _waitTimer = 3f;
            }
            
        }
    }

    public void ChangeHealth(int healthIndex)
    {
        _arrayOfHealth[healthIndex].GetComponent<Image>().color = Color.gray;
    }

    public void CharacterTakeDamage(int damage)
    {
        Health -= damage;
    }
}
