using Servingame.Abstracts.Controllers;
using Servingame.Movements;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Servingame.Controllers
{
    public class PlayerController : MonoBehaviour , IEntityController
    {
        //PlayerAnimation _playerAnimation;
        [SerializeField] private PlayerManager playerManager;
        HorizontalMove _horizontalMove;
        VerticalMove _verticalMove;
        RotationMove _rotationMove;
        Rigidbody rb;
        [SerializeField]private bool _isReadyToPlay,_isReadyToMove=false;
        float _horizontal;
        float _vertical ;
        [SerializeField] float _moveSpeed=5f;

        private void Awake()
        {
            _horizontalMove = new HorizontalMove(this);
            _verticalMove = new VerticalMove(this);
            _rotationMove = new RotationMove(this);
            rb = GetComponent<Rigidbody>();
        }
        private void FixedUpdate()
        {
            if (_isReadyToPlay)
            {
                if (_isReadyToMove)
                {
                    IsPlayerMoved();
                }
                else
                {
                    DisableMovement();
                }
            }
        }
        private void OnEnable()
        {
            EnableMovement();
        }
        private void OnDisable()
        {
            DisableMovement();
        }

        public void HorizontalMovement(float value)
        {
            _horizontal = _horizontal + value * Time.deltaTime * 1.5f;
        }

        public void VerticalMovement(float value)
        {
            _vertical = _vertical + value * Time.deltaTime * 1.5f;
        }

        public void IsPlayerMoved()
        {

            _horizontalMove.TickFixed(_horizontal, _moveSpeed);
            _verticalMove.VerticalMoveMethod(_vertical, _moveSpeed);
            _rotationMove.RotationPlayer(_horizontal, _vertical);
        }
        public void EnableMovement()
        {
            //InputManager.Instance.OnStartTouchH += HorizontalMovement;
            //InputManager.Instance.OnStartTouchV += VerticalMovement;
            _isReadyToMove = true;

        }
        public void DisableMovement()
        {
            //InputManager.Instance.OnStartTouchH -= HorizontalMovement;
            //InputManager.Instance.OnStartTouchV -= VerticalMovement;
            _isReadyToMove = false;
        }
        public void IsReadyToPlay(bool readyToPlayBool)
        {
            _isReadyToPlay = readyToPlayBool;
        }
        public void Reset()
        {
            DisableMovement();
            _isReadyToPlay = false;
            _isReadyToMove = false;
        }

        public void UpdateRunnerInputValue(RunnerInputParams runnerInputParams)
        {
            _horizontal += runnerInputParams.XValue * Time.deltaTime * 1.5f;
            _vertical += runnerInputParams.ZValue * Time.deltaTime * 1.5f;
        }

        public void SetRunnerInputValue(float x,float z)
        {
            _horizontal = x;
            _vertical = z;
        }
        
        public void IsPlayerMoving()
        {

        }
    }

}
