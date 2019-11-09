using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpState : State
{
    private Vector3 _moveDirection = Vector3.zero;

    private MovementController _mc;
    private AnimationController _ac;

    public JumpState(ICharacter character) : base(character)
    {
      
    }

    public override void Tick()
    {
        
        if (_character.CC.isGrounded)
        {
            _mc.UpdateMovement(InputController.GetLeftJoystick(),true);
            _ac.JumpAnimation(true, _character.GetJumpDistanceToGround());
            Debug.Log(_character.name + " | " + _character.GetJumpDistanceToGround());
        }
        else
        {
            _mc.UpdateMovement(InputController.GetLeftJoystick(), false);

            if (_character.CC.isGrounded)
            {
                if (InputController.GetLeftJoystick() != Vector3.zero)
                {
                    _character.SetState(new WalkState(_character));
                }
                else
                {
                    _character.SetState(new IdleState(_character));
                }
                _ac.JumpAnimation(false, _character.GetJumpDistanceToGround());
            }
        }
    }


    public override void OnStateEnter()
    {
        //base.OnStateEnter();
        //Debug.Log("OnstateEnter Jump");
        _mc = new MovementController(_character);
        _ac = new AnimationController(_character.Animator);
    }
    
}
