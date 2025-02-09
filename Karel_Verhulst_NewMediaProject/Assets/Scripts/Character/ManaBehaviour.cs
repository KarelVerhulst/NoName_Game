﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaBehaviour : MonoBehaviour
{
    /*
     * everything about the mana (that is used to attack with magic)
     */
    [SerializeField]
    private List<Image> _listOfManas = new List<Image>();
    [SerializeField]
    private float _manaReduceSpeed = 5;

    private const int MANA_MAX = 100;
    private float _manaAmount = 0;
    private float _manaRegenAmount = 30f;

    public bool IsManaEmpty { get; set; }

    int index = 0;
    
    void Start()
    {
        _manaAmount = MANA_MAX;
        IsManaEmpty = false;
    }
    
    public void TrySpendMana(float amount)
    {
        if (index == _listOfManas.Count)
        {
            IsManaEmpty = true;
            return;
        }

        if (_manaAmount <= 1.5f && index <= _listOfManas.Count)
        {
            index++;
            _manaAmount = MANA_MAX;
        }

        
        if (_manaAmount >= amount && !IsManaEmpty && index < _listOfManas.Count)
        {
            _manaAmount -= amount * (_manaReduceSpeed * Time.deltaTime);
            _listOfManas[index].fillAmount = GetManaNormalized();
        }
    }

    public void FillManaAmount()
    {
        
        _manaAmount += _manaRegenAmount * Time.deltaTime;
        _manaAmount = Mathf.Clamp(_manaAmount, 0f, MANA_MAX);
        
        if (_manaAmount >= 100 && index > 0)
        {
            index--;
            _manaAmount = 0;
        }

        _listOfManas[index].fillAmount = GetManaNormalized();
    }

    private float GetManaNormalized()
    {
        return _manaAmount / MANA_MAX;
    }
}
