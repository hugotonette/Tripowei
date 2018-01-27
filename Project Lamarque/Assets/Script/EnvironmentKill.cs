using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentKill : MonoBehaviour {

    public void Death(GameObject ThingToDestroy)
    {
        Debug.Log("bam");
        Destroy(ThingToDestroy);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Player"))
            Destroy(other.gameObject);
    }
}
