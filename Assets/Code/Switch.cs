using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour {
    public GameObject door;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerStay(Collider other) {
        print(other.tag);
        if (other.tag == "Player") {
            if (Input.GetButtonDown("Jump")) {
                door.GetComponent<OpenDoor>().Open();
            }
        }
    }
}
