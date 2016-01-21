using UnityEngine;
using System.Collections;

namespace Dreammancer{
	public class Over2 : MonoBehaviour {
		
		private Animator anim;
		
		//		public int flag = 0;
		//		public int statetype=0;
		private bool isIdle = false;
		
		int idleStateHash = Animator.StringToHash("Idle");
		// Use this for initialization
		void Start () {
			anim = GetComponent<Animator> ();
		}
		
		// Update is called once per frame
		void Update () {
			//if (anim.GetCurrentAnimatorStateInfo(0).shortNameHash == idleStateHash) {
			//	isIdle = true;
			//	Application.LoadLevel ("Level1");
			//}
		}
		//		void overIt(){
		//			Application.LoadLevel ("StartScene");
		//		}
	}
}