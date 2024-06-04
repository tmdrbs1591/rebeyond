using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : PlayerBase
{
    void Update()
    {
        Move();
        Fire();
    }
}
