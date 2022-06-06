using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    [SerializeField] public GameObject mainCamera;
    [SerializeField] protected float speed;
    [SerializeField] protected float jumpPower;
    [SerializeField] protected bool isGrounded = true;

    private Animator characterAnim;
    private Rigidbody characterRigidBody;

    private void Start()
    {
        characterAnim = GetComponent<Animator>();
        characterRigidBody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Move();

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Space) && Input.GetKeyDown(KeyCode.LeftShift))
        {
            Jump();
        }
        else if (Input.GetKey(KeyCode.LeftShift))
        {
            Sprint();
        }
        else
        {
            speed = 5000;
        }
    }

    private void LateUpdate()
    {
        if (mainCamera)
        {
            mainCamera.transform.position = transform.position;
        }

        if (gameObject.transform.position.y < 0)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, 0, gameObject.transform.position.z);
        }
    }

    private void Move()
    {
        var forwardInput = Input.GetAxis("Vertical");
        var rotateInput = Input.GetAxis("Horizontal");

        if (forwardInput > 0 || forwardInput < 0)
        {
            characterAnim.SetFloat("Speed_f", 0.3f);
        }
        else
        {
            characterAnim.SetFloat("Speed_f", 0.0f);
        }

        if (mainCamera)
        {
            characterRigidBody.AddForce(mainCamera.transform.forward * forwardInput * speed);
            gameObject.transform.Rotate(Vector3.up * rotateInput);
            mainCamera.transform.Rotate(Vector3.up * rotateInput);
        }
    }

    private void Sprint() 
    {
        characterAnim.SetFloat("Speed_f", 1.0f);
        speed = 8000;
    }

    private void Jump()
    {
        if (isGrounded)
        {
            characterAnim.SetTrigger("Jump_trig");
            characterRigidBody.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}