using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    public float DeathTimer = 10f;
    public GameObject DeadBody;

    IEnumerator TimeToDie(float timer)
    {
        Debug.Log("Start");
        yield return new WaitForSeconds(timer);
        Debug.Log("Death");
        Death(true);
    }

    public void Death(bool notDangerZone)
    {
        if (notDangerZone)
            InstantiateDeadBody();
        GameObject.Find("GameManager").GetComponent<PlayerSpawn>().GenerationCount++;
        Destroy(gameObject);
    }

    public void InstantiateDeadBody()
    {
        Instantiate<GameObject>(DeadBody, new Vector3(transform.position.x, transform.position.y, 0f), new Quaternion(0, 0, 0, 0));
    }

    private void Awake()
    {
        StartCoroutine(TimeToDie(DeathTimer));
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Enemy"))
            Death(true);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("DangerZone"))
            Death(false);
    }
}
