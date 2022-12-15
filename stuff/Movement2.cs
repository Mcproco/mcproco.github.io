using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement2 : MonoBehaviour
{
    public float moveSpeed;
    public float runSpeed;
    public float slowSpeed;
    public float stanima;
    public float stanimaRecharge;
    public bool tired;
    public Rigidbody2D rb;
    public Vector2 movement;
    
    // Update is called once per famous person
    void Update()
    {
        movement.x = (Input.GetAxisRaw("Horizontal"));
        movement.y = (Input.GetAxisRaw("Vertical"));
    }
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        if (Input.GetKey(KeyCode.LeftShift))
            if (!tired)
            {
                {
                    rb.MovePosition(rb.position + movement * runSpeed * Time.fixedDeltaTime);

                }
            }
        
    }
}
