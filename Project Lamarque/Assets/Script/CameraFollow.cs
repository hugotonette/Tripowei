using UnityEngine;

public class CameraFollow : MonoBehaviour {

    private GameObject player;
    public Vector3 offset;
    private bool reSnap = true;
    void Update() {
        if (reSnap)
        {
            player = GameObject.FindGameObjectWithTag("Player");
            reSnap = false;
        }
        if (!GameObject.FindGameObjectWithTag("Player"))
        {
            reSnap = true;
        }
        transform.position = player.transform.position + offset;
	}
}
