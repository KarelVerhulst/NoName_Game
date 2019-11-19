using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    private MovementController _mc;
    private AnimationController _ac;

    public IdleState(ICharacter character) : base(character)
    {
    }

    public override void Tick()
    {
        if (_character.GetComponentInParent<HealthBehaviour>().Health <= 0)
        { 
            _ac.DeadAnimation(true);

            return;
        }

        _mc.UpdateMovement(Vector3.zero, false); //idle

        if (InputController.GetLeftJoystick() != Vector3.zero)
        {
            _character.SetState(new WalkState(_character));
        }

        if (InputController.IsButtonYPressed())
        {
            _character.SetState(new JumpState(_character));
        }

        if (InputController.IsButtonAPressed())
        {
            _character.SetState(new MeleeAttackState(_character));
        }
    }

    public override void OnStateEnter()
    {
        base.OnStateEnter();
        //Debug.Log("OnstateEnter Idle");
        _mc = new MovementController(_character);
        _ac = new AnimationController(_character.Animator);
    }
}
