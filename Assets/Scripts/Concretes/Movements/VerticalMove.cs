using Servingame.Abstracts.Controllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Servingame.Movements
{
    public class VerticalMove : PlayerMovements
    {
        IEntityController entity;

        public VerticalMove(IEntityController entityController)
        {
            entity = entityController;
        }
        public virtual void VerticalMovement(float vertical, float moveSpeed)
        {
            //if (vertical == 0f) return;
            //if (Input.GetMouseButton(0))
            //{
            //    vertical = ClampMethod(vertical);
            //    entity.transform.Translate(Vector3.forward * vertical * Time.deltaTime * moveSpeed, Space.World);
            //}
            //else return;
            PlayerDirection(vertical,moveSpeed,entity,Vector3.forward);
        }

    }
}

