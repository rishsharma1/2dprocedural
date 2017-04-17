using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generate : MonoBehaviour {


	public GameObject dirtObject;
	public GameObject grassObject;

	public int width;
	public float heightFactor;
	public int dirtThreshold;
	public float smoothness;
	public int heigthAdd;

	[HideInInspector]
	public float randSeed;


	void Start () {
		GeneratePlatfrom ();
	}
	

	public void GeneratePlatfrom() {

		for(int i=0; i < width; i++) {

			int h = Mathf.RoundToInt(Mathf.PerlinNoise(randSeed,(i+transform.position.x)/smoothness)*heightFactor)+heigthAdd;

			for(int j=0; j < h; j++) {
				
				GameObject newTile;

				if (j < h - dirtThreshold) {
					newTile = dirtObject;
				} else {
					newTile = grassObject;
				}

				Instantiate(newTile,new Vector3(i+transform.position.x,j), Quaternion.identity);

			}
		}


	}
}
