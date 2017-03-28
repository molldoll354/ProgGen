using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pathmaker : MonoBehaviour
{
	private int counter = 0;
	public static int GlobalTileCount = 500;
	public Transform floorPrefab;
	public Transform bunnyPrefab;
	public Transform rockPrefab;
	public Transform pathmakerSpherePF;
	float randoNumber;
	float straightChance;
	float turnChance;
	// Use this for initialization
	void Start ()
	{
		straightChance = .3f;
		turnChance = .5f;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (GlobalTileCount <= 500) {
			if (counter < GlobalTileCount) {
				randoNumber = Random.Range (0.0f, 1.0f);
				if (randoNumber < straightChance) {
					if (randoNumber < turnChance) {
						transform.Rotate (0f, 90f, 0f);
					} else {
						transform.Rotate (0f, -90f, 0f);
					}
				}
				if (randoNumber < .3f) {
					Instantiate (floorPrefab, transform.position, Quaternion.identity);
				} else if (.3f < randoNumber && randoNumber < .6f) {
					Instantiate (bunnyPrefab, transform.position, Quaternion.identity);
				} else if (randoNumber > .6f) {
					Instantiate (rockPrefab, transform.position, Quaternion.identity);
				}
				transform.Translate (Vector3.forward * 5);
				counter++;
			}
		} else {
			Destroy (gameObject);
		}
	}
}
