using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformState : State
{
    /*
     * this transform the character to another one
     * for example from dragon to wolf and set the state back to idle
     */

    private GameObject _newCharacter;

    public TransformState(ICharacter character, GameObject newCharacter) : base(character)
    {
        _newCharacter = newCharacter;
        _newCharacter.transform.position = _character.transform.position;
        _newCharacter.transform.rotation = _character.transform.rotation;

        _character.GetComponentInParent<TransformBehaviour>().StartTransformCounter = true;
    }

    public override void Tick()
    {
        _newCharacter.SetActive(true);
        _character.gameObject.SetActive(false);

        StateInputController.MoveState(_character);
    }

    public override void OnStateEnter()
    {
        base.OnStateEnter();
        //Debug.Log("OnStateEnter Transform | " + _character.name);
    }
}
