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
		// characters pause
		PauseCharacters();

		yield return new WaitForSeconds(5);
		ReadyText.enabled = true;
		// ReadyText shows, AND character positions reset, ghost timers reset
		GameObject.FindWithTag("Player").GetComponent<PlayerController>().ResetPosition();
		
		foreach (var ghostController in GameObject.FindGameObjectsWithTag("Ghost").Select(g => g.GetComponent<GhostController>()))
			ghostController.ResetPosition();
		
		GameObject.Find("Pellets").GetComponent<PelletPurveyor>().ResetPellets();
		
		yield return new WaitForSeconds(5);
		
		// unpause everyone, hide ReadyText 
		ReadyText.enabled = false;
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

		foreach (var ghostController in GameObject.FindGameObjectsWithTag("Ghost").Select(g => g.GetComponent<GhostController>()))
			ghostController.Respawn();

		GameObject.Find("Ghosts").GetComponent<GhostGatekeeperTimer>().ResetTimer();
	}
}
