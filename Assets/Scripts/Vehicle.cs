using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Vehicle : MonoBehaviour
{
    [SerializeField] private float speed;

    private Rigidbody vehicleRb;

    private void Start()
    {
        vehicleRb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        vehicleRb.AddForce(gameObject.transform.forward * Time.deltaTime * speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Mountains"))
        {
            Destroy(gameObject);
        }
    }
}