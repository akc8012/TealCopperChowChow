using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class InkyPointRandomizer : MonoBehaviour
{
	[SerializeField] protected float MinZBound;
	[SerializeField] protected float MaxZBound;

	[SerializeField] protected float MinXBound;
	[SerializeField] protected float MaxXBound;
	[SerializeField] private float WaitTime;

	protected Transform Target;

	protected virtual void Start()
	{
		Target = GameObject.Find("Inky").transform;
		StartCoroutine(nameof(Randomize));
	}

	protected virtual void Update()
	{
		if (Vector3.Distance(transform.position, Target.position) < 1)
		{
			StopCoroutine(nameof(Randomize));
			StartCoroutine(nameof(Randomize));
		}
	}

	private IEnumerator Randomize()
	{
		while (true)
		{
			transform.position = new Vector3(Random.Range(MinXBound, MaxXBound), transform.position.y, Random.Range(MinZBound, MaxZBound));
			yield return new WaitForSeconds(WaitTime);
		}
	}
}
