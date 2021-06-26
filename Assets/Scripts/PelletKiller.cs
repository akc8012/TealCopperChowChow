using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PelletKiller : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag.Equals("Player"))
		{
			GameObject.Find("ScoreKeeper").GetComponent<ScoreKeeper>().AddPoints(10);
			Destroy(gameObject);
		}
	}
}
