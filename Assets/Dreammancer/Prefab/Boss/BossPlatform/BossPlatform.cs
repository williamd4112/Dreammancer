using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Dreammancer{
	public class BossPlatform : MonoBehaviour {

		private GameObject boss;
		// Use this for initialization
		void Start () {
			boss = GameObject.Find ("Boss");
		}
		
		// Update is called once per frame
		void Update () {
		
		}

		void OnCollisionEnter2D(Collision2D other){
			//Debug.Log ("HIT");
			if (other.gameObject.tag == "DestroyZone") {
				this.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, 0);
				this.gameObject.SetActive (false);
				this.GetComponentInParent<BossShoot> ().boList.Enqueue (this.gameObject);
			}
		}

		void OnTriggerEnter2D(Collider2D other){
			if (other.gameObject.tag == "DestroyZone") {
				this.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, 0);
				this.gameObject.SetActive (false);
				boss.GetComponent<BossShoot>().boList.Enqueue (this.gameObject);
			}
		}
	}
}
