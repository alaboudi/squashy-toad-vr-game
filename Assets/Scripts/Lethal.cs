using UnityEngine;
using System.Collections;

public class Lethal : MonoBehaviour {

    //find the death componenet attached to the frog
    Death deathComponent;

    private void Start()
    {
        deathComponent = FindObjectOfType<Death>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        deathComponent.onDeath();
    }
}
