using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggSpawn : MonoBehaviour
{
    public GameObject EggPrefab;

    private bool _canSpawnEgg = false;

    private void Update()
    {
        if (_canSpawnEgg)
            if (Input.GetKeyDown(KeyCode.G))
            {
                Debug.Log("ping");
                Instantiate<GameObject>(EggPrefab);
            }

    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            if (!GameObject.FindGameObjectWithTag("Egg"))
                _canSpawnEgg = true;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            _canSpawnEgg = false;
        }
    }
}
