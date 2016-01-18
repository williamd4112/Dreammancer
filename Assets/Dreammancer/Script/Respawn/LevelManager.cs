using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Dreammancer{
	public class LevelManager : MonoBehaviour{

		public static LevelManager Instance{ get;private set;}

		public DreammancerCharacter Player{get;private set;}
		//public Camera camera {get;private;set;}

		private List<Checkpoint> _checkpoints;
		private int _currentCheckpointIndex;

		public Checkpoint DebugSpawn;
		// Use this for initialization
		public void Awake(){
			Instance = this;
		}
		public void Start () {
//			
			_checkpoints = FindObjectsOfType<Checkpoint> ().OrderBy(t => t.transform.position.x).ToList();
			_currentCheckpointIndex = _checkpoints.Count > 0 ? 0 : -1;

			Player = FindObjectOfType<DreammancerCharacter> ();
			//Camera = FindObjectOfType

#if UNITY_EDITOR
			if (DebugSpawn != null) {
				DebugSpawn.SpawnPlayer (Player);
			} else if (_currentCheckpointIndex != -1) {
				_checkpoints[_currentCheckpointIndex].SpawnPlayer(Player);
			}
#else
			if (_currentCheckpointIndex != -1) {
				_checkpoints[_currentCheckpointIndex].SpawnPlayer(Player);
			}
#endif
		}
		
		// Update is called once per frame
		public void Update () {

			var isAtLastCheckpoint = _currentCheckpointIndex + 1 >= _checkpoints.Count;
			if (isAtLastCheckpoint)
				return;

			var distanceToNextCheckpoint = _checkpoints [_currentCheckpointIndex + 1].transform.position.x - Player.transform.position.x;
			if (distanceToNextCheckpoint >= 0)
				return;

			_checkpoints [_currentCheckpointIndex].PlayerLeftCheckpoint ();
			_currentCheckpointIndex++;
			_checkpoints [_currentCheckpointIndex].PlayerHitCheckpoint ();

			// TODO: time bonus
		}

		public void GotoNextLevel (string levelName){

			StartCoroutine (GotoNextLevelCo (levelName));
		}

		private IEnumerator GotoNextLevelCo(string levelName){

			Player.FinishLevel ();
			//Time.timeScale = 0;
			yield return new WaitForSeconds (0.5f);

			if (string.IsNullOrEmpty (levelName))
				Application.LoadLevel ("StartScene");
			else
				Application.LoadLevel (levelName);

		}

		public void KillPlayer(){

			StartCoroutine (KillPlayerCo ());
		}
		private IEnumerator KillPlayerCo(){

			Player.Kill ();
			yield return new WaitForSeconds (0.2f);

			if (_currentCheckpointIndex != -1) {
				_checkpoints[_currentCheckpointIndex].SpawnPlayer(Player);

				//TODO: points
			}
		}

	}
}