using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextSceneScript : MonoBehaviour
{
    public string NextScene;
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
            if (NextScene.Length == 0)
                Debug.Log("Insert Scene Here");
            else
                SceneManager.LoadScene(NextScene);
    }

    public void NextSceneButton(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

}
