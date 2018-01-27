using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    public float DeathTimer = 10f;

    IEnumerator TimeToDie(float timer)
    {
        Debug.Log("Start");
        yield return new WaitForSeconds(timer);
        Debug.Log("Death");
        Death();
    }

    public void Death()
    {
        GameObject.Find("GameManager").GetComponent<PlayerSpawn>().GenerationCount++; 
        Destroy(this.gameObject);
    }

    private void Awake()
    {
        StartCoroutine(TimeToDie(DeathTimer));
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Enemy"))
            Death();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("DangerZone"))
            Death();
    }
}
