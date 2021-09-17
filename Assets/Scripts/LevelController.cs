using System.Collections;
using System.Linq;
using UnityEngine;

public class LevelController : MonoBehaviour
{
	public void NextLevel()
	{
		StartCoroutine(nameof(NextLevelRoutine));
	}

	private IEnumerator NextLevelRoutine()
	{
		GameObject.FindWithTag("Player").GetComponent<PlayerController>().Pause();
		foreach (var ghostController in GameObject.FindGameObjectsWithTag("Ghost").Select(g => g.GetComponent<GhostController>()))
			ghostController.Pause();
		
		yield return new WaitForSeconds(2);
		
		GameObject.FindWithTag("Player").GetComponent<PlayerController>().Unpause();
		GameObject.Find("Pellets").GetComponent<PelletPurveyor>().ResetPellets();
		
		foreach (var ghostController in GameObject.FindGameObjectsWithTag("Ghost").Select(g => g.GetComponent<GhostController>()))
			ghostController.Respawn();
		
		GameObject.Find("Ghosts").GetComponent<GhostGatekeeperTimer>().ResetTimer();
	}
}
