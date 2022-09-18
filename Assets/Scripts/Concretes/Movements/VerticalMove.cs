using Servingame.Abstracts.Controllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Servingame.Movements
{
    public class VerticalMove 
    {
        IEntityController entity;
        float maxHSpeed = 0.7f;

        public VerticalMove(IEntityController entityController)
        {
            entity = entityController;
        }
        public virtual void VerticalMoveMethod(float vertical, float moveSpeed)
        {
            if (vertical == 0f) return;
            if (Input.GetMouseButton(0))
            {
                vertical = Mathf.Clamp(vertical, -maxHSpeed, maxHSpeed);
                entity.transform.Translate(Vector3.forward * vertical * Time.deltaTime * moveSpeed, Space.World);
            }
            else return;
        }
        public float characterZClamp(float position, float value)
        {
            position = Mathf.Clamp(position, -value, value);
            return position;
        }


    }
}

