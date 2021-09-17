using UnityEngine;

public class PelletKiller : MonoBehaviour
{
	[SerializeField]
	private int Points = 10;
	
	private void OnTriggerEnter(Collider other)
	{
		if (other.tag.Equals("Player"))
		{
			GameObject.Find("ScoreKeeper").GetComponent<ScoreKeeper>().AddPoints(Points);

			if (gameObject.name.Contains("PowerPellet"))
			{
				foreach (GameObject ghost in GameObject.FindGameObjectsWithTag("Ghost"))
					ghost.GetComponent<GhostController>().StartFleeState();
			}

			gameObject.SetActive(false);
			GameObject.Find("Pellets").GetComponent<PelletPurveyor>().PelletEaten();
		}
	}
}
