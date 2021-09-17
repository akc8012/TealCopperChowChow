using System.Collections;
using System.Linq;
using UnityEngine;

public class LevelController : MonoBehaviour
{
	private void Start()
	{
		NextLevel();
	}

	public void NextLevel() => StartCoroutine(nameof(StartLevelCoroutine));

	private IEnumerator StartLevelCoroutine()
	{
		PauseCharacters();

		yield return new WaitForSeconds(5);
		
		UnpauseCharacters();
	}

	private void PauseCharacters()
	{
		GameObject.FindWithTag("Player").GetComponent<PlayerController>().Pause();
		foreach (var ghostController in GameObject.FindGameObjectsWithTag("Ghost").Select(g => g.GetComponent<GhostController>()))
			ghostController.Pause();
	}

	private static void UnpauseCharacters()
	{
		GameObject.FindWithTag("Player").GetComponent<PlayerController>().Unpause();
		GameObject.Find("Pellets").GetComponent<PelletPurveyor>().ResetPellets();

		foreach (var ghostController in GameObject.FindGameObjectsWithTag("Ghost").Select(g => g.GetComponent<GhostController>()))
			ghostController.Respawn();

		GameObject.Find("Ghosts").GetComponent<GhostGatekeeperTimer>().ResetTimer();
	}
}
