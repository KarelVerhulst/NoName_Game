using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
    protected BaseCharacterBehaviour _character;

    public abstract void Tick();

    public virtual void OnStateEnter() { }
    public virtual void OnStateExit() { }

    public State(ICharacter character)
    {
        this._character = (BaseCharacterBehaviour)character;
    }
}
