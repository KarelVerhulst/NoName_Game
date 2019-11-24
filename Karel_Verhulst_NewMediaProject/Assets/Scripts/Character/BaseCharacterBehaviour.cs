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
    [SerializeField]
    private LayerMask _mapLayerMask = 0;
    [SerializeField]
    protected float _spendingAmountOfMana = 1;

    private State _currentState;
    
    // Properties
    private CharacterController _cc;
    public CharacterController CC { get { return _cc; } }

    private Animator _animator = null;
    public Animator Animator { get { return _animator; } }

    private Transform _camera = null;
    public Transform CameraTransform { get { return _camera; } }

    public float MoveSpeed { get { return _moveSpeed; } }
    public float RotateSpeed { get { return _rotateSpeed; } }
    public float JumpSpeed { get { return _jumpSpeed; }  }
    public float Gravity { get { return _gravity; } }
    public Vector3 Movement { get; set; }

    public bool IsCharacterSplit { get; set; }

    void Awake()
    {
        _cc = this.GetComponent<CharacterController>();
        _camera = Camera.main.transform;
        _animator = this.GetComponent<Animator>();
   
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
     
    public float GetJumpDistanceToGround()
    {
        RaycastHit hit;
        if (Physics.Raycast(this.transform.position, Vector3.down, out hit, 100, _mapLayerMask))
        {
            return (hit.point - this.transform.position).magnitude;
        }

        return 0;
    }
}
