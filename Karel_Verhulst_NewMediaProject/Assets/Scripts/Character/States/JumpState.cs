using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpState : State
{
    private Vector3 _moveDirection = Vector3.zero;

    private MovementController _mc;
    private AnimationController _ac;
    private bool _jump;

    public JumpState(ICharacter character) : base(character)
    {
      
    }

    public override void Tick()
    {
        
        if (_character.CC.isGrounded)
        {
            _mc.UpdateMovement(InputController.GetLeftJoystick(),true);
            _jump = true;
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
                _jump = false;
            }
        }

        _ac.JumpAnimation(_jump, _character.GetJumpDistanceToGround());
    }


    public override void OnStateEnter()
    {
        //base.OnStateEnter();
        //Debug.Log("OnstateEnter Jump");
        _mc = new MovementController(_character);
        _ac = new AnimationController(_character.Animator);
    }
    
}
