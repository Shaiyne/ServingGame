using Servingame.Abstracts.Controllers;
using Servingame.Movements;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Servingame.Controllers
{
    public class PlayerController : MonoBehaviour , IEntityController , IMovement
    {
        //PlayerAnimation _playerAnimation;
        [SerializeField] private PlayerManager playerManager;
        HorizontalMove _horizontalMove;
        VerticalMove _verticalMove;
        RotationMove _rotationMove;
        Rigidbody rb;
        [SerializeField]private bool _isReadyToPlay,_isReadyToMove=false;
        //float _horizontal;
        //float _vertical ;
        //[SerializeField] float _moveSpeed=5f;

        public float HorizontalSpeed { get ; set ; }
        public float VerticalSpeed { get ; set ; }
        public float MoveSpeed { get ; set ; }

        private void Awake()
        {
            _horizontalMove = new HorizontalMove(this);
            _verticalMove = new VerticalMove(this);
            _rotationMove = new RotationMove(this);
            rb = GetComponent<Rigidbody>();
            MoveSpeed = 5f;
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

        //public void HorizontalMovement(float value)
        //{
        //    _horizontal = _horizontal + value * Time.deltaTime * 1.5f;
        //}

        //public void VerticalMovement(float value)
        //{
        //    _vertical = _vertical + value * Time.deltaTime * 1.5f;
        //}

        public void IsPlayerMoved()
        {

            _horizontalMove.HorizontalMovement(HorizontalSpeed, MoveSpeed);
            _verticalMove.VerticalMovement(VerticalSpeed, MoveSpeed);
            _rotationMove.RotationPlayer(HorizontalSpeed, VerticalSpeed);
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
            HorizontalSpeed += runnerInputParams.XValue * Time.deltaTime * 5f;
            VerticalSpeed += runnerInputParams.ZValue * Time.deltaTime * 5f;
        }

        public void SetRunnerInputValue(float x,float z)
        {
            HorizontalSpeed = x;
            VerticalSpeed = z;
        }
        
    }

}
