using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenWallBehaviour : MonoBehaviour
{
    [SerializeField]
    private BoxCollider _wallCollider = null;
    [SerializeField]
    private float _colorSpeed = 5;
   
    private Material _wallMaterial = null;
    private Color _currentColor;
    private Color _newColor;

    private void Start()
    {
        _wallMaterial = this.GetComponentInParent<Renderer>().material;
        _currentColor = _wallMaterial.color;
        
    }

    private void OnTriggerEnter(Collider other)
    {
        _newColor = _wallMaterial.color;

        if (_newColor.r <= 0.7f && _newColor.r >= 0)
        {
            _newColor.r += 0.3f;
        }
        else if (_newColor.r >= 1f)
        {
            _newColor.r -= 0.4f;
        } 

        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<WolfBehaviour>())
        {
           // Debug.Log("Wolf is in the hidden area");
            _wallCollider.isTrigger = true;
           
            _wallMaterial.color = Color.Lerp(_wallMaterial.color, _newColor, _colorSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        _wallCollider.isTrigger = false;
        _wallMaterial.color = _currentColor;
    }
}
