using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LifeManager : MonoBehaviour
{
	private int LifeCount = 3;
	[SerializeField] private GameObject LifeManTop;
	[SerializeField] private GameObject LifeManBottom;
	
	public bool TryRemoveLife()
	{
		LifeCount--;

		if (LifeCount == 2) 
			LifeManBottom.SetActive(false);
		
		if (LifeCount == 1)
			LifeManTop.SetActive(false);
		
		if (LifeCount == 0)
			StartCoroutine(nameof(ResetScene));

		return LifeCount > 0;
	}

	private IEnumerator ResetScene()
	{
		GameObject.Find("GameOver").GetComponent<Text>().enabled = true;
		
		yield return new WaitForSeconds(4);
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
}
