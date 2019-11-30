using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TransformBehaviour : MonoBehaviour
{
    [SerializeField]
    private Image _transformImage = null;
    [SerializeField]
    private float _transformRegenAmount = 10f;
    [SerializeField]
    private float _transformSpendAmount = 20f;

    private const int TRANSFORM_MAX = 100;

    private bool _canISpend = true;
    private float _transformAmount = 0;

    public bool IsTransformAvailable  { get; set; }
    public bool StartTransformCounter { get; set; }
    

    // Start is called before the first frame update
    void Start()
    {
        _transformAmount = TRANSFORM_MAX;
        IsTransformAvailable = true;
        StartTransformCounter = false;
    }

    private void Update()
    {
        if (_canISpend & StartTransformCounter)
        {
            SpendTransformAmount();
        }
        else
        {
            FillTransformAmount();
        }

        _transformImage.fillAmount = GetTransformNormalized();
    }

    private void FillTransformAmount()
    {
        if (GetTransformNormalized() < 1)
        {
            _canISpend = false;
            IsTransformAvailable = false;
            _transformAmount += _transformRegenAmount * Time.deltaTime;
            _transformAmount = Mathf.Clamp(_transformAmount, 0f, TRANSFORM_MAX);
            
        }else 
        {
            StartTransformCounter = false;
            IsTransformAvailable = true;
            _canISpend = true;
        }
    }
    
    private void SpendTransformAmount()
    {
        if (GetTransformNormalized() > 0)
        {
            _canISpend = true;
            IsTransformAvailable = true;

            _transformAmount -= _transformSpendAmount * Time.deltaTime;
            _transformAmount = Mathf.Clamp(0f, _transformAmount, TRANSFORM_MAX);
        }
        else
        {
            IsTransformAvailable = false;
            _canISpend = false;
        }
    }

    private float GetTransformNormalized()
    {
        return _transformAmount / TRANSFORM_MAX;
    }
}
