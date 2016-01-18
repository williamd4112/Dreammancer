using UnityEngine;
using System.Collections;

namespace Dreammancer{
	public class SecBossSound : MonoBehaviour {
		public AudioClip[] sound;
		private AudioSource m_audio;
		// Use this for initialization
		void Start () {
			m_audio = this.GetComponent<AudioSource> ();
		}
		
		// Update is called once per frame
		void Update () {
		
		}
		public void PlayReadyToShoot(){
			m_audio.loop = false;
			m_audio.PlayOneShot (sound [1], 0.5f);
		}

		public void PlayRay(){
			m_audio.loop = false;
			m_audio.PlayOneShot (sound [0], 0.5f);
		}

		public void PlayTransport(){
			//Debug.Log ("Transportting");
			m_audio.PlayOneShot (sound [2], 0.5f);
		}

        public void PlayExplo()
        {
            m_audio.PlayOneShot(sound[3], 1f);
        }

        public void PlayHurt()
        {
            m_audio.PlayOneShot(sound[4], 1f);
        }

		public void Pause(){
			m_audio.Pause ();
		}
	}
}
