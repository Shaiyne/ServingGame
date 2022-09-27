using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void ChangePlayerAnimation(PlayerAnimationStates playerAnimationStates)
    {
        //Debug.Log(playerAnimationStates);
        switch (playerAnimationStates)
        {
            case PlayerAnimationStates.Idle:
                animator.Play(playerAnimationStates.ToString());
                break;
            case PlayerAnimationStates.Running:
                animator.Play(playerAnimationStates.ToString());
                break;
            case PlayerAnimationStates.ServingIdle:
                animator.Play(playerAnimationStates.ToString());
                break;
            case PlayerAnimationStates.ServingRunning:
                animator.Play(playerAnimationStates.ToString());
                break;
            case PlayerAnimationStates.FillUp:
                animator.Play(playerAnimationStates.ToString());
                break;
        }
    }
}
