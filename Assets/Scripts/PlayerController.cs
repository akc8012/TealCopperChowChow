using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	[SerializeField]
	private float MoveSpeed = 10;

	private Vector3 Direction;

	private CharacterController CharacterController;
	
    // Start is called before the first frame update
    void Start()
	{
		CharacterController = GetComponent<CharacterController>();
	}

    // Update is called once per frame
    void Update()
	{
		Vector3 lastDirection = Direction;
		Vector3 lastPosition = transform.position;

		if (Input.GetAxisRaw("Vertical") > 0)
			Direction = new Vector3(0, 0, MoveSpeed);
		if (Input.GetAxisRaw("Vertical") < 0)
			Direction = new Vector3(0, 0, -MoveSpeed);
		if (Input.GetAxisRaw("Horizontal") < 0)
			Direction = new Vector3(-MoveSpeed, 0, 0);
		if (Input.GetAxisRaw("Horizontal") > 0)
			Direction = new Vector3(MoveSpeed, 0, 0);

		CharacterController.Move(Direction * Time.deltaTime);

		if (lastPosition == transform.position)
		{
			Direction = lastDirection;
			CharacterController.Move(Direction * Time.deltaTime);
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Ghost"))
			Destroy(gameObject);
	}
}
