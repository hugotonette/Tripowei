using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{

    public GameObject PlayerPrefab;
    public Transform NestTransform;

    private void Update()
    {
        if (!GameObject.FindGameObjectWithTag("Player"))
        {
            Instantiate<GameObject>(PlayerPrefab, new Vector3(NestTransform.position.x, NestTransform.position.y, 0), new Quaternion(0, 0, 0, 0));
        }
    }

}
