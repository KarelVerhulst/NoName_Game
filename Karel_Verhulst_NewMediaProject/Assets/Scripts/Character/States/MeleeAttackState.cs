using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttackState : State
{
    public MeleeAttackState(ICharacter character) : base(character)
    {
    }

    public override void Tick()
    {
        //Debug.Log("Melee attack");

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
