using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportBox : MonoBehaviour
{
	[SerializeField]
	private Transform TeleportPoint;

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
			other.gameObject.GetComponent<PlayerController>().SetPosition(TeleportPoint.position);
	}
}
