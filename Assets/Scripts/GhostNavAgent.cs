using UnityEngine;
using UnityEngine.AI;

public class GhostNavAgent : MonoBehaviour
{ 
	[SerializeField] Transform Goal;
	private NavMeshAgent NavMeshAgent;

	void Start()
	{
		NavMeshAgent = GetComponent<NavMeshAgent>();
	}

	void Update()
	{
		if (NavMeshAgent.enabled)
			NavMeshAgent.destination = Goal.position;
	}
}
