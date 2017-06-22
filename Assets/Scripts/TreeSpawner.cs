using UnityEngine;
using System.Collections;

public class TreeSpawner : MonoBehaviour {

    public GameObject TreePrefab;

    //version 2: use with random tree spawning
    public int minTrees = 5;
    public int maxTrees = 15;

    // Use this for initialization
    void Start () {

        ////version 1:  manually call trees to produce
        //CreateTree();
        //CreateTree();

        //create a random amount of trees
        int treesToSpawn = Random.Range(minTrees, maxTrees);
        for (int treeCounter = 0; treeCounter < treesToSpawn; treeCounter++)
        {
            CreateTree();
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    /**
     * Create a tree at a random position in comparison to its parent
     */
    public void CreateTree() {
        GameObject tree = Instantiate(TreePrefab);
        tree.transform.parent = transform;
        tree.transform.localPosition = new Vector3(Random.Range(-50, 50), -0.5f, Random.Range(-5,5));
    }
}
