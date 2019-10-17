using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseCharacterBehaviour : MonoBehaviour, ICharacter
{
    // fields
    [SerializeField]
    private float _moveSpeed = 4.0f;
    [SerializeField]
    private float _rotateSpeed = 8.0f;
    [SerializeField]
    protected float _jumpSpeed = 8.0f;
    [SerializeField]
    protected float _gravity = 20.0f;

    private State _currentState;

    // Properties
    private CharacterController _cc;
    public CharacterController CC { get { return _cc; } }

    private Transform _camera;
    public Transform CameraTransform { get { return _camera; } }

    public float MoveSpeed { get { return _moveSpeed; } }
    public float RotateSpeed { get { return _rotateSpeed; } }
    public float JumpSpeed { get { return _jumpSpeed; }  }
    public float Gravity { get { return _gravity; } }
    public Vector3 Movement { get; set; }

    void Awake()
    {
        _cc = this.GetComponent<CharacterController>();
        _camera = Camera.main.transform;
   
        SetState(new IdleState(this));
    }
    
    protected virtual void Update()
    {
        _currentState.Tick();
    }
    
    public void SetState(State state)
    {
        if (_currentState != null)
            _currentState.OnStateExit();

        _currentState = state;

        if (_currentState != null)
            _currentState.OnStateEnter();
    }
}
