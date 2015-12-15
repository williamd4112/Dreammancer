using UnityEngine;
using System.Collections;

namespace Dreammancer
{
	public class Bullet : MonoBehaviour {

		// Use this for initialization
		void Start () {
		
		}
		
		// Update is called once per frame
		void Update () {
		
		}

		void OnCollisionEnter2D(Collision2D other){
			//Debug.Log ("HIT");
			if (other.gameObject.tag == "Player") {
				//Debug.Log ("HIT PLAYER");
				//Debug.Log ("hey");
				Destroy (this.gameObject);
			}

		}
	}
}
