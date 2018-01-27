using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float MaxSpeedX, MaxSpeedY;
    public float GroundAccel, AirAccel;
    public float JumpSpeed;

    public Collider2D groundCheckCol;
    public LayerMask whatIsSolid;

    private Rigidbody2D _playerBody;
    private bool _onGround;

    float _axisHorizontal;
    bool _kJumpDown, _kJumpRelease;

    private void Awake()
    {
        _playerBody = GetComponent<Rigidbody2D>();

        _kJumpDown = false;
        _kJumpRelease = false;
    }

    private void Update()
    {
        // Checking Inputs. As the inputs are updated only on the Update, we only check them here.
        _axisHorizontal = Input.GetAxis("Horizontal");

        _kJumpDown = Input.GetButtonDown("Jump");
        _kJumpRelease = Input.GetButtonUp("Jump");

        _onGround = Physics2D.IsTouchingLayers(groundCheckCol, whatIsSolid);

        // As our movement don't apply forces, we can apply it during the Update. 
        // Applying the movement during the Fixed Update can result in losing Inputs.
        ApplyMovement();
    }

    private void FixedUpdate()
    {
        //Nothing...
    }


    void ApplyMovement()
    {
        float currentSpeedY = _playerBody.velocity.y;

        float targetSpeedX;
        float currentSpeedX;
        currentSpeedX = _playerBody.velocity.x;
        targetSpeedX = MaxSpeedX * _axisHorizontal;

        if (_onGround)
            currentSpeedX = Common.ApproachUniform(targetSpeedX, currentSpeedX, GroundAccel);
        else
            currentSpeedX = Common.ApproachUniform(targetSpeedX, currentSpeedX, AirAccel);

        if (currentSpeedY > MaxSpeedY)
            currentSpeedY = Common.ApproachUniform(MaxSpeedY, currentSpeedY, AirAccel);
        else if (currentSpeedY < -MaxSpeedY)
            currentSpeedY = Common.ApproachUniform(-MaxSpeedY, currentSpeedY, AirAccel);

        if (_onGround)
        {
            if (_kJumpDown)  //Jump
            {
                Debug.Log("jump");
                currentSpeedY += JumpSpeed;
            }
        }

        if (_playerBody.velocity.y > 0.0f && _kJumpRelease)
        {
            currentSpeedY *= 0.25f;
        }

        _playerBody.velocity = new Vector2(currentSpeedX, currentSpeedY);
    }

//    private void OnCollisionEnter2D(Collision2D col)
//    {
//        if (col.gameObject.CompareTag("Floor"))  //Está encostando no chão
//        {
//            _onGround = true;
//        }
//    }
//
//    private void OnCollisionExit2D(Collision2D col)
//    {
//        if (col.gameObject.CompareTag("Floor"))
//        {
//            _onGround = false;
//        }
//    }

}
