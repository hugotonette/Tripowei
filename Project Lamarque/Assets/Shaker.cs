using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shaker : MonoBehaviour {

    public bool ShakeTestTrigger = false;

    public float Duration = 1f, Magnitude = 1f;

	// Use this for initialization
	void Start ()
    {
        ShakeTestTrigger = false;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (ShakeTestTrigger == true)
        {
            ShakeTestTrigger = false;
            Shake();
        }
    }

    public void Shake()
    {
        StartCoroutine(ShakeMovement(Duration, Magnitude));
    }

    IEnumerator ShakeMovement(float duration, float magnitude)
    {
        float elapsed = 0.0f;

        Vector3 startlocalPos = this.transform.localPosition;

        while (elapsed < duration)
        {

            elapsed += Time.deltaTime;

            float percentComplete = elapsed / duration;
            float damper = 1.0f - Mathf.Clamp(4.0f * percentComplete - 3.0f, 0.0f, 1.0f);

            // map value to [-1, 1]
            float x = UnityEngine.Random.value * 2.0f - 1.0f;
            float y = UnityEngine.Random.value * 2.0f - 1.0f;
            x *= magnitude * damper;
            y *= magnitude * damper;

            transform.localPosition = startlocalPos + new Vector3(x, y, 0f);

            yield return null;
        }

        transform.localPosition = startlocalPos;
    }
}
