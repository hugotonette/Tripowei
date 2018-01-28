using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerDeath : MonoBehaviour
{
    public float DeathTimer = 10f;

    private float timer;

    Animator _animator;

    IEnumerator TimeToDie(float timer)
    {
        Debug.Log("Start");
        yield return new WaitForSeconds(timer);
        Debug.Log("Death");
        Death(true);
    }

    public void Death(bool notDangerZone)
    {
        GameObject.Find("GameManager").GetComponent<PlayerSpawn>().GenerationCount++;
        GameObject.Find("GameManager").GetComponent<LiveTimerSlider>().RestartTimer();

        CameraManager cameraManager = FindObjectOfType<CameraManager>();
        if (cameraManager != null)
            cameraManager.Shake();

        _animator.SetTrigger("Dead");

        Destroy(gameObject);
    }

    void DestroyItself()
    {
        Destroy(gameObject);
    }
    
    private void Awake()
    {
        _animator = GetComponent<Animator>();
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
