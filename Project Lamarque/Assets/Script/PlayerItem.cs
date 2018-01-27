using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItem : MonoBehaviour
{
    public Collider2D InteractibleZone;

    private bool _canPickItem;

    private void Update()
    {
        if (_canPickItem)
        {
            if (Input.GetKeyDown(KeyCode.G))
            {

            }
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Item"))
            _canPickItem = true;
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Item"))
            _canPickItem = false;
    }
}
