using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour {
    public Vector3 closedPos;
    public Vector3 openPos;

    public float lerpTime = 1f;
    public bool IsOpen;

    float currentLerpTime;

    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {

        //increment timer once per frame
        currentLerpTime += Time.deltaTime;
        if (currentLerpTime > lerpTime) {
            currentLerpTime = lerpTime;
        }

        //lerp!
        float perc = currentLerpTime / lerpTime;

        if (IsOpen) {
            transform.position = Vector3.Lerp(closedPos, openPos, perc);
        } else {
            transform.position = Vector3.Lerp(openPos, closedPos, perc);
        }
    }
    
 
    public void Open() {
        //transform.position = IsOpen ? closedPos : openPos;
        IsOpen = !IsOpen;
        
        currentLerpTime = 0f;
    }
}
