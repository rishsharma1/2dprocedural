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

	private static string DIRT_PREFIX = "_DIRT_";
	private static string GRASS_PREFIX = "_GRASS_";
	private static string FIRST_GRASS  = "Generator_0_GRASS_0";



	void Start () {
		GeneratePlatfrom ();
	}
	

	public void GeneratePlatfrom() {

		int grassCounter = 0;
		int dirtCounter = 0;

		for(int i=0; i < width; i++) {

			int h = Mathf.RoundToInt(Mathf.PerlinNoise(randSeed,(i+transform.position.x)/smoothness)*heightFactor)+heigthAdd;

			for(int j=0; j < h; j++) {
				
				GameObject newTile;

				if (j < h - dirtThreshold) {
					newTile = dirtObject;
					newTile.name = this.name + DIRT_PREFIX + dirtCounter;
					dirtCounter += 1;

				} else {

					newTile = grassObject;
					newTile.name = this.name + GRASS_PREFIX + grassCounter;


					if (newTile.name == FIRST_GRASS) {
						Player player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player>();
						player.setPlayerPosition ((float)j);
					}
					grassCounter += 1;

				}

				Instantiate(newTile,new Vector3(i+transform.position.x,j), Quaternion.identity);

			}
		}


	}
}
