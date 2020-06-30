using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float jumpHieght = 10f;
    public Collider2D groundCollider;
    private Boolean isGrounded = false;
    private Rigidbody2D rigid;
    private Collider2D collider;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        collider = transform.GetChild(0).GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float xAxis = Input.GetAxis("Horizontal");
        if (xAxis > 0)
        {
            transform.localScale = new Vector3(3, 3);
        }
        if(xAxis < 0)
        {
            transform.localScale = new Vector3(-3, 3);
        }
        transform.Translate(transform.right * xAxis * Time.deltaTime * moveSpeed);
    }

    private void FixedUpdate()
    {
        float xAxis = Input.GetAxis("Horizontal");
        float yAxis = Input.GetAxis("Vertical");
        if (collider.IsTouching(groundCollider))
        {
            isGrounded = true;
        }
        if (yAxis > 0 || Input.GetKeyDown("space"))
        {
            Jump(xAxis);
        }
    }

    void Jump(float xAxis)
    {
        if (isGrounded)
        {
            Vector2 force = new Vector2(xAxis, jumpHieght);
            rigid.AddForce(force);
            isGrounded = false;
        }
    }

}
