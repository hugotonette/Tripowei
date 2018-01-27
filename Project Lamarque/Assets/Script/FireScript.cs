using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireScript : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Flammable"))
        {
            //Animation Here
            Destroy(col.gameObject);
        }
    }

}
