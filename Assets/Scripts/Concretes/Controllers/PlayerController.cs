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

        public void IsPlayerMoved()
        {

            _horizontalMove.HorizontalMovement(HorizontalSpeed, MoveSpeed);
            _verticalMove.VerticalMovement(VerticalSpeed, MoveSpeed);
            _rotationMove.RotationPlayer(HorizontalSpeed, VerticalSpeed);
        }
        public void EnableMovement()
        {
            _isReadyToMove = true;

        }
        public void DisableMovement()
        {
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
