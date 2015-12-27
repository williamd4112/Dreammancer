using UnityEngine;
using System.Collections;

namespace Dreammancer
{
	public class Bullet : MonoBehaviour {

		private Animator m_animator;
		// Use this for initialization
		void Start () {
			m_animator = this.GetComponent<Animator> ();
		}
		
		// Update is called once per frame
		void Update () {
		
		}

		void OnTriggerEnter2D(Collider2D other){
			//Debug.Log ("HIT");
			if (other.gameObject.tag == "Player") {
				//Debug.Log ("HIT PLAYER");
				//Debug.Log ("hey");
				m_animator.SetTrigger("Explo");
			}
		}

		void OnCollisionStay2D(Collision2D other){
			//Debug.Log ("HIT");
			if (other.gameObject.tag == "Player") {
				//Debug.Log ("HIT PLAYER");
				//Debug.Log ("hey");
				Debug.Log(gameObject.layer);
			}
			Debug.Log (other.gameObject);
			Destroy (this.gameObject);
			m_animator.SetTrigger("Explo");
		}

		//void OnCollisionStay2

		void DestroyBu(){
			Destroy (this.gameObject);
		}
	}
}
