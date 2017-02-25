using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public float movementSpeed;

    private Rigidbody _rigidbody;

	// Use this for initialization
	void Start () {
        _rigidbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        //_rigidbody.velocity = new Vector3(Input.GetAxis("Horizontal") * movementSpeed * Time.deltaTime, _rigidbody.velocity.y, Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime);

        
        Vector3 newVelocity = new Vector3(Input.GetAxis("Horizontal") * movementSpeed * Time.deltaTime, _rigidbody.velocity.y, Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime);

        _rigidbody.velocity = newVelocity;

        transform.Rotate(0, Input.GetAxis("Right Horizontal") + Input.GetAxis("Mouse X"), 0);
    }

    void FixedUpdate() {
        
    }
}
