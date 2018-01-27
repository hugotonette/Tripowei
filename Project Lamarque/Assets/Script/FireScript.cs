using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireScript : MonoBehaviour
{
    public GameObject FirePrefab;

    private GameObject _newFire;
    private bool _canFire = true;

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Flammable") && !col.gameObject.CompareTag("Player"))
        {
            //Animation Here
            Destroy(col.gameObject);
        }
        if (col.gameObject.CompareTag("Player"))
        {
            //Player on fire animation

            if (!GameObject.FindGameObjectWithTag("Player").transform.Find("Fire(Clone)"))
            {
                _canFire = true;
                if (_canFire)
                {
                    _newFire = Instantiate<GameObject>(FirePrefab, GameObject.FindGameObjectWithTag("Player").transform);
                    _newFire.transform.parent = GameObject.FindGameObjectWithTag("Player").transform;
                    _canFire = false;
                }
            }
            else
                _canFire = false;
        }
    }

}
