﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTrap : MonoBehaviour
{
    [SerializeField]
    private Material _disolveMaterial = null;
    [SerializeField]
    private float _waitTimer = 1;
    [SerializeField]
    private float _speed = 1;
    [SerializeField]
    private float _time = 1;
    [SerializeField]
    private bool _repeat = true;

    private BoxCollider _boxCollider = null;
    private bool _isActionDissolve = true;
    private float _disolveTimer = 0;
    private float _rate = 0;

    // Start is called before the first frame update
    void Start()
    {
        _disolveMaterial.SetFloat("_Amount", 0);
        _rate = (1.0f / _time) * _speed;
        _boxCollider = this.GetComponent<BoxCollider>();
        StartCoroutine(Action());
    }

    private IEnumerator Action()
    {
        while (_repeat)
        {
            if (_isActionDissolve)
            {
                yield return new WaitForSeconds(_waitTimer);

                yield return Dissolve();

            }
            else
            {
                yield return new WaitForSeconds(_waitTimer);

                yield return Resolve();
            }

            yield return null;
        }
    }

    private IEnumerator Dissolve()
    {
        float time = 0.0f;
        
        while (time < 1.0f)
        {
            time += Time.deltaTime * _rate;

            ChangeMaterialt(time);

            if (time >= 0.5)
            {
                _boxCollider.isTrigger = true;
            }

            if (time >= 1)
            {
                _isActionDissolve = false;
            }

            yield return null;
        }
    }

    private IEnumerator Resolve()
    {
        float time = 1.0f;
        
        while (time > 0.0f)
        {
            time -= Time.deltaTime * _rate;

            ChangeMaterialt(time);

            if (time <= 0.5)
            {
                _boxCollider.isTrigger = false;
            }

            if (time <= 0)
            {
                _isActionDissolve = true;
            }

            yield return null;
        }
    }

    private void ChangeMaterialt(float time)
    {
        _disolveMaterial.SetFloat("_Amount", time);
    }
}
