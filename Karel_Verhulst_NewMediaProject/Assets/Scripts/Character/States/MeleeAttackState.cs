using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttackState : State
{
    /*
     * his melee attack goes here but for now i don't use this script
     */

    public MeleeAttackState(ICharacter character) : base(character)
    {
    }

    public override void Tick()
    {
        //Debug.Log("Melee attack");

        if (_character.Movement != Vector3.zero)
        {
            _character.SetState(new WalkState(_character));
        }
        else
        {
            _character.SetState(new IdleState(_character));
        }
        
    }
    
}
