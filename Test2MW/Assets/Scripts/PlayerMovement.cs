using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float Speed = 5;

    public Rigidbody rb;
    private TailMovement tail;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        tail = GetComponent<TailMovement>();

        rb.velocity = Vector3.forward * Speed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
       // if (Input.GetKey(KeyCode.W))
        {
            rb.velocity = Vector3.forward * Speed;
        }

        if (Input.GetKey(KeyCode.S))
        {
            rb.velocity = Vector3.back * Speed;
        }

        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = Vector3.left * Speed;
        }

        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = Vector3.right * Speed;
        }

        Speed += 0.01f;
    }




}
