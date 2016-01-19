using UnityEngine;
using System.Collections;


namespace Dreammancer{
	public class InstaKill : MonoBehaviour {
	
		public void OnTriggerEnter2D(Collider2D other){
			if (!other.CompareTag ("Player")) {
                other.gameObject.GetComponent<Health>().decreaseHealth(100);
			}

			var player = other.GetComponent<DreammancerCharacter> ();
			if (player == null)
				return;

			LevelManager.Instance.KillPlayer ();
		}

		// Use this for initialization
		void Start () {
		
		}
		
		// Update is called once per frame
		void Update () {
		
		}
	}
}