using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeScene : MonoBehaviour
{
    public string NextSceneName;
    public float Timer = 1f;

    public Image img;

    IEnumerator WaitToChange()
    {
        yield return new WaitForSeconds(Timer);
        SceneManager.LoadScene(NextSceneName);
    }

    private void Awake()
    {
        StartCoroutine(WaitToChange());
    }
}
