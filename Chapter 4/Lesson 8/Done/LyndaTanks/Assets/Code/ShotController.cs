using UnityEngine;
using System.Collections;

public class ShotController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Destroy (gameObject, 2);
	}
	
	void OnCollisionEnter(Collision other){
		Destroy (gameObject);
	}
}
