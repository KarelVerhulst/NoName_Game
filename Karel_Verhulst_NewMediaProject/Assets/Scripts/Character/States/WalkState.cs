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

        if (InputController.GetLeftJoystick() != Vector3.zero)
        {
            // MoveBehaviour();
            _mc.UpdateMovement(InputController.GetLeftJoystick(), false);
            _ac.MoveAnimation(true);
        }
        else
        {
            _character.SetState(new IdleState(_character));
            _ac.MoveAnimation(false);
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
