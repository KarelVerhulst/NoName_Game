using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    private MovementController _mc;

    public IdleState(ICharacter character) : base(character)
    {
    }

    public override void Tick()
    {
        _mc.UpdateMovement(Vector3.zero, false); //idle

        if (InputController.GetLeftJoystick() != Vector3.zero)
        {
            _character.SetState(new WalkState(_character));
        }

        if (InputController.IsButtonBPressed())
        {
            _character.SetState(new JumpState(_character));
        }
    }

    public override void OnStateEnter()
    {
        base.OnStateEnter();
        //Debug.Log("OnstateEnter Idle");
        _mc = new MovementController(_character);
    }
}
