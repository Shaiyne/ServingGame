using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMovement 
{
    float HorizontalSpeed { get; set; }

    float VerticalSpeed { get; set; }

    float MoveSpeed { get ; set; }
}
