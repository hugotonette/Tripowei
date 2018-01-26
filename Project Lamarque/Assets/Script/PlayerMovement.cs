using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    
    public float Speed = 10f;
    public float JumpForce = 400f;
    public Collider2D _GroundCheckCollider;

    private Rigidbody2D _playerBody;
    private bool _canJump;
    

    IEnumerator TimeForce(float Time)
    {
        GetComponent<Rigidbody>().AddForce(new Vector3(0, Speed, 0));
        yield return new WaitForSeconds(5);
    }

    private void Awake()
    {
        _playerBody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (_canJump)
        {
            if (Input.GetKeyDown("space") || Input.GetKeyDown(KeyCode.UpArrow))  //Jump
            {
                Debug.Log("jump");
                _playerBody.AddForce(new Vector2(0f, JumpForce));
            }
        }

        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))  //Right
        {
            Debug.Log("Right");
            _playerBody.velocity = new Vector2(Speed, _playerBody.velocity.y);
        }
        else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))  //Left
        {
            Debug.Log("Left");
            _playerBody.velocity = new Vector2(-Speed, _playerBody.velocity.y);
        }

    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Floor"))
            _canJump = true;
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Floor"))
            _canJump = false;
    }

}
