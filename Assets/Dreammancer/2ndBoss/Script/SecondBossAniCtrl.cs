using UnityEngine;
using System.Collections;

namespace Dreammancer{
	public class SecondBossAniCtrl : MonoBehaviour {
		private Animator m_Animator;
		// Use this for initialization
		void Start () {
			m_Animator = this.gameObject.GetComponent<Animator> ();
		}
		
		// Update is called once per frame
		void Update () {
		
		}

		public void becomeHurtable(){
			m_Animator.SetTrigger ("IsHurtable");
		}
	}
}