using UnityEngine;
using System.Collections;

public class Death : MonoBehaviour {

    public GameObject UICanvas;
    public GameObject Reticle;

    public void onDeath() {
        //show the canvas
        UICanvas.SetActive(true);
        Reticle.SetActive(true);

        //turn the frog kinematic to remove physics
        GetComponent<Rigidbody>().isKinematic = true;
    }
}
