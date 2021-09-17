using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GhostGatekeeperTimer : MonoBehaviour
{
	private GhostNavAgent[] Ghosts;
	
    void Start()
	{
		Ghosts = GetComponentsInChildren<GhostNavAgent>();
	}

	private IEnumerator GatekeeperTimer()
	{
		EnableGhost("Blinky");
		EnableGhost("Pinky");

		yield return new WaitForSeconds(5);
		EnableGhost("Inky");
		
		yield return new WaitForSeconds(10);
		EnableGhost("Clyde");
	}

	private void EnableGhost(string ghostName) => Ghosts.First(g => g.gameObject.name == ghostName).enabled = true;

	public void ResetTimer()
	{
		StopTimer();
		StartCoroutine(nameof(GatekeeperTimer));
	}
	
	public void StopTimer() => StopCoroutine(nameof(GatekeeperTimer));
}
