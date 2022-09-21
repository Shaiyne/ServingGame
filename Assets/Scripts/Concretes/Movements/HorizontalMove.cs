using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Servingame.Abstracts.Controllers;

namespace Servingame.Movements
{
    public class HorizontalMove : PlayerMovements
    {
        IEntityController entity;

        public HorizontalMove(IEntityController entityController)
        {
            entity = entityController;
        }
        public virtual void HorizontalMovement(float horizontal, float moveSpeed)
        {
            //if (horizontal == 0f) return;
            //if (Input.GetMouseButton(0))
            //{
            //    horizontal = ClampMethod(horizontal);
            //    entity.transform.Translate(Vector3.right * horizontal * Time.deltaTime * moveSpeed, Space.World);
            //}
            //else return;
            PlayerDirection(horizontal, moveSpeed, entity, Vector3.right);
        }

    }

}

