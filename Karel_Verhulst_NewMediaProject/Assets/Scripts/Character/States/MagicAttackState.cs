using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicAttackState : State
{
    /*
     * magic attacks goes here
     * but because of some problems the real magic attack is placed in the dragon and wolf script
     */

    public MagicAttackState(ICharacter character) : base(character)
    {
      
    }
   
    public override void Tick()
    {
        //SetMagicAttack();

        StateInputController.MoveState(_character);
        StateInputController.JumpState(_character);
    }

    public override void OnStateEnter()
    {
        
    }
    
    private void SetMagicAttack()
    {
        if (_character.GetComponent<DragonBehaviour>())
        {
            _character.GetComponent<DragonBehaviour>().DragonMagicAttack();
        }
        else if(_character.GetComponent<WolfBehaviour>())
        {
            _character.GetComponent<WolfBehaviour>().WolfMagicAttack();
        }
    }
}
