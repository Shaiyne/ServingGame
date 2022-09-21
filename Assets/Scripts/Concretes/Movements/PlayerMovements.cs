using Servingame.Abstracts.Controllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerMovements 
{
    private float speedClamp = 0.7f;

    public float SpeedClamp { get { return speedClamp; }}

    public float ClampMethod(float value)
    {
        return value = Mathf.Clamp(value, -speedClamp, speedClamp);
    }
    public void PlayerDirection(float direction, float moveSpeed,IEntityController entityController,Vector3 vctr)
    {
        if (direction == 0f) return;
        if (Input.GetMouseButton(0))
        {
            direction = ClampMethod(direction);
            entityController.transform.Translate(vctr * direction * Time.deltaTime * moveSpeed, Space.World);
        }
        else return;
    }
}
