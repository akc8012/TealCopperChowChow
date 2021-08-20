using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

public enum GhostState
{
	Pursue,
	Flee
}

public class GhostController : MonoBehaviour
{
	[SerializeField]
	private Material DefaultMaterial;
	[SerializeField]
	private Material Blue;
	[SerializeField]
	private Material White;

	public GhostState State { get; private set; } = GhostState.Pursue;

	private Renderer Renderer;
	private NavMeshAgent NavMeshAgent;

	private Vector3 StartPosition;
	private Quaternion StartRotation;

	void Start()
	{
		Renderer = GetComponent<Renderer>();
		NavMeshAgent = GetComponent<NavMeshAgent>();

		StartPosition = transform.position;
		StartRotation = transform.rotation;
	}

	public void SetState(GhostState state)
	{
		State = state;
		Renderer.material = Blue;

		StopCoroutine(nameof(FleeRoutine));
		StartCoroutine(nameof(FleeRoutine));
	}

	private IEnumerator FleeRoutine()
	{
		yield return new WaitForSeconds(6.5f);
	
		Renderer.material = White;
		yield return new WaitForSeconds(.3f);
		
		Renderer.material = Blue;
		yield return new WaitForSeconds(.3f);
		
		Renderer.material = White;
		yield return new WaitForSeconds(.3f);
		
		Renderer.material = Blue;
		yield return new WaitForSeconds(.3f);
		
		Renderer.material = White;
		yield return new WaitForSeconds(.3f);

		State = GhostState.Pursue;
		Renderer.material = DefaultMaterial;
	}

	public void Pause()
	{
		NavMeshAgent.enabled = false;
		enabled = false;
	}

	public void Respawn()
	{
		transform.position = StartPosition;
		transform.rotation = StartRotation;

		NavMeshAgent.enabled = true;
		enabled = true;
	}
}
