using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreManager : MonoBehaviour
{
    public StoreManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }
}
