using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox : Animal
{
    private void Awake()
    {
        speed = 55;
        patrolRadius = 20;
    }
}
