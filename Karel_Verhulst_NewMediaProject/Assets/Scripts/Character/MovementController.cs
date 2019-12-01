using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController
{
    private Vector3 _moveDirection = Vector3.zero;
    private float _vertical = 0.0f;
    private float _horizontal = 0.0f;
    private float _inputAmount = 0.0f;

    private BaseCharacterBehaviour _character;
    
    private float _runTimer = 3;
    private float _acceleratorTimer = 0;

    public MovementController(BaseCharacterBehaviour character)
    {
        _character = character;
        _character.CurrentSpeed = _character.MoveSpeed.x; 
    }

    public void UpdateMovement(Vector3 movement, bool jump)
    {
        if (_character.CC.isGrounded)
        {
            IncreaseSpeedAfterTime();
            
            ApplyMovement(movement);
            RotateCharacterToDirection();
            Jump(jump);
        }

        ApplyGround();

        DoMovement();
    }

    private void Jump(bool jump)
    {
        if (jump)
        {
            _moveDirection.y = _character.JumpSpeed;
        }
    }

    private void IncreaseSpeedAfterTime()
    {
        _runTimer -= Time.deltaTime;

        if (_runTimer <= 0)
        {
            _character.CurrentSpeed = Mathf.SmoothStep(_character.MoveSpeed.x, _character.MoveSpeed.y, _acceleratorTimer / _character.Accelerator);
            _acceleratorTimer += Time.deltaTime;
        }
        else
        {
            _character.CurrentSpeed = _character.MoveSpeed.x;
        }
    }

    private void ApplyMovement(Vector3 movement)
    {
        // reset movement
        _moveDirection = Vector3.zero;

        //_vertical = InputController.GetLeftJoystick().z;
        //_horizontal = InputController.GetLeftJoystick().x;

        _vertical = movement.z;
        _horizontal = movement.x;

        Vector3 correctedVertical = _vertical * _character.CameraTransform.forward;
        Vector3 correctedHorizontal = _horizontal * _character.CameraTransform.right;

        Vector3 combinedInput = correctedHorizontal + correctedVertical;

        _moveDirection = new Vector3((combinedInput).normalized.x, 0, (combinedInput).normalized.z);

        // make sure the input doesnt go negative or above 1;
        float inputMagnitude = Mathf.Abs(_horizontal) + Mathf.Abs(_vertical);
        _inputAmount = Mathf.Clamp01(inputMagnitude);
    }

    private void RotateCharacterToDirection()
    {
        //fix for message: Look rotation viewing vector is zero
        if (_moveDirection != Vector3.zero)
        {
            Quaternion rot = Quaternion.LookRotation(_moveDirection);
            Quaternion targetRotation = Quaternion.Slerp(_character.transform.rotation, rot, Time.fixedDeltaTime * _inputAmount * _character.RotateSpeed);
            _character.transform.rotation = targetRotation;
        }
    }

    private void ApplyGround()
    {
        _moveDirection.y -= _character.Gravity * Time.deltaTime;
    }

    private void DoMovement()
    {
        _character.CC.Move(_moveDirection * Time.deltaTime * _character.CurrentSpeed);
    }
}
