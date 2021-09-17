using System.Collections.Generic;
using UnityEngine;

public class PelletPurveyor : MonoBehaviour
{
	private List<GameObject> Pellets;
	private bool AllEaten;

    void Start()
	{
		Pellets = new List<GameObject>();
		foreach (Transform child in transform) 
			Pellets.Add(child.gameObject);
	}

    public void PelletEaten()
	{
		if (AllPelletsEaten())
			GameObject.Find("LevelController").GetComponent<LevelController>().NextLevel();
	}

	private bool AllPelletsEaten()
	{
		foreach (var pellet in Pellets)
		{
			if (pellet.activeSelf)
				return false;
		}

		return true;
	}

	public void ResetPellets()
	{
		foreach (var pellet in Pellets) 
			pellet.SetActive(true);
	}
}

