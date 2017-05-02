using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratePlatform : MonoBehaviour {


	public GameObject platform;
	public Transform generationPoint;

	public float distanceApartMax;
	public float distanceApartMin;


	private float platformWidth;


	void Start() {
		platformWidth = platform.GetComponent<BoxCollider2D>().size.x;

	}

	void Update() {

		// if true create some new platforms
		if(transform.position.x < generationPoint.position.x) {

			float distanceApart = Random.Range(distanceApartMin,distanceApartMax);

			transform.position = new Vector3(transform.position.x+platformWidth+distanceApart,
											 transform.position.y,transform.position.z);
			Instantiate(platform,transform.position,transform.rotation);
		}

	}
}
