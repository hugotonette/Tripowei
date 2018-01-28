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

    Animator _animator;
    bool _isFacingRight = false;    

    private Rigidbody2D _playerBody;
    private bool _onGround;

    float _axisHorizontal;
    bool _kJumpDown, _kJumpRelease;

    private void Awake()
    {
        _playerBody = GetComponent<Rigidbody2D>();

        _kJumpDown = false;
        _kJumpRelease = false;

        _animator = GetComponent<Animator>();
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

        if (Mathf.Abs(_playerBody.velocity.x) > 0.01f)
            _animator.SetBool("IsMoving", true);
        else
            _animator.SetBool("IsMoving", false);

        if (_onGround)
        {
            _animator.SetBool("IsJumping", false);
        }
        else
            _animator.SetBool("IsJumping", true);

        if (_playerBody.velocity.x > 3f && !_isFacingRight)
        {
            Flip(true);
        }
        else if (_playerBody.velocity.x < -3f && _isFacingRight)
        {
            Flip(false);
        }

    }

    private void FixedUpdate()
    {
        //Nothing...
    }

    void Flip(bool faceRight)
    {
        _isFacingRight = faceRight;

        if (_isFacingRight)
            transform.localScale = new Vector3(-1f, 1f, 1f);
        else
            transform.localScale = new Vector3(1f, 1f, 1f);
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
                //Debug.Log("jump");
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
