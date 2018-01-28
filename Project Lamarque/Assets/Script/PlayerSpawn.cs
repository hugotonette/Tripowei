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
    public GameObject EggPrefab;

    private void Awake()
    {
        GenerationText.text = ("Marvin da " + GenerationCount + "° Geração");
    }

    private void Update()
    {
        if (!GameObject.FindGameObjectWithTag("Player"))
        {
<<<<<<< HEAD
            GenerationText.text = ("Marvin da " + GenerationCount + "° Geração");
            if (!GameObject.FindGameObjectWithTag("Egg"))
=======
            GenerationText.text = ("Generation: " + GenerationCount);

            EggPrefab = GameObject.FindGameObjectWithTag("Egg");
            Instantiate<GameObject>(PlayerPrefab, new Vector3(EggPrefab.transform.position.x, EggPrefab.transform.position.y, 0),
                new Quaternion(0, 0, 0, 0));

            EggPrefab.transform.position = NestTransform.transform.position;


            /*if (!GameObject.FindGameObjectWithTag("Egg"))
>>>>>>> ec12e5587173394168845b7b9f0cee14a85fa06a
            {
                Instantiate<GameObject>(PlayerPrefab, new Vector3(NestTransform.position.x, NestTransform.position.y, 0),
                new Quaternion(0, 0, 0, 0));
            }
            else
            {
                EggPrefab = GameObject.FindGameObjectWithTag("Egg");
                Instantiate<GameObject>(PlayerPrefab, new Vector3(EggPrefab.transform.position.x, EggPrefab.transform.position.y, 0),
                new Quaternion(0, 0, 0, 0));
                Destroy(EggPrefab);
            }*/
        }
    }
}
