using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Checkpoint : MonoBehaviour {

	private List<IPlayerRespawnListener> _listners;
	public void Awake(){
		_listners = new List<IPlayerRespawnListener> ();
	}

	public void PlayerHitCheckpoint()
	{StartCoroutine(PlayerHitCheckpointCo(LevelManager.Instance.CurrentTimeBonus));
		}

	private IEnumerator PlayerHitCheckpointCo(int bonus)
	{
		FloatingText.Show ("Checkpoint!","CheckpointText", new CenteredTextPositioner(.3f));
        yield return new WaitForSeconds (.5f);
		FloatingText.Show (string.Format ("+{0} time bonus!",bonus), "CheckpointText", new CenteredTextPositioner (.3f));
	}

	public void PlayerLeftCheckpoint()
	{}

	public void SpawnPlayer (Player player)
	{
		player.RespawnAt (transform);

		foreach (var listener in _listners)
			listener.OnPlayerRespawnInThicCheckpoint (this, player);
	}

	public void AssignObjectToCheckpoint(IPlayerRespawnListener listner)
	{
	
		_listners.Add (listner);
	}
}
