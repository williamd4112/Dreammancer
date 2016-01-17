using UnityEngine;
using System.Collections;

namespace Dreammancer{
	public enum motionState{
		Angry,
		Sad,
		None
	}

	public class Effectable : MonoBehaviour {

		public int motion = 0;
		public bool isAngry;
		public bool isSad;
		[SerializeField]
		public int motionThreshold;
		public motionState m_motionS;


		// Use this for initialization
		void Start () {
			m_motionS = motionState.None;
		}
		
		// Update is called once per frame
		void Update () {
			if (motion >= motionThreshold) {
				m_motionS = motionState.Angry;
			} else if (motion <= -1 * motionThreshold) {
				m_motionS = motionState.Sad;
			}
			MotionMod ();
		}

		public void AngerChange(int amount){
			motion += amount;
		}

		public void SadChange(int amount){
			motion -= amount;
		}

		virtual public void MotionMod(){

		}
	}
}
