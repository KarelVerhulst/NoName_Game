using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpState : State
{
    private Vector3 _moveDirection = Vector3.zero;

    private MovementController _mc;

    public JumpState(ICharacter character) : base(character)
    {
      
    }

    public override void Tick()
    {
        
        if (_character.CC.isGrounded)
        {
            _mc.UpdateMovement(InputController.GetLeftJoystick(),true);
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
                
            }
        }
    }


    public override void OnStateEnter()
    {
        //base.OnStateEnter();
        //Debug.Log("OnstateEnter Jump");
        _mc = new MovementController(_character);
    }
}
