using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeManager : MonoBehaviour
{
	public int LifeCount = 3;
	
	public void RemoveLife()
	{
		LifeCount--;
	}
}
