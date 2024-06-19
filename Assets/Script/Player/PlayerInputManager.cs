using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerInputManager : MonoBehaviour
    {
        private PlayerControls _playerControls;
        private PlayerAnimator _playerAnimator;
        private PlayerInputManager _playerInputManager;
        private PlayerAudio _playerAudio;

        [SerializeField] private Vector2 moveInput;
        public float moveAmount;
        public float verticalInput;
        public float horizontalInput;
        public Vector3 offsetFood;

        private void Awake()
        {
            if(_playerControls == null)
            {
                _playerControls = new PlayerControls();
            }

            _playerAnimator = GetComponent<PlayerAnimator>();
            _playerInputManager = GetComponent<PlayerInputManager>();
            _playerAudio = GetComponent<PlayerAudio>();
        }

        private void OnEnable()
        {
            _playerControls.Movement.Move.performed += OnMove;
            _playerControls.Movement.Move.canceled += OnMove;

            _playerControls.Movement.Attack.performed += attack;

            _playerControls.Enable();
        }

        private void attack(UnityEngine.InputSystem.InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                GameObject foodObject = PlayerFoodPool.instance.GetFoodObject();

                if (foodObject != null)
                {
                    foodObject.transform.position = transform.position + offsetFood;
                    foodObject.SetActive(true);
                    SoundManager.instance.PlayFood();
                }
            }
        }

        private void OnDisable()
        {
            _playerControls.Movement.Move.performed -= OnMove;
            _playerControls.Movement.Move.canceled -= OnMove;

            _playerControls.Movement.Attack.performed -= attack;

            _playerControls.Disable();
        }


        private void OnMove(UnityEngine.InputSystem.InputAction.CallbackContext context)
        {
            moveInput = context.ReadValue<Vector2>();
        }

        public void HandleMovementInput()
        {
            verticalInput = moveInput.y;
            horizontalInput = moveInput.x;

            moveAmount = Mathf.Clamp01(Mathf.Abs(horizontalInput) + Mathf.Abs(verticalInput));
            _playerAnimator.UpdateAnimatorValue(moveAmount, 0);
        }
    }
}
