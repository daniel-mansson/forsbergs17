using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public float movementSpeed;
    public float lampRotationSpeed;
    public float lampRotationLimitMin;
    public float lampRotationLimitMax;
    public GameObject _headLight;

    private Rigidbody _rigidbody;

	public float m_soundFreq = 0.1f;
	public float m_soundVolume = 0.1f;
	float m_timeSinceLastSound = 0f;

	// Use this for initialization
	void Start () {
        _rigidbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        //_rigidbody.velocity = new Vector3(Input.GetAxis("Horizontal") * movementSpeed * Time.deltaTime, _rigidbody.velocity.y, Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime);

        
        Vector3 newVelocity = new Vector3(
			Input.GetAxis("Horizontal") * movementSpeed, _rigidbody.velocity.y, 
			Input.GetAxis("Vertical") * movementSpeed);

        _rigidbody.velocity = newVelocity;

		m_timeSinceLastSound += Time.deltaTime;
		if (m_timeSinceLastSound > m_soundFreq)
		{
			float v = newVelocity.magnitude * m_soundVolume;
			AudioManager.Play("playermove", transform.position, v);

			m_timeSinceLastSound -= m_soundFreq;
		}

        float newXRot = _headLight.transform.rotation.eulerAngles.x + Input.GetAxis("Right Vertical") + Input.GetAxis("Mouse Y") * lampRotationSpeed * Time.deltaTime;
        if (newXRot < lampRotationLimitMin) {
            newXRot = lampRotationLimitMin;
        } else if (newXRot > lampRotationLimitMax) {
            newXRot = lampRotationLimitMax;
        }

        float newYRot = _headLight.transform.rotation.eulerAngles.y + Input.GetAxis("Right Horizontal") + Input.GetAxis("Mouse X") * lampRotationSpeed * Time.deltaTime;

        _headLight.transform.rotation = Quaternion.Euler(newXRot, newYRot, 0);
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "Monster") {
            Kill();
        }
    }

    void Kill() {
        Destroy(this.gameObject);
    }
}
