using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Health : NetworkBehaviour {

	public int maxHealth = 100;

	[SyncVar(hook="OnHealthChange")]
	public int currentHealth;

	public Text HealthScore;

	void Start(){
		currentHealth = maxHealth;
		HealthScore.text = currentHealth.ToString();

	}

	void Update(){
		
	}

	public void TakeDamage(int amount)
	{
		if (!isServer) {
			return;
		}
		currentHealth -= amount;
		if (currentHealth <= 0)
		{
			currentHealth = 0;
			Debug.Log("Dead!");
			HealthScore.text = currentHealth.ToString();
		}
	}

	void OnHealthChange(int updatedHealth){
		Debug.Log ("OnHealthChange called");
		HealthScore.text = updatedHealth.ToString ();
	}
}