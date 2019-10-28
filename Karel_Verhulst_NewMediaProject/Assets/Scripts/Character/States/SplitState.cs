using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplitState : State
{
    private Transform _newPosition = null;

    public SplitState(ICharacter character, Transform newPosition) : base(character)
    {
        _newPosition = newPosition;
    }

    public override void Tick()
    {
        //Debug.Log("Split");

        //throw new System.NotImplementedException();

        //_character.SetState(new IdleState(_character));
    }

    public override void OnStateEnter()
    {
        base.OnStateEnter();
        _character.IsCharacterSplit = true;
        _character.transform.position = _newPosition.position;

        _character.StartCoroutine(test());
        
    }

    IEnumerator test()
    {
        yield return new WaitForSeconds(1f);

        _character.SetState(new IdleState(_character));
    }
}
