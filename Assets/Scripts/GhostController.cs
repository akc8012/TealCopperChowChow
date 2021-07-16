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
	private float MoveSpeed = 8;
	[SerializeField]
	private Material Pink;
	[SerializeField]
	private Material Blue;

	[SerializeField]
	private Material White;

	public GhostState State { get; private set; } = GhostState.Pursue;

	private Vector3 Direction;
	private Renderer Renderer;

	private CharacterController CharacterController;

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
		Renderer.material = Pink;
	}

	// Start is called before the first frame update
	void Start()
	{
		Direction = new Vector3(0, 0, MoveSpeed);
		CharacterController = GetComponent<CharacterController>();
		Renderer = GetComponent<Renderer>();
	}

    // Update is called once per frame
    void Update()
	{
		CharacterController.Move(Direction * Time.deltaTime);
    }

	private void OnControllerColliderHit(ControllerColliderHit hit)
	{
		if (hit.collider.CompareTag("Wall")) 
			CollideWithWall();
	}

	private void CollideWithWall()
	{
		if (Direction.z < 0)
		{
			Direction.x = -MoveSpeed;
			Direction.z = 0;
		}
		else if (Direction.z > 0)
		{
			Direction.x = MoveSpeed;
			Direction.z = 0;
		}
		else if (Direction.x < 0)
		{
			Direction.x = 0;
			Direction.z = MoveSpeed;
		}
		else if (Direction.x > 0)
		{
			Direction.x = 0;
			Direction.z = -MoveSpeed;
		}
	}
}
