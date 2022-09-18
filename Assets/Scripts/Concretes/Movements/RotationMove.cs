using Servingame.Controllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Servingame.Movements
{
    public class RotationMove : MonoBehaviour
    {
        PlayerController _playerController;
        public RotationMove(PlayerController playerController)
        {
            _playerController = playerController;
        }

        public void RotationPlayer(float horizontal,float vertical)
        {
            Vector3 movementDirection = new Vector3(horizontal, 0, vertical);
            movementDirection.Normalize();

            if (movementDirection != Vector3.zero)
            {
                _playerController.transform.forward = movementDirection;
            }
        }
    }
}

