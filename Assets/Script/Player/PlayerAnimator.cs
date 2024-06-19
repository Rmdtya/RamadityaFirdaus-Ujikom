using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private PlayerInputManager _playerInputManager;
    private Animator _playerAnimator;
    private int _horizontalInput;
    private int _verticalInput;

    private void Awake()
    {
        _playerAnimator = GetComponent<Animator>();
        _horizontalInput = Animator.StringToHash("horizontal");
        _verticalInput = Animator.StringToHash("vertical");
    }

    public void PlayTargetAnimation(string targetAnimation, bool isInteracting)
    {
        _playerAnimator.CrossFade(targetAnimation, 0.2f);
    }

    public void UpdateAnimatorValue(float horizontalInput, float verticalInput)
    {
        float snapHorizontalInput;

        if (horizontalInput >= 0.5f)
        {
            snapHorizontalInput = 1;
        }else if(horizontalInput <= -0.5f)
        {
            snapHorizontalInput= -1;
        }
        else
        {
            snapHorizontalInput = 0;
        }

        _playerAnimator.SetFloat(_horizontalInput, snapHorizontalInput, 0.1f, Time.deltaTime);
    }
}
