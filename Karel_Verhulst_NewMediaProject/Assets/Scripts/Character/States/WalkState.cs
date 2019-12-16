using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkState : State
{
    private Vector3 _moveDirection = Vector3.zero;

    private MovementController _mc;
    private AnimationController _ac;

    public WalkState(ICharacter character) : base(character)
    {
    }
    
    public override void Tick()
    {

        if (_character.GetComponentInParent<HealthBehaviour>().Health <= 0)
        {
            _ac.DeadAnimation(true);

            return;
        }
        else
        {
            _ac.DeadAnimation(false);
        }

        if (_ac.CheckIfAnimationIsPlaying(0, "Dead"))
            return;

        if (InputController.GetLeftJoystick() != Vector3.zero)
        {
            // MoveBehaviour();
            _mc.UpdateMovement(InputController.GetLeftJoystick(), false);
            _ac.MoveAnimation(true);
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


    }

    public override void OnStateEnter()
    {
        //base.OnStateEnter();
        //Debug.Log("OnstateEnter Walk");
        _mc = new MovementController(_character);
        _ac = new AnimationController(_character.Animator);
    }

}
