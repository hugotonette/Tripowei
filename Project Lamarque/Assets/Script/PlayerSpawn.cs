using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSpawn : MonoBehaviour
{
    [System.NonSerialized]
    public int GenerationCount = 0;

    public Text GenerationText;
    public GameObject PlayerPrefab;
    public Transform NestTransform;
    private GameObject Egg;

    private void Awake()
    {
        GenerationText.text = ("Generation: " + GenerationCount);
    }

    private void Update()
    {
        if (!GameObject.FindGameObjectWithTag("Player"))
        {
            GenerationText.text = ("Generation: " + GenerationCount);
            if (!GameObject.FindGameObjectWithTag("Egg"))
            {
                Instantiate<GameObject>(PlayerPrefab, new Vector3(NestTransform.position.x, NestTransform.position.y, 0),
                new Quaternion(0, 0, 0, 0));
            }
            else
            {
                Egg = GameObject.FindGameObjectWithTag("Egg");
                Instantiate<GameObject>(PlayerPrefab, new Vector3(Egg.transform.position.x, Egg.transform.position.y, 0),
                new Quaternion(0, 0, 0, 0));
                Destroy(Egg);
            }
        }
    }

}
