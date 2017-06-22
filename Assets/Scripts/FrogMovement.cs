using UnityEngine;
using System.Collections;

public class FrogMovement : MonoBehaviour {

    ////use with version 2 
    //public Vector3 jumpVelocity;

    ////use with version 3
    //public float jumpAngle = 45;
    //public float jumpSpeed = 5;
    //int collisionCounter = 0;

    //use with version 4
    public float jumpAngle = 45;
    public float[] jumpSpeed = {2, 4, 6};
    int collisionCounter;
    int jumpCounter = 0;

    // Use this for initialization
    void Start () {
	    
	}

    

    // Update is called once per frame
    void Update () {

        /**
         * Check if the jump button was called, if so make the frog jump in the projected 
         * forward direction. Ensure that you only make a instantaneous velocity change to the frog.
         * VR players may feel sick otherwise.
         */

        ////version 1: without public field
        //if (GvrViewer.Instance.Triggered)
        //{
        //    Rigidbody rb = GetComponent<Rigidbody>();
        //    rb.AddForce(new Vector3(0, 1, 2), ForceMode.VelocityChange);
        //}



        ////version 2: with public field settings
        //if (GvrViewer.Instance.Triggered) {
        //    Rigidbody rb = GetComponent<Rigidbody>();
        //    rb.AddForce(jumpVelocity, ForceMode.VelocityChange);
        //}



        ////version 3: no jumping in the air and jumping in look direction.
        //Rigidbody rb = GetComponent<Rigidbody>();
        //bool isOnGround = collisionCounter > 0;

        //if (GvrViewer.Instance.Triggered && isOnGround) {

        //    //get the camera's forward projection on the plane
        //    Camera camera = GetComponentInChildren<Camera>();
        //    Vector3 projectedForwardDirection = Vector3.ProjectOnPlane(camera.transform.forward, Vector3.up);

        //    //translate projected forward to jump direction
        //    float jumpRadian = Mathf.Deg2Rad * jumpAngle;
        //    Vector3 unnormalizedJump = Vector3.RotateTowards(projectedForwardDirection, Vector3.up, jumpRadian, 0);

        //    //make the frog jump
        //    rb.AddForce(unnormalizedJump.normalized * jumpSpeed, ForceMode.VelocityChange);
        //}


        //version4: let's allow for double and triple jumps
        Rigidbody rb = GetComponent<Rigidbody>();
        bool isOnGround = collisionCounter > 0;

        //reset  jump counter if the frog is the ground
        if (isOnGround) {
            jumpCounter = 0;
        }

        if (GvrViewer.Instance.Triggered && jumpCounter < jumpSpeed.Length)
        {

            //get the camera's forward projection on the plane
            Camera camera = GetComponentInChildren<Camera>();
            Vector3 projectedForwardDirection = Vector3.ProjectOnPlane(camera.transform.forward, Vector3.up);

            //translate projected forward to jump direction
            float jumpRadian = Mathf.Deg2Rad * jumpAngle;
            Vector3 unnormalizedJump = Vector3.RotateTowards(projectedForwardDirection, Vector3.up, jumpRadian, 0);

            //make the frog jump
            rb.AddForce(unnormalizedJump.normalized * jumpSpeed[jumpCounter], ForceMode.VelocityChange);

            jumpCounter++;
        }
    }


    //increment jump counter if an object collides with our frog. This implies its on the floor
    private void OnCollisionEnter(Collision collision)
    {
        collisionCounter++;
    }

    private void OnCollisionExit(Collision collision)
    {
        collisionCounter--;
    }


}
