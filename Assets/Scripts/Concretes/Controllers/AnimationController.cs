using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void ChangePlayerAnimation(PlayerAnimationStates playerAnimationStates)
    {
        //Debug.Log(playerAnimationStates);
        switch (playerAnimationStates)
        {
            case PlayerAnimationStates.Idle:
                _animator.Play(playerAnimationStates.ToString());
                break;
            case PlayerAnimationStates.Running:
                _animator.Play(playerAnimationStates.ToString());
                break;
            case PlayerAnimationStates.ServingIdle:
                _animator.Play(playerAnimationStates.ToString());
                break;
            case PlayerAnimationStates.ServingRunning:
                _animator.Play(playerAnimationStates.ToString());
                break;
            case PlayerAnimationStates.FillUp:
                _animator.Play(playerAnimationStates.ToString());
                break;
        }
    }
}
