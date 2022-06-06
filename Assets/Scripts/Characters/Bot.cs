using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bot : Animal
{
    private void Awake()
    {
        speed = 65;
        patrolRadius = 20;
    }
}
