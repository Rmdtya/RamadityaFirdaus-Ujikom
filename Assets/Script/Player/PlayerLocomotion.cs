using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerLocomotion : MonoBehaviour
    {
        private PlayerInputManager _playerInputManager;
        private PlayerManager _playerManager;
        private PlayerAnimator _playerAnimator;

        public Vector3 _moveDirection;
        private Rigidbody _playerRb;
        [SerializeField] private PlayerStatus _playerStatus;

        private void Awake()
        {
            _playerManager = GetComponent<PlayerManager>();
            _playerInputManager = GetComponent<PlayerInputManager>();
            _playerRb = GetComponent<Rigidbody>();
            _playerAnimator = GetComponent<PlayerAnimator>();
        }

        public void HandleMovement()
        {
            _moveDirection = transform.right * _playerInputManager.horizontalInput;

            _moveDirection.Normalize();
            _moveDirection.y = 0;

            _moveDirection = _moveDirection * _playerStatus.speed;

            Vector3 movementVelocity = _moveDirection;

            _playerRb.velocity = movementVelocity;
        }
    }
}
