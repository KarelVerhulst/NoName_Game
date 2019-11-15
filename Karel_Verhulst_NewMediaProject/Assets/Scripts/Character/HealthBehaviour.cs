using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

static class Extension
{
    public static bool IsEqualTo(this Color me, Color other)
    {
        return me.r == other.r && me.g == other.g && me.b == other.b && me.a == other.a;
    }
}

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

    // Update is called once per frame
    void Update()
    {
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
