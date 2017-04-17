using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class TankController : NetworkBehaviour {
	public float MoveSpeed = 150.0f;
	public float RotateSpeed = 3.0f;
	public Color LocalPlayerColor;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (!isLocalPlayer) {
			return;
		}
		var x = Input.GetAxis("Horizontal") * Time.deltaTime * MoveSpeed;
		var z = Input.GetAxis("Vertical") * Time.deltaTime * RotateSpeed;

		transform.Rotate(0, x, 0);
		transform.Translate(0, 0, z);

	}

	public override void OnStartLocalPlayer(){
		var tankParts = GetComponentsInChildren<MeshRenderer>();
		foreach (var part in tankParts) {
			part.material.color = LocalPlayerColor;
		}
	}
}
