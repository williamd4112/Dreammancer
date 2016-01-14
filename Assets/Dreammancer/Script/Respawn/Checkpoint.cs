using UnityEngine;
using System.Collections;

namespace Dreammancer{
	public class Checkpoint : MonoBehaviour {

		//public LevelManager levelManager;
		// Use this for initialization
		void Start () {
			
			//levelManager = FindObjectOfType<LevelManager> ();
	
			// Update is called once per frame
		}

		public void PlayerHitCheckpoint(){


		}
		private IEnumerator PlayerHitCheckpointCo(int bonus){
			yield break;
		}

		public void PlayerLeftCheckpoint(){

		}

		public void SpawnPlayer(DreammancerCharacter player){

			player.RespawnAt (transform);

		}

		public void AssignObjectToCheckpoint(){


		}
//		void Update () {
//		
//		}
//		void OnTriggerEnter2D(Collider2D other){
//			
//			if (other.name == "Player"){
//
//				levelManager.currentCheckpoint = gameObject;
//				Debug.Log("Active Checkpoint"+ transform.position);
//			}
//
//		}
	}
}