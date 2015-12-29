using UnityEngine;
using System.Collections;
namespace Dreammancer{
	public class BossSound : MonoBehaviour {
		public AudioClip[] sound;
		private AudioSource audio;
		// Use this for initialization
		void Start () {
			audio = this.GetComponent<AudioSource> ();
		}
		
		// Update is called once per frame
		void Update () {
		
		}

		public void PlayHurt(){
			//Debug.Log("PlayingHU");
			audio.PlayOneShot (sound [0], 1f);
		}

		public void PlayRay(){
			audio.PlayOneShot (sound [1], 1f);
		}

		public void PlayDie(){
			audio.PlayOneShot (sound [2], 1f);
		}
	}
}
