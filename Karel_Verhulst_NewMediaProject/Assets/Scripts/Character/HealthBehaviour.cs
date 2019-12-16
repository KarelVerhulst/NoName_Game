using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBehaviour : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _arrayOfHealth = null;
    
    [SerializeField]
    private float _waitTimer = 3f;

    public int Health { get; set; }
    public Transform RespawnPoint { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        Health = _arrayOfHealth.Length;

        StartCoroutine(Test());
    }

    IEnumerator Test()
    {
        while (true)
        {
            if (Health <= 0)
            {
                foreach (GameObject item in _arrayOfHealth)
                {
                    item.GetComponent<Image>().color = Color.gray;
                }

                yield return new WaitForSeconds(_waitTimer);

                ResetHealthAndPosition();
               
            }

            yield return null;
        }
    }

    private void ResetHealthAndPosition()
    {
        foreach (GameObject item in _arrayOfHealth)
        {
            item.GetComponent<Image>().color = Color.green;
        }

        Health = _arrayOfHealth.Length;

        this.GetComponentInChildren<BaseCharacterBehaviour>().transform.position = RespawnPoint.position;
        
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
