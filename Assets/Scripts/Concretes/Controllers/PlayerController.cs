using Servingame.Abstracts.Controllers;
using Servingame.Movements;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Servingame.Controllers
{
    public class PlayerController : MonoBehaviour , IEntityController , IMovement
    {
        HorizontalMove _horizontalMove;
        VerticalMove _verticalMove;
        RotationMove _rotationMove;
        Rigidbody rb;
        [SerializeField]private bool _isReadyToPlay,_isReadyToMove=false;
        public FloatingJoystick floatingJoystick;
        public GameObject JoystickActiviness;

        public float HorizontalSpeed { get ; set ; }
        public float VerticalSpeed { get ; set ; }
        public float MoveSpeed { get ; set ; }

        public float speed;
        public float turnSpeed;

        private void Awake()
        {
            _horizontalMove = new HorizontalMove(this);
            _verticalMove = new VerticalMove(this);
            _rotationMove = new RotationMove(this);
            rb = GetComponent<Rigidbody>();
            MoveSpeed = 1f;
            floatingJoystick = GameObject.Find("Floating Joystick").GetComponent<FloatingJoystick>();
            JoystickActiviness = GameObject.Find("Joystick");
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
            //DisableMovement();
        }

        public void IsPlayerMoved()
        {

            _horizontalMove.HorizontalMovement(HorizontalSpeed, MoveSpeed);
            _verticalMove.VerticalMovement(VerticalSpeed, MoveSpeed);
            _rotationMove.RotationPlayer(HorizontalSpeed, VerticalSpeed);
            JoystickMovement();
        }

        public void EnableMovement()
        {
            _isReadyToMove = true;
            JoystickActiviness.SetActive(true);

        }
        public void DisableMovement()
        {
            _isReadyToMove = false;
            JoystickActiviness.SetActive(false);
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

        public void JoystickMovement()
        {
            float horizontal = floatingJoystick.Horizontal;
            float vertical = floatingJoystick.Vertical;
            Vector3 addedPos = new Vector3(horizontal * speed * Time.deltaTime, 0, vertical * speed * Time.deltaTime);
            transform.position += addedPos;

            Vector3 direction = Vector3.forward * vertical + Vector3.right * horizontal;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), turnSpeed * Time.deltaTime);
        }

    }

}
