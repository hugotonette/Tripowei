using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabSkill : MonoBehaviour {

    public float MinSpeedToThrow = 0.1f;
    public float ThrowForce = 10f;

    List<Grabbable> _itensOnReach;
    Grabbable _itemBeingHeld;

    Rigidbody2D _playerRb; // Para calcular arremesso.

	// Use this for initialization
	void Start () {
        _itensOnReach = new List<Grabbable>();

        _playerRb = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetButtonDown("Grab") && CanHold())
        {
            if (_itensOnReach.Count > 0)
                GrabItem(_itensOnReach[0]);        
        }		
        if (Input.GetButtonUp("Grab") && _itemBeingHeld != null)
        {
            ReleaseItem();
        }
	}


    void GrabItem(Grabbable item)
    {
        _itemBeingHeld = item;
        _itemBeingHeld.Hold(this);
    }


    public void ReleaseItem(bool enableThrow = true)
    {
        if (_itemBeingHeld != null) // e sempre deveria ser...
        {
            _itemBeingHeld.Release();

            //Throw
            if (Mathf.Abs(_playerRb.velocity.x) > MinSpeedToThrow && enableThrow == true)
            {
                _itemBeingHeld.GetRigidBody2d().velocity = new Vector2(1f * Mathf.Sign(_playerRb.velocity.x), 1f).normalized * ThrowForce;
            }

            _itemBeingHeld = null;
        }
    }


    bool CanHold()
    {
        if (_itemBeingHeld != null)
            return false;
        else
            return true;
    }

    private void OnDestroy()
    {
        ReleaseItem(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Item"))
        {
            Grabbable item = collision.GetComponent<Grabbable>();
            if (!_itensOnReach.Contains(item))
                _itensOnReach.Add(collision.GetComponent<Grabbable>());
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Item"))
        {
            _itensOnReach.Remove(collision.GetComponent<Grabbable>());
        }
    }
}
