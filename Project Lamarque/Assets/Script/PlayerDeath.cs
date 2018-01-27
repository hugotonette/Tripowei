using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDeath : MonoBehaviour
{
    public float DeathTimer = 10f;

    IEnumerator TimeToDie(float timer)
    {
        Debug.Log("Start");
        yield return new WaitForSeconds(timer);
        Debug.Log("Death");
        Destroy(this.gameObject);
    }

    private void Awake()
    {
        StartCoroutine(TimeToDie(DeathTimer));
    }

    private void Update()
    {
        Debug.Log(Mathf.Round(DeathTimer - Time.time));
    }
}
