using UnityEngine;
using System.Collections;

namespace Dreammancer
{
	public class Bullet : MonoBehaviour {
		
		private GameObject boss;
		private Animator m_animator;
		// Use this for initialization
		void Start () {
			m_animator = this.GetComponent<Animator> ();
			boss = GameObject.Find("Boss");
		}
		
		// Update is called once per frame
		void Update () {
			
		}
		
		void OnTriggerEnter2D(Collider2D other){
			//Debug.Log ("HIT");
			if (other.gameObject.tag == "Player") {
				//Debug.Log ("HIT PLAYER");
				//Debug.Log ("hey");
			}
			m_animator.SetTrigger("Explo");
		}
		
		void OnCollisionEnter2D(Collision2D other){
			//Debug.Log ("HIT");
			if (other.gameObject.tag == "Player") {
				//Debug.Log ("HIT PLAYER");
				//Debug.Log ("hey");
				//Debug.Log(gameObject.layer);
				//Debug.Break();
			}
			//Debug.Log (other.gameObject);
			m_animator.SetTrigger("Explo");
		}
		
		//void OnCollisionStay2
		
		void DestroyBu(){
			this.GetComponent<Rigidbody2D> ().velocity = new Vector2(0,0);
			this.gameObject.SetActive (false);
			boss.GetComponent<BossShoot> ().buList.Enqueue (this.gameObject);
			//this.GetComponentInParent<BossShoot> ().buList.Enqueue (this.gameObject);
		}
	}
}
