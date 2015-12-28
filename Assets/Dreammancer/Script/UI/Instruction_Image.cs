using UnityEngine;
using System.Collections;


namespace Dreammancer
{
	public class Instruction_Image : MonoBehaviour {


		public GameObject billboard;
		// Use this for initialization
		void Start () {
			billboard.SetActive(false);
		}
		
		// Update is called once per frame
		void Update () {
			//billboard.SetActive(false);
		}
		void OnTriggerEnter2D(Collider2D other){
			//Debug.Log ("HIT!!");
			if (other.gameObject.tag == "Player") {
				billboard.SetActive(true);
			}
			
		}
		void OnTriggerExit2D(Collider2D other){
			if (other.gameObject.tag == "Player") {
				billboard.SetActive(false);
			}
		}
	}
}