using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformState : State
{
    private GameObject _newCharacter;

    public TransformState(ICharacter character, GameObject newCharacter) : base(character)
    {
        _newCharacter = newCharacter;
        _newCharacter.transform.position = _character.transform.position;
        _newCharacter.transform.rotation = _character.transform.rotation;

    }

    public override void Tick()
    {
        _newCharacter.SetActive(true);
        _character.gameObject.SetActive(false);
        
        _character.SetState(new IdleState(_character));
    }

public override void OnStateEnter()
    {
        //Debug.Log("OnStateEnter Transform | " + _character.name);
    }
}
