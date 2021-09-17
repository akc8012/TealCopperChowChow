using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

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
		GameObject.Find("ReadyToDie").GetComponent<Text>().enabled = true;
		yield return new WaitForSeconds(5);
		//TODO reset pieces without starting them
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
		GameObject.Find("ReadyToDie").GetComponent<Text>().enabled = false;
	}
}
