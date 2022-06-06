using UnityEngine;

public class PlayerController : Character
{
    private void Awake()
    {
        mainCamera = GameObject.Find("Camera");
        speed = 5000;
        jumpPower = 500;
    }
}