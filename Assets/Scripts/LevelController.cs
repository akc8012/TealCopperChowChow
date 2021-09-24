using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{
	private Text ReadyText;

	private void Start()
	{
		ReadyText = GameObject.Find("ReadyToDie").GetComponent<Text>();
		StartCoroutine(nameof(StartGameCoroutine));
	}

	private IEnumerator StartGameCoroutine()
	{
		PauseCharacters();
		ReadyText.enabled = true;
		
		yield return new WaitForSeconds(5);
		ReadyText.enabled = false;
		UnpauseCharacters();
	}

	public void NextLevel() => StartCoroutine(nameof(StartLevelCoroutine));

	private IEnumerator StartLevelCoroutine()
	{
		PauseCharacters();

		yield return new WaitForSeconds(5);
		ReadyText.enabled = true;
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

	private void UnpauseCharacters()
	{
		GameObject.FindWithTag("Player").GetComponent<PlayerController>().Unpause();
		GameObject.Find("Pellets").GetComponent<PelletPurveyor>().ResetPellets();

		foreach (var ghostController in GameObject.FindGameObjectsWithTag("Ghost").Select(g => g.GetComponent<GhostController>()))
			ghostController.Respawn();

		GameObject.Find("Ghosts").GetComponent<GhostGatekeeperTimer>().ResetTimer();
		ReadyText.enabled = false;
	}
}
