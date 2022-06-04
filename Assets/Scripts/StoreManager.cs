using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreManager : MonoBehaviour
{
    public static StoreManager Instance { get; private set; }

    public GameObject character { get; set; }

    private void Awake()
    {
        Instance = this;
    }
}