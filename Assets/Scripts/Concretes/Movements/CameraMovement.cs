using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Servingame.Controllers;

namespace Servingame.Movements
{
    public class CameraMovement : MonoBehaviour
    {
        PlayerController playerController;
        Vector3 distance;
        float smoothSpeed = 0.125f;
        private void Awake()
        {
            playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        }
        private void Start()
        {
            distance = transform.position - playerController.transform.position;
        }
        void Update()
        {
            FollowCamera();
        }

        void FollowCamera()
        {
            Vector3 smoothPosition = distance + playerController.transform.position;
            transform.position = Vector3.Lerp(transform.position, smoothPosition, smoothSpeed);
        }
    }
}

