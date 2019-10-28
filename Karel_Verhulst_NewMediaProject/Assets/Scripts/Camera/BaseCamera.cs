using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCamera : MonoBehaviour
{
    public Transform _target;
    public float _height = 10f;
    public float _distance = 20f;
    
    void Start()
    {
        
    }

    void  Update()
    {
        HandleCamera();
    }

    protected virtual void HandleCamera()
    {
        _target = GameObject.FindGameObjectWithTag("Player").transform;

        if (!_target)
        {
            return;
        }
    }
   
}
