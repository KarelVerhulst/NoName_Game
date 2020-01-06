using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkState : State
{
    /*
     * movement state + the move animation
     */

    private Vector3 _moveDirection = Vector3.zero;

    private MovementController _mc;
    private AnimationController _ac;

    public WalkState(ICharacter character) : base(character)
    {
    }
    
    public override void Tick()
    {
        PlayDeathAnimation();

        if (_ac.CheckIfAnimationIsPlaying(0, "Dead"))
            return;

        CharacterMovement();
        
        StateInputController.JumpState(_character);

    }

    public override void OnStateEnter()
    {
        //base.OnStateEnter();
        //Debug.Log("OnstateEnter Walk");
        _mc = new MovementController(_character);
        _ac = new AnimationController(_character.Animator);
    }

    private void PlayDeathAnimation()
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

        
    }

    private void CharacterMovement()
    {
        _character.Movement = InputController.GetLeftJoystick();

        if (_character.Movement != Vector3.zero)
        {
            _mc.UpdateMovement(false);
            _ac.MoveAnimation(true);
        }
        else
        {
            _ac.MoveAnimation(false);
            _character.SetState(new IdleState(_character));

        }
    }
}
