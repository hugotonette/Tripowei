using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireScript : MonoBehaviour
{
    public GameObject FirePrefab;
    public float BurnTime;

    private GameObject _newFire;
    private bool _canFire = true;

    IEnumerator Burning(float time, GameObject objToBurn)
    {
        InstantiateFire(objToBurn);
        yield return new WaitForSeconds(time);
        Destroy(objToBurn);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Flammable"))
        {
            Burning(BurnTime, col.gameObject);
        }
        if (col.gameObject.CompareTag("Player"))
        {
            if (!GameObject.FindGameObjectWithTag("Player").transform.Find("Fire(Clone)"))
            {
                _canFire = true;
                if (_canFire)
                {
                    _canFire = false;
                    _newFire = Instantiate<GameObject>(FirePrefab, GameObject.FindGameObjectWithTag("Player").transform);
                    _newFire.transform.parent = GameObject.FindGameObjectWithTag("Player").transform;
                    _newFire.transform.localPosition = new Vector3(0, 0, 0);
                    //_canFire = false;
                }
            }
            else
                _canFire = false;
        }
    }

    private void InstantiateFire(GameObject objToBurn)
    {
        _newFire = Instantiate<GameObject>(FirePrefab, GameObject.FindGameObjectWithTag("Player").transform);
        _newFire.transform.parent  = objToBurn.transform;
        _newFire.transform.localPosition = new Vector3(0, 0, 0);
    }
}
