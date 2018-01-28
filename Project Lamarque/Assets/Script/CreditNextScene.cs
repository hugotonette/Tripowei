using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditNextScene : MonoBehaviour
{
    public string NextScene;

    private void Update()
    {
        if (Input.anyKeyDown)
        {
            SceneManager.LoadScene(NextScene);
        }
    }
}