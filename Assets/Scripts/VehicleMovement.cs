using UnityEngine;
using System.Collections;

public class VehicleMovement : MonoBehaviour {

    public float vehicleSpeed;

	// Use this for initialization
	void Start () {
	
	}
	
	//// Update is called once per frame
	//void Update () {
 //       transform.Translate(-vehicleSpeed * Time.deltaTime, 0, 0);
 //   }

    void FixedUpdate()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.MovePosition(transform.position - transform.right * vehicleSpeed * Time.deltaTime);
    } 
}
