using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabbable : MonoBehaviour
{

    public float PlayerXOffset;
    public float PlayerYOffset;

    Rigidbody2D _rb;
    GrabSkill _holder ;

    Vector2 _startPos;
    float _startRot;

    // Use this for initialization
    void Start()
    {
        _rb = this.GetComponent<Rigidbody2D>();

        _startPos = this.transform.position;
        _startRot = _rb.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsHeld())
        {
            this.transform.position = _holder.transform.position + new Vector3(PlayerXOffset, PlayerYOffset,0.0f);
        }
    }

    public void Hold(GrabSkill holder)
    {
        print(gameObject.name + " was held");
        _rb.simulated = false;

        _holder = holder;
    }

    public Rigidbody2D GetRigidBody2d()
    {
        return _rb;
    }

    public void Release()
    {
        print(gameObject.name + " was released");
        _rb.simulated = true;

        _holder = null;
    }

    public bool IsHeld()
    {
        if (_holder != null)
            return true;
        else
            return false;
    }

    public void Respawn() // Não vai ser usado, por enquanto.
    {
        if (_holder != null)
        {
            _holder.ReleaseItem(false);
        }

        _rb.velocity = Vector2.zero;

        _rb.MovePosition(_startPos);
        _rb.MoveRotation(_startRot);
    }
}
