using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterMovement : MonoBehaviour {
    public Transform _target;
    public float maxSpeed;
    public bool inLight;
    public float health;
    public float lightDamage;

    NavMeshAgent agent;

	// Use this for initialization
	void Start () {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = maxSpeed;
	}
	
	// Update is called once per frame
	void Update () {
        agent.SetDestination(_target.position);

        NavMeshPath path = new NavMeshPath();
        agent.CalculatePath(_target.position, path);

        if (path.status != NavMeshPathStatus.PathComplete) {
            agent.SetDestination(transform.position);
        } else {
            agent.SetDestination(_target.position);
        }

        if (inLight) {
            health -= lightDamage;
            if (health <= 0) {
                Kill();
            }
        }
    }

    void Kill() {
        Destroy(this.gameObject);
    }

    private void OnTriggerStay(Collider other) {
        print("in light");

        if (other.tag == "Light") {
            inLight = true;
            agent.speed = maxSpeed / 2;
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.tag == "Light") {
            inLight = false;
            agent.speed = maxSpeed;
        }
    }
}
