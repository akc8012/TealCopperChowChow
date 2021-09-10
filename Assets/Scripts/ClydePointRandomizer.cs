using UnityEngine;

public class ClydePointRandomizer : InkyPointRandomizer
{
	[SerializeField] float DistanceFromPlayer;
	private Transform Player;
	
	protected override void Start()
	{
		base.Start();
		
		Target = GameObject.Find("Clyde").transform;
		Player = GameObject.FindWithTag("Player").transform;
	}
	
    protected override void Update()
	{
		base.Update();
		MinZBound = Player.position.z - DistanceFromPlayer;
		MaxZBound = Player.position.z + DistanceFromPlayer;
		
		MinXBound = Player.position.x - DistanceFromPlayer;
		MaxXBound = Player.position.x + DistanceFromPlayer;
	}
}
