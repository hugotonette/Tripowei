using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flammable : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Fire"))
        {
            Debug.Log("Burn Baby Burn");
            //Animação do fogo aqui
            Destroy(gameObject);
        }
    }
}
