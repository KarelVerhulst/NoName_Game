using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StateInputController
{
    /*
     * this script is mean to put everything that use the inputcontroller, so i only need to write it once and i can use it in other scripts 
     * but it's not good enoug
     */

    public static void MoveState(BaseCharacterBehaviour character)
    {
        character.Movement = InputController.GetLeftJoystick();

        if (character.Movement != Vector3.zero)
        {
            character.SetState(new WalkState(character));
        }
        else
        {
            IdleState(character);
        }
    }

    private static void IdleState(BaseCharacterBehaviour character)
    {
        character.SetState(new IdleState(character));
    }

    public static void JumpState(BaseCharacterBehaviour character)
    {
        if (InputController.IsButtonYPressed())
        {
            character.SetState(new JumpState(character));
        }
    }

    //public static void MagicAttackState(BaseCharacterBehaviour character)
    //{
    //    bool newTriggerHeld = InputController.GetRightTrigger() > 0f;
    //    if (newTriggerHeld && character.GetComponentInParent<HealthBehaviour>().Health > 0)
    //    {
    //        character.SetState(new MagicAttackState(character));
    //    }
    //    else
    //    {
    //        WolfBehaviour wolfBehaviour = character.GetComponent<WolfBehaviour>();

    //        if (wolfBehaviour != null)
    //        {
    //            wolfBehaviour.IsShieldActive = false;
    //        }
            
    //        character.GetComponentInParent<ManaBehaviour>().IsManaEmpty = false;
    //        character.GetComponentInParent<ManaBehaviour>().FillManaAmount();
    //    }
    //}
}
