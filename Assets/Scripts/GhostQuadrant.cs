using UnityEngine;

public class GhostQuadrant : MonoBehaviour
{
	[SerializeField] private Transform GhostTarget;
	
	private void OnTriggerEnter(Collider other)
	{
		gameObject.GetComponentInParent<GhostQuadrantHandler>().CurrentQuadrant = GhostTarget;
	}
}
