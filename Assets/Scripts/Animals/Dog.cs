using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : Animal
{
    private void Awake()
    {
        speed = 20;
        patrolRadius = 20;
    }
}