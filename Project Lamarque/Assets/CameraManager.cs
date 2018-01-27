using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour {

    [SerializeField]
    Shaker _shaker;

	// Use this for initialization
	void Start () {
        if (_shaker == null)
            _shaker = GetComponentInChildren<Shaker>();	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Shake()
    {
        _shaker.Shake();
    }
}
