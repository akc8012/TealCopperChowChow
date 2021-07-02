using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostController : MonoBehaviour
{
	[SerializeField]
	private float MoveSpeed = 8;

	private Vector3 Direction;
	
	private CharacterController CharacterController;
	
    // Start is called before the first frame update
	void Start()
	{
		Direction = new Vector3(0, 0, MoveSpeed);
		CharacterController = GetComponent<CharacterController>();
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
