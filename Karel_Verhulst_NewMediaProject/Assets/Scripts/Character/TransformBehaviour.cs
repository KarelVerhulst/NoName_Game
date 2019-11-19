using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TransformBehaviour : MonoBehaviour
{
    [SerializeField]
    private Image _transformImage = null;
    [SerializeField]
    private float _transformRegenAmount = 30f;

    private const int TRANSFORM_MAX = 100;
    

    public bool IsTransformAvailable  { get; set; }
    public float TransformAmount { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        TransformAmount = 0;
        IsTransformAvailable = false;
    }

    private void Update()
    {
        FillManaAmount();
    }

    public void FillManaAmount()
    {
        if (GetManaNormalized() < 1)
        {
            IsTransformAvailable = false;
            TransformAmount += _transformRegenAmount * Time.deltaTime;
            TransformAmount = Mathf.Clamp(TransformAmount, 0f, TRANSFORM_MAX);

            _transformImage.fillAmount = GetManaNormalized();
        }else 
        {
            IsTransformAvailable = true;
        }
    }

    private float GetManaNormalized()
    {
        return TransformAmount / TRANSFORM_MAX;
    }
}
