using System.Collections;
using UnityEngine;

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
	private GhostNavAgent GhostNavAgent;

	private Vector3 StartPosition;
	private Quaternion StartRotation;

	void Start()
	{
		Renderer = GetComponent<Renderer>();
		GhostNavAgent = GetComponent<GhostNavAgent>();

		StartPosition = transform.position;
		StartRotation = transform.rotation;
	}

	public void StartFleeState()
	{
		State = GhostState.Flee;
		Renderer.material = Blue;
		GhostNavAgent.Goal = GameObject.Find("Quadrants").GetComponent<GhostQuadrantHandler>().CurrentQuadrant;

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

		EndFleeState();
	}

	private void EndFleeState()
	{
		State = GhostState.Pursue;
		Renderer.material = DefaultMaterial;

		GhostNavAgent.ResetGoal();
	}

	public void Pause()
	{
		GhostNavAgent.enabled = false;
		enabled = false;
	}

	public void Respawn()
	{
		transform.position = StartPosition;
		transform.rotation = StartRotation;

		GhostNavAgent.enabled = true;
		enabled = true;
	}
}
