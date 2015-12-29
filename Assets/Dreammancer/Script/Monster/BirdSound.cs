using UnityEngine;
using System.Collections;


namespace Dreammancer{
	public class BirdSound : MonoBehaviour {
		
		public AudioClip idle;
		public AudioClip fly;
		public int flag = 0;
		public int statetype=0;
		
		private bool isFlying = false;
		private bool isIdle = false;
		
		private AudioSource m_fly; // Source for the walk sounds
		private AudioSource m_idle; //
		
		private bool m_StartedSound; // flag for knowing if we have started sounds
		
		private Animator anim;
		//int jumpStateHash = Animator.StringToHash("Jumping");
		int walkStateHash = Animator.StringToHash("birds_fly");
		//int runStateHash = Animator.StringToHash("Run");
		int idleStateHash = Animator.StringToHash("birds_idle");
		
		//private DreammancerCharacterControl m_DreammancerCharacterControl; // Reference to Dream we are controllin
		
		void Start(){
			anim = GetComponent<Animator> ();
		}
		
		
		private void StartSound()
		{
			// get the carcontroller ( this will not be null as we have require component)
			//m_DreammancerCharacterControl = GetComponent<DreammancerCharacterControl> ();
			// setup the simple audio source
			if(statetype==1){
				m_fly = SetUpEngineAudioSource(fly);
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
			if (anim.GetCurrentAnimatorStateInfo(0).shortNameHash == idleStateHash) {
				isFlying = false;
				isIdle = true;
				StopSound();
				statetype=0;
				flag=0;
			}
			if (anim.GetCurrentAnimatorStateInfo(0).shortNameHash == walkStateHash) {
				isFlying = true;
				isIdle = false;
				statetype=1;
				if(flag==0){
					StartSound();
					flag=1;
				}
			}
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
