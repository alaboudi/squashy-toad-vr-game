using UnityEngine;
using System.Collections;

public class VehicleSpawner : MonoBehaviour {

    public GameObject vehiclePrefab;

    ////version1:
    //public float spawnInterval=2;

    //version2:
    public float spawnIntervalMin = 1;
    public float spawnIntervalMax = 5;

    ////version3: 
    //public float meanTime = 10;
    //public float minTime = 2;

    float nextSpawnTime = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        
        if (Time.time > nextSpawnTime) {
            Spawn();

            //version1: fixed interval
            //nextSpawnTime += spawnInterval;

            //version2: uniform random
            nextSpawnTime = Time.time + Random.Range(spawnIntervalMin, spawnIntervalMax);

            //version3 (Nerd!): Poisson ditribution with minTime fix
            //nextSpawnTime = Time.time + minTime + -Mathf.Log(Random.value) * meanTime;
        }
    }


    //function to spawn vehicles in the game
    void Spawn() {
        //instantiate the car into the world
        GameObject vehicle = Instantiate(vehiclePrefab);

        //fix transform according to spawner transform
        vehicle.transform.position = transform.position;
        vehicle.transform.rotation = transform.rotation;
        vehicle.transform.parent = transform;
    }
}
