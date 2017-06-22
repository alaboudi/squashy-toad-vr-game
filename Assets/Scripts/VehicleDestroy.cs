using UnityEngine;
using System.Collections;

public class VehicleDestroy : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    /**
     * This script helps detect a objects colliding into it.
     * When an object collides with the trigger, destroy it from the world!
     */
    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.GetComponentInParent<Rigidbody>().gameObject);
    }
}
