using System;
using UnityEngine;
using UnityEngine.AI;

public class GhostNavAgent : MonoBehaviour
{
	public Transform Goal;
	private NavMeshAgent NavMeshAgent;

	void Awake() => NavMeshAgent = GetComponent<NavMeshAgent>();

	void Update() => NavMeshAgent.destination = Goal.position;

	private void OnEnable() => NavMeshAgent.enabled = true;

	private void OnDisable() => NavMeshAgent.enabled = false;
}

