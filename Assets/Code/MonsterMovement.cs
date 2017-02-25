using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterMovement : MonoBehaviour {
    public Transform _target;

    NavMeshAgent agent;

	// Use this for initialization
	void Start () {
        agent = GetComponent<NavMeshAgent>();
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
    }
}
