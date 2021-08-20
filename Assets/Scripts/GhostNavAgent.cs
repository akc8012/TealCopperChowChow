using UnityEngine;
using UnityEngine.AI;

public class GhostNavAgent : MonoBehaviour
{ 
	[SerializeField] Transform Goal;
	private NavMeshAgent Agent;

	void Start()
	{
		Agent = GetComponent<NavMeshAgent>();
	}

	void Update()
	{
		Agent.destination = Goal.position;
	}
}
