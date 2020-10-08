using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{

    public float forwardForce = 1000;
    public float sideForce = 50;

    private bool moveLeft = false;
    private bool moveRight = false;
    private bool accellerate = false;
    private bool deAccellerate = false;

    private Rigidbody rb;
    private Vector3 startPos;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(new Vector3(0, 0, 200));
        startPos = gameObject.transform.position;
    }


    void Update()
    {
        var sideTrigger = Input.GetAxisRaw("Horizontal");
        if (sideTrigger >  0)
        {
            moveRight = true;
            moveLeft = false;
        }

        if (sideTrigger < 0)
        {
            moveLeft = true;
            moveRight = false;
        }

        if (sideTrigger == 0)
        {
            moveRight = false;
            moveLeft = false;
        }

        var upTrigger = Input.GetAxisRaw("Vertical");

        if (upTrigger > 0)
        {
            accellerate = true;
        }

        if (upTrigger < 0)
        {
            deAccellerate = true;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var zDiff = (transform.position.z - startPos.z) / 5;
        rb.AddForce(new Vector3(0, 0, forwardForce + zDiff) * Time.deltaTime);

        if (moveRight)
        {
            rb.AddForce(new Vector3(sideForce, 0, 0));
        }

        if (moveLeft)
        {
            rb.AddForce(new Vector3(-sideForce, 0, 0));
        }

        if (accellerate)
        {
            rb.AddForce(new Vector3(0, 0, 1000) * Time.deltaTime);
        }

        if (deAccellerate)
        {
            rb.AddForce(new Vector3(0, 0, -1000) * Time.deltaTime);
        }

        accellerate = false;
        deAccellerate = false;
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("obstacle"))
        {
            rb.AddForce(new Vector3(0, 100, 0));
        }
    }
}
