using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrinkManager : MonoBehaviour {

	public float drunkenDecreaseRate = 0f;
	public float minFailureDrunkenAmount;
	public float minFailureDrunkenTime;
	public float maxFailureDrunkenAmount;
	public float maxFailureDrunkenTime;

	private float drunkenAmount = 0f;
	private float failureTimer = 0f;

	public void Drink(float amount) {
		drunkenAmount += amount;
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		drunkenAmount = Mathf.Clamp (drunkenAmount - Time.deltaTime * drunkenDecreaseRate, 0, 1);
		if (drunkenAmount < minFailureDrunkenAmount || drunkenAmount > maxFailureDrunkenAmount) {
			failureTimer += Time.deltaTime; 
			if (drunkenAmount < minFailureDrunkenAmount && failureTimer >= minFailureDrunkenTime) {
				// Lose
				Lose ();
			} else if (drunkenAmount > maxFailureDrunkenAmount && failureTimer >= maxFailureDrunkenTime) {
				// Lose again
				Lose ();
			}
		} else {
			failureTimer -= Time.deltaTime;
		}
	}

	void Lose() {

	}
}
