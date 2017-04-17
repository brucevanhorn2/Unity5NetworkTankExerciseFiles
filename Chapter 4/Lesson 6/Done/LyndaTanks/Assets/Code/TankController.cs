using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class TankController : NetworkBehaviour {
	public float MoveSpeed = 150.0f;
	public float RotateSpeed = 3.0f;
	public Color LocalPlayerColor;
	public GameObject ShotPrefab;
	public Transform ShotSpawnTransform;
	public float ReloadRate = 0.5f;
	public float ShotSpeed;
	private float _nextShotTime;
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

		if (Input.GetKeyDown (KeyCode.Space)) {
			var bullet = Instantiate(ShotPrefab, ShotSpawnTransform.position, Quaternion.identity) as GameObject;
			bullet.GetComponent<Rigidbody>().velocity = transform.forward * ShotSpeed;
		}

	}

	public override void OnStartLocalPlayer(){
		var tankParts = GetComponentsInChildren<MeshRenderer>();
		foreach (var part in tankParts) {
			part.material.color = LocalPlayerColor;
		}
	}
}
