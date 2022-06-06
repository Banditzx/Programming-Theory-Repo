using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
    [SerializeField] protected float speed;
    [SerializeField] protected float patrolRadius;

    private Rigidbody animalRb;
    private Animator animalAnim;
    private Vector3 defaultPathPos;
    private Vector3 patrolPathPos;
    private bool isPathEnd = true;
    private bool isBreak = false;

    // Start is called before the first frame update
    void Start()
    {
        animalRb = GetComponent<Rigidbody>();
        animalAnim = GetComponent<Animator>();
        defaultPathPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        if (isPathEnd || patrolPathPos == null)
        {
            patrolPathPos = GetRandomPos();
            isPathEnd = false;
            animalAnim.SetFloat("Speed_f", 0.5f);
        }

        if (!isPathEnd && !isBreak)
        {
            Vector3 lookDirection = (patrolPathPos - transform.position).normalized;
            animalRb.AddForce(lookDirection * speed);
            animalRb.transform.LookAt(patrolPathPos);

            if (ComparePos(transform.position, patrolPathPos))
            {
                isBreak = true;
                animalAnim.SetFloat("Speed_f", 0.1f);
                StartCoroutine(GoToNextPath());
            }
        }
    }

    private bool ComparePos(Vector3 currentPos, Vector3 patrolPos)
    {
        int xCurrent = (int)currentPos.x;
        int zCurrent = (int)currentPos.z;
        int xPatrol = (int)patrolPos.x;
        int zPatrol = (int)patrolPos.z;

        if (xCurrent == xPatrol && zCurrent == zPatrol)
        {
            return true;
        }

        return false;
    }

    private IEnumerator GoToNextPath()
    {
        var second = Random.Range(5, 10);
        yield return new WaitForSeconds(second);
        isPathEnd = true;
        isBreak = false;
    }

    private Vector3 GetRandomPos()
    {
        var x = Random.Range(defaultPathPos.x, defaultPathPos.x + patrolRadius);
        var z = Random.Range(defaultPathPos.z, defaultPathPos.z + patrolRadius);

        return new Vector3(x, 0.0f, z);
    }

    private void OnCollisionEnter(Collision collision)
    {
        isPathEnd = true;
    }
}