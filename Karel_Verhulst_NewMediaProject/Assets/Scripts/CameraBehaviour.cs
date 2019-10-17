using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    //[SerializeField]
    private Transform _target = null;
    [SerializeField]
    [Range(0.01f, 1.0f)]
    private float _smoothSpeed = 0.5f;
    [SerializeField]
    private Vector3 _positionOffset = Vector3.zero;
    [SerializeField]
    private Vector3 _rotationOffset = Vector3.zero;

    [SerializeField]
    private float _yZoomMultiplier = 0;
    [SerializeField]
    private float _zZoomMultiplier = 0;
    [SerializeField]
    private float _zoomSpeed = 10f;
    [SerializeField]
    private Vector2 _minMaxYClamp = Vector2.zero;
    [SerializeField]
    private Vector2 _minMaxZClamp = Vector2.zero;

    Vector3 clampVector = Vector3.zero;
    
    void Update()
    {
        _target = GameObject.FindGameObjectWithTag("Player").transform;
        Vector3 desiredPosition = _target.position + _positionOffset;

        ZoomBehaviour();

        Vector3 smoothedPosition = Vector3.Slerp(transform.position, desiredPosition, _smoothSpeed);
        this.transform.position = smoothedPosition;

        this.transform.rotation = Quaternion.Euler(_rotationOffset);
    }
   
    private void ZoomBehaviour()
    {
        float vMovement = InputController.GetRightJoystick().z;

        float clampY = vMovement * _yZoomMultiplier;
        float clampZ = vMovement * _zZoomMultiplier;

        clampVector.y += clampY * _zoomSpeed * Time.deltaTime;
        clampVector.z += -clampZ * _zoomSpeed * Time.deltaTime;

        clampVector.y = Mathf.Clamp(clampVector.y, _minMaxYClamp.x, _minMaxYClamp.y);
        clampVector.z = Mathf.Clamp(clampVector.z, _minMaxZClamp.x, _minMaxZClamp.y);
   
        //clampVector.y = Mathf.Clamp(clampVector.y, 2.2f, 7f);
        //clampVector.z = Mathf.Clamp(clampVector.z, -16.7f, -6.5f);


        //_positionOffset += new Vector3(0, clampY, -clampZ) * _zoomSpeed * Time.deltaTime;
        _positionOffset = clampVector;
    }
}
