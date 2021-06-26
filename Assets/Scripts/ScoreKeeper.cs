using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour
{
	private Text ScoreText;
	private int Score;
	
    // Start is called before the first frame update
    void Start()
	{
		ScoreText = GetComponent<Text>();
	}

    // Update is called once per frame
    void Update()
    {
        
    }

	public void AddPoints(int points)
	{
		Score += points;
		ScoreText.text = Score.ToString();
	}
}
