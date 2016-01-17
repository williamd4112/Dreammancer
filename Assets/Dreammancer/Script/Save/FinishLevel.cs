using UnityEngine;
using System.Collections;


namespace Dreammancer{
	public class FinishLevel : MonoBehaviour {

		public string LevelName;

		// Use this for initialization
		void Start () {
		
		}
		
		// Update is called once per frame
		void Update () {
		
		}

		public void OnTriggerEnter2D(Collider2D other){

			Debug.Log("ok!!!");

			if (other.GetComponent<DreammancerCharacter> () == null) {

				Debug.Log("something");
				return;
			}
			LevelManager.Instance.GotoNextLevel (LevelName);
		}
	}
}