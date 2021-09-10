using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class InkyPointRandomizer : MonoBehaviour
{
	[SerializeField] private float MinZBound;
	[SerializeField] private float MaxZBound;

	[SerializeField] private float XBound;
	[SerializeField] private float WaitTime;

	private Transform Inky;

	private void Start()
	{
		Inky = GameObject.Find("Inky").transform;

		StartCoroutine(nameof(Randomize));
	}

	private void Update()
	{
		if (Vector3.Distance(transform.position, Inky.position) < 1)
		{
			StopCoroutine(nameof(Randomize));
			StartCoroutine(nameof(Randomize));
		}
	}

	private IEnumerator Randomize()
	{
		while (true)
		{
			transform.position = new Vector3(Random.Range(-XBound, XBound), transform.position.y,Random.Range(MinZBound, MaxZBound));
			yield return new WaitForSeconds(WaitTime);
		}
	}
}
