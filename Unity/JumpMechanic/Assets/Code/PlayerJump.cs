using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    private float jumpForce = 10f;
    private bool IsGrounded = false;
    private Rigidbody player;

    private void Start()
    {
        player = GetComponent<Rigidbody>();
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded == true)
        {
            player.velocity = new Vector3(0f, jumpForce, 0f);
            IsGrounded = false;
        }
    }

    private void Update()
    {
        Jump();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name != "Player")
        {
            IsGrounded = true;
        }
    }
}
