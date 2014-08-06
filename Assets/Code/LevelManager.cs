using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
	public static LevelManager Instance { get; private set;}

	public Player Player { get; private set;}
	public CameraController Camera { get; private set;}
	public TimeSpan RunningTime {get{return DateTime.UtcNow - _started;}}

	public int CurrentTimeBonus
	{
		get{
			var secondDifference=(int)(BonusCutOffSeconds-Time.timeSinceLevelLoad);
			return Mathf.Max(0, secondDifference)*BonusSecondMultiplier;
		}
	}

	private List<Checkpoint> _Checkpoints;
	private int _currentCheckpointIndex;
	private DateTime _started;
	private int _savedPoints;

	public Checkpoint DebugSpawn;
	public int BonusCutOffSeconds;
	public int BonusSecondMultiplier;


	public void Awake()
	{
	    _savedPoints = GameManager.Instance.Points;
		Instance = this;
	}
	public void Start()
	{
				_Checkpoints = FindObjectsOfType<Checkpoint> ().OrderBy (t => t.transform.position.x).ToList ();
				_currentCheckpointIndex = _Checkpoints.Count > 0 ? 0 : -1;

				Player = FindObjectOfType<Player> ();
				Camera = FindObjectOfType<CameraController> ();

				_started = DateTime.UtcNow;

		var listners = FindObjectsOfType<MonoBehaviour> ().OfType<IPlayerRespawnListener> ();
				foreach (var listener in listners) {
						for (var i = _Checkpoints.Count -1; i >=0; i--) {
								var distance = ((MonoBehaviour)listener).transform.position.x - _Checkpoints [i].transform.position.x;
								if (distance < 0)
										continue;
				
								_Checkpoints[i].AssignObjectToCheckpoint (listener);
								break;
						}
				}


#if UNITY_EDITOR
						if (DebugSpawn != null)
								DebugSpawn.SpawnPlayer (Player);
						else if (_currentCheckpointIndex != -1)
								_Checkpoints [_currentCheckpointIndex].SpawnPlayer (Player);
#else
		if (_currentCheckpointIndex!=-1)
			_Checkpoints[_currentCheckpointIndex].SpawnPlayer(Player);
#endif
				
		}
	public void Update(){
		var isAtLastCheckpoint = _currentCheckpointIndex + 1 >= _Checkpoints.Count;
		if (isAtLastCheckpoint)
						return;
		var distanceToNextCheckpoint = _Checkpoints [_currentCheckpointIndex + 1].transform.position.x - Player.transform.position.x;
		if (distanceToNextCheckpoint >=0)
			return;

		_Checkpoints [_currentCheckpointIndex].PlayerLeftCheckpoint ();
		_currentCheckpointIndex++;
		_Checkpoints [_currentCheckpointIndex].PlayerHitCheckpoint ();

		GameManager.Instance.AddPoints (CurrentTimeBonus);
		_savedPoints = GameManager.Instance.Points;
		_started = DateTime.UtcNow;

	
		}


    public void GoToNextLevel(string levelName)

    {
    
        StartCoroutine(GoToNextLevelCo(levelName));
    }

    private IEnumerator GoToNextLevelCo(string levelName)
    {
        Player.FinishLevel();
        GameManager.Instance.AddPoints(CurrentTimeBonus);
        FloatingText.Show("Level completed", "CheckpointText", new CenteredTextPositioner(0.1f));
        yield return new WaitForSeconds(1);
        FloatingText.Show(string.Format("{0} points!", GameManager.Instance.Points), "CheckpointText", new CenteredTextPositioner(.1f));
        yield return new WaitForSeconds(5f);

        if (string.IsNullOrEmpty(levelName))
            Application.LoadLevel("StartScreen");
        else
        {
            Application.LoadLevel(levelName);
        }

    }

    public void KillPlayer(){

		StartCoroutine(KillPlayerCo());

	}

	private IEnumerator KillPlayerCo()
	{
		Player.Kill ();
		Camera.IsFollowing = false;
		yield return new WaitForSeconds (2f);
		
		Camera.IsFollowing = true;
		
		if (_currentCheckpointIndex != -1)
			_Checkpoints [_currentCheckpointIndex].SpawnPlayer (Player);

		_started = DateTime.UtcNow;
		GameManager.Instance.ResetPoints (_savedPoints);
	}

}
