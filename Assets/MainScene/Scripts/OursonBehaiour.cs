using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class OursonBehaiour : MonoBehaviour
{
    public GameObject player;
    public NavMeshAgent agent;

    void Start ()
    {
        
	}
	
	void Update ()
    {
        agent.SetDestination(player.transform.position);
    }
}
