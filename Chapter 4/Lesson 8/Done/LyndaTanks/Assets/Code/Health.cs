using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Health : MonoBehaviour {

	public int maxHealth = 100;
	public int currentHealth;
	public Text HealthText;

	void Start(){
		currentHealth = maxHealth;
	}

	void Update(){
		HealthText.text = currentHealth.ToString();
	}

	public void TakeDamage(int amount)
	{
		currentHealth -= amount;
		if (currentHealth <= 0)
		{
			currentHealth = 0;
			Debug.Log("Dead!");
		}
	}
}