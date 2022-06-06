using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chicken : Animal
{
    private void Awake()
    {
        speed = 5.5f;
        patrolRadius = 10;
    }
}