using UnityEngine;
using System.Collections;


namespace Dreammancer{
	public class UFOsound : MonoBehaviour {
		
		public Rigidbody2D rb;
		public AudioClip move;
		public int statetype=0;
		public bool flag = false;
		public float speed;
		private bool isMoving = false;
		private AudioSource m_move; // Source for the walk sounds
		private bool m_StartedSound; // flag for knowing if we have started sounds
		private DreammancerObject m_DreamObj;
		
		void Start(){
			m_DreamObj = this.GetComponent<DreammancerObject> ();
			rb = this.GetComponent<Rigidbody2D> ();
			Debug.Log("Fuck!!");
		}
		
		private void StartSound()
		{
			//rb = this.GetComponent<Rigidbody2D> ();
			if(statetype==1){
				m_move = SetUpEngineAudioSource(move);
			}
			m_StartedSound = true;
		}
		
		private void StopSound()
		{
			//Destroy all audio sources on this object:
			foreach (AudioSource source in GetComponents<AudioSource>())
			{
				Destroy(source);
			}
			m_StartedSound = false;
		}
		void Update()
		{
			speed = rb.velocity.magnitude;
			if (!flag) {
				StartSound ();
				flag = true;
			}

			Debug.Log (speed);
		}
		// sets up and adds new audio source to the gane object
		private AudioSource SetUpEngineAudioSource(AudioClip clip)
		{
			// create the new audio source component on the game object and set up its properties
			AudioSource source = gameObject.AddComponent<AudioSource>();
			source.clip = clip;
			source.loop = true;
			source.Play();
			return source;
		}
	}
}
