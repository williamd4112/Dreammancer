using UnityEngine;
using System.Collections;


namespace Dreammancer{
	public class Footsteps : MonoBehaviour {

		public AudioClip idle;
		public AudioClip walk;
		public AudioClip run;
		public AudioClip jump;
		public int flag = 0;
		public int statetype=0;
		public float frequency;

		private bool isWalking = false;
		private bool isRunning = false;
		private bool isJump = false;
		private bool isIdle = false;

		private AudioSource m_walk; // Source for the walk sounds
		private AudioSource m_jump; // 
		private AudioSource m_run; // 
		private AudioSource m_idle; //

		private bool m_StartedSound; // flag for knowing if we have started sounds

		private Animator anim;
		int jumpStateHash = Animator.StringToHash("Jumping");
		int walkStateHash = Animator.StringToHash("Walk");
		int runStateHash = Animator.StringToHash("Run");
		int idleStateHash = Animator.StringToHash("Idle");

		private DreammancerCharacterControl m_DreammancerCharacterControl; // Reference to Dream we are controllin

		void Start(){
			anim = GetComponent<Animator> ();
		}


		private void StartSound()
		{
			// get the carcontroller ( this will not be null as we have require component)
			m_DreammancerCharacterControl = GetComponent<DreammancerCharacterControl> ();
			// setup the simple audio source
			if(statetype==1){
				m_walk = SetUpEngineAudioSource(walk);
			}
			if(statetype==2){
				m_walk = SetUpEngineAudioSource(jump);
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
				isWalking = false;
				isRunning = false;
				isJump = false;
				isIdle = true;
				StopSound();
				statetype=0;
				flag=0;
			}
			if (anim.GetCurrentAnimatorStateInfo(0).shortNameHash == jumpStateHash) {
				isWalking = false;
				isRunning = false;
				isJump = true;
				StopSound();
				if(flag==1||statetype==0){
					flag=0;
					statetype=2;
					StartSound();
				}
			}
			if (anim.GetCurrentAnimatorStateInfo(0).shortNameHash == walkStateHash) {
				isWalking = true;
				isRunning = false;
				isJump = false;
				isIdle = false;
				statetype=1;
				if(flag==0){
					StartSound();
					flag=1;
				}
			}
			if (anim.GetCurrentAnimatorStateInfo(0).shortNameHash == runStateHash) {
				isWalking = false;
				isRunning = true;
				isJump = false;
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
			source.pitch = frequency;
			source.clip = clip;
			source.loop = true;
			source.Play();
			return source;
		}
	}
}
