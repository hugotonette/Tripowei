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
        if (col.gameObject.CompareTag("Flammable"))
        {
            _newFire = Instantiate<GameObject>(FirePrefab, GameObject.FindGameObjectWithTag("Player").transform);
            _newFire.transform.parent = col.gameObject.transform;
            _newFire.transform.localPosition = new Vector3(0, 0, 0);
            Destroy(col.gameObject);
        }
        if (col.gameObject.CompareTag("Player"))
        {
            if (!GameObject.FindGameObjectWithTag("Player").transform.Find("Fire(Clone)"))
            {
                _canFire = true;
                if (_canFire)
                {
                    _newFire = Instantiate<GameObject>(FirePrefab, GameObject.FindGameObjectWithTag("Player").transform);
                    _newFire.transform.parent = GameObject.FindGameObjectWithTag("Player").transform;
                    _newFire.transform.localPosition = new Vector3(0, 0, 0);
                    _canFire = false;
                }
            }
            else
                _canFire = false;
        }
    }

}
