using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkState : State
{
    private Vector3 _moveDirection = Vector3.zero;
    private float _vertical = 0.0f;
    private float _horizontal = 0.0f;
    private float _inputAmount;

    private MovementController _mc;

    public WalkState(ICharacter character) : base(character)
    {
    }
    
    public override void Tick()
    {
        if (InputController.GetLeftJoystick() != Vector3.zero)
        {
            // MoveBehaviour();
            _mc.UpdateMovement(InputController.GetLeftJoystick(), false);
        }
        else
        {
            _character.SetState(new IdleState(_character));
        }

        if (InputController.IsButtonYPressed())
        {
            _character.SetState(new JumpState(_character));
        }

        if (InputController.IsButtonAPressed())
        {
            _character.SetState(new MeleeAttackState(_character));
        }

        if (InputController.GetRightTrigger() != 0)
        {
            _character.SetState(new MagicAttackState(_character));
        }
    }

    public override void OnStateEnter()
    {
        //base.OnStateEnter();
        //Debug.Log("OnstateEnter Walk");
        _mc = new MovementController(_character);
    }

    private void MoveBehaviour()
    {
        if (_character.CC.isGrounded)
        {
            // reset movement
            _moveDirection = Vector3.zero;

            _vertical = InputController.GetLeftJoystick().z;
            _horizontal = InputController.GetLeftJoystick().x;
            
            Vector3 correctedVertical = _vertical * _character.CameraTransform.forward;
            Vector3 correctedHorizontal = _horizontal * _character.CameraTransform.right;

            Vector3 combinedInput = correctedHorizontal + correctedVertical;

            _moveDirection = new Vector3((combinedInput).normalized.x, 0, (combinedInput).normalized.z);

            // make sure the input doesnt go negative or above 1;
            float inputMagnitude = Mathf.Abs(_horizontal) + Mathf.Abs(_vertical);
            _inputAmount = Mathf.Clamp01(inputMagnitude);

            //fix for message: Look rotation viewing vector is zero
            if (_moveDirection != Vector3.zero)
            {
                Quaternion rot = Quaternion.LookRotation(_moveDirection);
                Quaternion targetRotation = Quaternion.Slerp(_character.transform.rotation, rot, Time.fixedDeltaTime * _inputAmount * _character.RotateSpeed);
                _character.transform.rotation = targetRotation;
            }
            
            Jump();
        }

        _moveDirection.y -= _character.Gravity * Time.deltaTime;
        _character.CC.Move(_moveDirection * Time.deltaTime * _character.MoveSpeed);
    }

    private void Jump()
    {
        if (InputController.IsButtonYPressed())
        {
            _character.SetState(new JumpState(_character));
        }
    }
}
