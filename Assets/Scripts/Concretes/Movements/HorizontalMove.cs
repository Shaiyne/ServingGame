using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Servingame.Abstracts.Controllers;

namespace Servingame.Movements
{
    public class HorizontalMove 
    {
        float maxHSpeed = 0.7f;
        IEntityController entity;

        public HorizontalMove(IEntityController entityController)
        {
            entity = entityController;
        }
        public virtual void TickFixed(float horizontal, float moveSpeed)
        {
            if (horizontal == 0f) return;
            if (Input.GetMouseButton(0))
            {
                horizontal = Mathf.Clamp(horizontal, -maxHSpeed, maxHSpeed);
                entity.transform.Translate(Vector3.right * horizontal * Time.deltaTime * moveSpeed, Space.World);
            }
            else
            {
                return;
            }
        }

        public float characterXClamp(float position, float value)
        {
            position = Mathf.Clamp(position, -value, value);
            return position;
        }


    }

}

