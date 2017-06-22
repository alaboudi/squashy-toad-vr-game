using UnityEngine;
using System.Collections;

public class LaneSpawner : MonoBehaviour {

    ////version1:create lane prefabs array;
    //public GameObject[] lanePrefabs;

    //version2, 3: create specific lanes (safe, dangerous)
    public GameObject[] safeLanesPrefabs;
    public GameObject[] dangerousLanesPrefabs;
    enum LaneType { Safe, Dangerous };
    LaneType lastLaneType = LaneType.Safe;


    //version3
    public GameObject frog;
    public float laneSpawnDistance = 100;
    int offset = 0;
    

 //   //version1 + 2
	//// Use this for initialization
	//void Start () {
 //       int offset = 0;
 //       while (offset < 100)
 //       {
 //           CreateRandomLane(offset);
 //           offset += 10;
 //       }
 //   }
    
    


    public void CreateRandomLane(float offset)
    {
        ////version1: select a random lane
        ////select a random lane
        //int laneIndex = Random.Range(0, lanePrefabs.Length);
        //GameObject lane = Instantiate(lanePrefabs[laneIndex]);

        //version2 + 3: generate sequencial lanes
        GameObject lane;
        if (lastLaneType == LaneType.Safe)
        {
            lane = InstantiateRandomLane(dangerousLanesPrefabs);
            lastLaneType = LaneType.Dangerous;
        }
        else {
            lane = InstantiateRandomLane(safeLanesPrefabs);
            lastLaneType = LaneType.Safe;
        }

        //make the randomly generated lane a child of the lanespawner
        lane.transform.SetParent(transform, false);
        lane.transform.Translate(0, 0, offset);
    }

    GameObject InstantiateRandomLane(GameObject[] lanes) {
        int randomSelector = Random.Range(0,lanes.Length);
        GameObject lane = Instantiate(lanes[randomSelector]);
        return lane;
    }

    //version3: Check frog location for necessary lane spawning.
    // Update is called once per frame
    void Update () {
        
        //create a lane as we progress
        while (offset < laneSpawnDistance + frog.transform.position.z) {
            CreateRandomLane(offset);
            offset += 10;
        }


        //delete each lane that is far away
        foreach (Transform laneTransform in transform) {
            if (laneTransform.position.z + laneSpawnDistance < frog.transform.position.z)
            {
                //Destroy lane
                Destroy(laneTransform.gameObject);
            }
        }
        
	}
}
