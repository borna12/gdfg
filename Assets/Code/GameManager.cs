using UnityEngine;
using System.Collections;
using System;
public class GameManager 
{
	private static GameManager _instance;
	public static GameManager Instance{ get { return _instance ?? (_instance=new GameManager()); } }
	public int Points { get; private set;}
	int pointsToCheckpoint=0;

	private GameManager(){

	}

	public void Reset()
	{}

	public void ResetPoints(int points)
	{
		Points = points;
	
		}
	
	public void AddPoints(int pointsToAdd)
	{
		Points += pointsToAdd;

	}

}