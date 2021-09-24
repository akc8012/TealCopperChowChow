using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerPellet : MonoBehaviour
{
	private Renderer Renderer;
    // Start is called before the first frame update
    void OnEnable()
	{
		Renderer = GetComponent<Renderer>();
		StartCoroutine(nameof(BlinkRoutine));
	}
	
	private IEnumerator BlinkRoutine()
	{
		while (true)
		{
			Renderer.enabled = !Renderer.enabled;
			yield return new WaitForSeconds(.3f);
		}
	}
}
