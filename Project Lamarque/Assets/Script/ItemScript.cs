using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour
{
    public Collider2D InteractibleZone;
    public float PlayerXOffset;
    public float PlayerYOffset;

    private bool _canPickItem;
    private bool _holdingItem = false;
    private Transform _playerTransform;

    private void FixedUpdate()
    {
        if (_canPickItem && !_holdingItem)
        {
            if (Input.GetKeyDown(KeyCode.G))
            {
                Debug.Log("G");
                _holdingItem = !_holdingItem;
            }
        }

        if (_holdingItem)
        {
            transform.position = _playerTransform.position + new Vector3(PlayerXOffset, PlayerYOffset, 0);
            GetComponent<Rigidbody2D>().gravityScale = 0;
        }
        else
        {
            GetComponent<Rigidbody2D>().gravityScale = 1;
        }
    }

    private void Update()
    {
        if (!GameObject.FindGameObjectWithTag("Player"))
        {
            _canPickItem = false;
            _holdingItem = true;
        }
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        Debug.Log("Enter Item Range");
        if (col.gameObject.CompareTag("Player"))
        {
            _playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
            _canPickItem = true;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        Debug.Log("Exit Item Range");
        if (col.gameObject.CompareTag("Player"))
        {
            _playerTransform = null;
            _canPickItem = false;
        }
    }
}
