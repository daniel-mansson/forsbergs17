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
    public float aggroDistance;
    public float distance;

    NavMeshAgent agent;
    public ShadowScript shadow;

    // Use this for initialization
    void Start() {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = maxSpeed;
    }

    // Update is called once per frame
    void Update() {
        agent.SetDestination(_target.position);

        NavMeshPath path = new NavMeshPath();
        agent.CalculatePath(_target.position, path);

        if (path.status != NavMeshPathStatus.PathComplete) {
            agent.SetDestination(transform.position);
        } else {
            agent.SetDestination(_target.position);
        }

        distance = Vector3.Distance(this.transform.position, _target.position);

        if (distance > aggroDistance) {
            agent.SetDestination(transform.position);
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
            shadow.setLightState(true);
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.tag == "Light") {
            inLight = false;
            agent.speed = maxSpeed;
            shadow.setLightState(false);
        }
    }
}
