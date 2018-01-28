using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LiveTimerSlider : MonoBehaviour
{
    public Text LiveTimer;

    private float _maxTime;
    private float _time;

    private void Awake()
    {
        _time = 0;
        _maxTime = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerDeath>().DeathTimer;
    }

    private void Update()
    {
        _time += Time.deltaTime;
        LiveTimer.text = ("Tempo de vida: ") + (Mathf.Round(_maxTime - _time)).ToString();
    }

    private float CalculateTime(float maxTime, float currentTime)
    {
        return currentTime / maxTime;
    }

    public void RestartTimer()
    {
        _time = 0;
    }
}
