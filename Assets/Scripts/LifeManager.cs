using UnityEngine;

public class LifeManager : MonoBehaviour
{
	public int LifeCount = 3;
	[SerializeField] private GameObject LifeManTop;
	[SerializeField] private GameObject LifeManBottom;
	
	public void RemoveLife()
	{
		LifeCount--;

		if (LifeCount == 2) 
			LifeManBottom.SetActive(false);
		
		if (LifeCount == 1)
			LifeManTop.SetActive(false);
		
		// todo: kill everything on 0
	}
}
