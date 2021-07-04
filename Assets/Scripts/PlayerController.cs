using UnityEngine;

public class PlayerController : MonoBehaviour
{
	[SerializeField]
	private float MoveSpeed = 10;

	private Vector3 Direction;
	private const float RaycastDistance = 1f;

	private CharacterController CharacterController;

	private bool AllowedToMoveForward = true;
	private bool AllowedToMoveBack = true;
	private bool AllowedToMoveLeft = true;
	private bool AllowedToMoveRight = true;

	// Start is called before the first frame update
	void Start()
	{
		CharacterController = GetComponent<CharacterController>();
	}

    // Update is called once per frame
    void Update()
	{
		if (AllowedToMoveForward && Input.GetAxisRaw("Vertical") > 0)
			Direction = Vector3.forward;
		if (AllowedToMoveBack && Input.GetAxisRaw("Vertical") < 0)
			Direction = Vector3.back;
		if (AllowedToMoveLeft && Input.GetAxisRaw("Horizontal") < 0)
			Direction = Vector3.left;
		if (AllowedToMoveRight && Input.GetAxisRaw("Horizontal") > 0)
			Direction = Vector3.right;

		CharacterController.Move(Direction * MoveSpeed * Time.deltaTime);
	}

	private void FixedUpdate()
	{
		var verticalPositions = new Vector3[] { transform.position, transform.position + new Vector3(0.5f, 0, 0), transform.position - new Vector3(0.5f, 0, 0) };
		AllowedToMoveForward = AllowedToMoveInDirection(Vector3.forward, verticalPositions);
		AllowedToMoveBack = AllowedToMoveInDirection(Vector3.back, verticalPositions);

		var horizontalPositions = new Vector3[] { transform.position, transform.position + new Vector3(0, 0, 0.5f), transform.position - new Vector3(0, 0, 0.5f) };
		AllowedToMoveLeft = AllowedToMoveInDirection(Vector3.left, horizontalPositions);
		AllowedToMoveRight = AllowedToMoveInDirection(Vector3.right, horizontalPositions);
	}

	private bool AllowedToMoveInDirection(Vector3 direction, Vector3[] positions)
	{
		foreach (var position in positions)
		{
			var ray = new Ray(position, direction);
			if (CollidingWithWall(ray))
				return false;
		}

		return true;
	}

	private bool CollidingWithWall(Ray ray)
	{
		if (Physics.Raycast(ray, out RaycastHit hit, RaycastDistance))
			return hit.collider.CompareTag("Wall");

		return false;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Ghost"))
			Destroy(gameObject);
	}
}
