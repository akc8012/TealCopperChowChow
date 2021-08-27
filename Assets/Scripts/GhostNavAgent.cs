using System;
using UnityEngine;
using UnityEngine.AI;

public class GhostNavAgent : MonoBehaviour
{
	public Transform Goal;
	private NavMeshAgent NavMeshAgent;
	private Transform StartGoal;

	void Awake()
	{
		NavMeshAgent = GetComponent<NavMeshAgent>();
		StartGoal = Goal;
	}

	public void ResetGoal() => Goal = StartGoal;

	void Update() => NavMeshAgent.destination = Goal.position;

	private void OnEnable() => NavMeshAgent.enabled = true;

	private void OnDisable() => NavMeshAgent.enabled = false;
}
