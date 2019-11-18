using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBehaviour : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _arrayOfHealth = null;

    public int Health { get; set; }
    // Start is called before the first frame update
    void Start()
    {
        Health = _arrayOfHealth.Length;
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
