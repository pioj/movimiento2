using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class control : MonoBehaviour
{
    // Start is called before the first frame update

    private Rigidbody2D rb;
    private float angle;
    public float speedRot;
    float impulse;
    public float maximpulse;

    private Vector2 cosa; 
    
     void Awake()
     {
         rb = GetComponent<Rigidbody2D>();
     }

    void Start()
    {
        cosa = Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {
        angle = -Input.GetAxis("Horizontal") * speedRot;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            impulse++;
            cosa = Vector2.up * impulse;
        }
        impulse = Mathf.Clamp(impulse, 0f, maximpulse);

    }

     void FixedUpdate()
     {
        rb.MoveRotation(rb.rotation + angle * Time.fixedDeltaTime);
        rb.AddRelativeForce(cosa);
        cosa *= 0.98f;
     }
}
