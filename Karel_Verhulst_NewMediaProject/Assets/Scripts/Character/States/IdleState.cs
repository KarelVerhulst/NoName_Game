using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    /*
     * when the character is in the idle state he can walk and jump
     */

    private MovementController _mc;
    private AnimationController _ac;

    public IdleState(ICharacter character) : base(character)
    {
    }

    public override void Tick()
    {
        Death();

        StateInputController.MoveState(_character);
        StateInputController.JumpState(_character);
    }

    public override void OnStateEnter()
    {
        base.OnStateEnter();
        //Debug.Log("OnstateEnter Idle");
        _mc = new MovementController(_character);
        _ac = new AnimationController(_character.Animator);
    }

    private void Death()
    {
        if (_character.GetComponentInParent<HealthBehaviour>().Health <= 0)
        {
            _ac.DeadAnimation(true);

            return;
        }
        else
        {
            _ac.MoveAnimation(false);
            _ac.DeadAnimation(false);

            _mc.UpdateMovement(false);
        }
    }
}
