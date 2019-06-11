using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //public Vector3 my_forward_position_angle;


    public float speed = 10f;
    private float rotation_speed = 5f;
    

    private Rigidbody2D rb_player;
    private Vector2 moveVelocity;
    private Vector2 dashmoveVelocity;


    private Vector3 lastMoveDir;

    private float x_compound;
    private float y_compound;

   
    void Start()
    {
        rb_player = GetComponent<Rigidbody2D>();
        x_compound = rb_player.position.x;
        y_compound = rb_player.position.y;
    }

    void Update()
    {

        HandleMovement();
        
        HandleDash();
    }

    


    


    private void HandleMovement()
    {
        float moveX = 0f;
        float moveY = 0f;

        if (Input.GetKey(KeyCode.W))
        {
            moveY = +1f;
        }
        if (Input.GetKey(KeyCode.S))
        {
            moveY = -1f;
        }
        if (Input.GetKey(KeyCode.A))
        {
            moveX = -1f;
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveX = +1f;
        }

        bool isIdle = moveX == 0 && moveY == 0;
        if (!isIdle)
        {
            Vector3 moveDir = new Vector3(moveX, moveY).normalized;
            lastMoveDir = moveDir;
            transform.position += moveDir * speed * Time.deltaTime;
        }
        
    }

    private void HandleDash()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            float dashDistance = 5f;
            transform.position += lastMoveDir * dashDistance;
        }
    }

    private bool CanMove(Vector3 dir, float distance)
    {
        return Physics2D.Raycast(transform.position, dir, distance).collider == null;
    }
}
