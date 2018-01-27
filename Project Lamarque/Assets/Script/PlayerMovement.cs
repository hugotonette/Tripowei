using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float Speed = 10f;
    public float JumpForce = 400f;
    public bool CanMoveOnAir = true;

    private Rigidbody2D _playerBody;
    private bool _canJump;


    private void Awake()
    {
        _playerBody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (_canJump)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow))  //Jump
            {
                Debug.Log("jump");
                _playerBody.AddForce(new Vector2(0f, JumpForce));
            }
        }

        //Linear Drag (no RigidBody2D define o atrito (tempo q demora pra parar o movimento)
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))  //Right
        {
            Debug.Log("Right");
            _playerBody.velocity = new Vector2(Speed, _playerBody.velocity.y);
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))  //Left
        {
            Debug.Log("Left");
            _playerBody.velocity = new Vector2(-Speed, _playerBody.velocity.y);
        }


    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Floor"))  //Está encostando no chão
        {
            _canJump = true;
        }
    }

    private void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Floor"))
        {
            _canJump = false;
        }
    }

}
