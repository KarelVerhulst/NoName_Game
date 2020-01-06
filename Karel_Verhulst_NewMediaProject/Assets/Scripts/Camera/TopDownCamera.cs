using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownCamera : BaseCamera
{
    /*
     * specific script for a topDowncamera and it behaviour
     */

    [SerializeField]
    private float _smoothSpeed = 0.5f;
    [SerializeField]
    private float _zoomSpeed = 1f;
    [SerializeField]
    private Vector2 _minMaxHeightClamp = Vector2.zero;
    [SerializeField]
    private Vector2 _minMaxDistanceClamp = Vector2.zero;
    
    protected override void HandleCamera()
    {
        base.HandleCamera();

        // possible to zoom in and out using the right joystick
        ZoomBehaviour();

        Vector3 worldposition = (Vector3.forward * -_distance) + (Vector3.up * _height);

        Vector3 flatTargetPosition = _target.position;

        flatTargetPosition.y = 0f;

        Vector3 desiredPosition = _target.position + worldposition;

        this.transform.position = Vector3.Slerp(transform.position, desiredPosition, Time.deltaTime * _smoothSpeed);
        //this.transform.LookAt(_target);
    }

    private void ZoomBehaviour()
    {
        float vMovement = Mathf.RoundToInt(InputController.GetRightJoystick().z);

        _distance += vMovement  * _zoomSpeed * Time.deltaTime;
        _height += vMovement * _zoomSpeed * Time.deltaTime;
      
        _distance = Mathf.Clamp(_distance, _minMaxDistanceClamp.x, _minMaxDistanceClamp.y);
        _height = Mathf.Clamp(_height, _minMaxHeightClamp.x, _minMaxHeightClamp.y);
        
    }
}
