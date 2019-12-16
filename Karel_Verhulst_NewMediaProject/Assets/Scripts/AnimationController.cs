using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController 
{
    private Animator _animator;

    public AnimationController(Animator animator)
    {
        _animator = animator;
    }

    private int _isRunningParam = Animator.StringToHash("IsRunning");
    private int _isJumpParam = Animator.StringToHash("IsJumping");
    private int _jumpDistanceToGroundParam = Animator.StringToHash("JumpDistanceToGround");
    private int _isDeadParam = Animator.StringToHash("IsDeath");

    public void MoveAnimation(bool isRunning)
    {
        _animator.SetBool(_isRunningParam, isRunning);
    }

    public void JumpAnimation(bool isJump, float distanceToGround)
    {
        _animator.SetBool(_isJumpParam, isJump);
        _animator.SetFloat(_jumpDistanceToGroundParam, distanceToGround);
    }

    public void DeadAnimation(bool isDead)
    {
        _animator.SetBool(_isDeadParam, isDead);
    }

    public bool CheckIfAnimationIsPlaying(int layerIndex, string animationName)
    {
        return _animator.GetCurrentAnimatorStateInfo(layerIndex).IsName(animationName);
    }
}
