using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateTerrain : MonoBehaviour {


	public GameObject terrainGenerator;
	int terrainBlockWidth;
	public int numTerrainBlocks;
	float randSeed;
	private static string GENERATOR_PREFIX = "Generator_";
	private static string FIRST_GRASS  = "Generator_0_GRASS_0";



	void Start () {
		terrainBlockWidth = terrainGenerator.GetComponent<Generate> ().width;
		randSeed = Random.Range (-1000f, 1000);
		CreateTerrain ();
	
	}
	
	void CreateTerrain () {

		int lastX = -terrainBlockWidth;


		for(int i=0;i<numTerrainBlocks;i++) {
			string generatorName = GENERATOR_PREFIX + i;
			GameObject newTerrainBlock = Instantiate(terrainGenerator,new Vector3(lastX+terrainBlockWidth,0f),Quaternion.identity) as GameObject;
			newTerrainBlock.name = generatorName;
			newTerrainBlock.GetComponent<Generate>().randSeed = randSeed;
			lastX += terrainBlockWidth;
		}
	}
}
