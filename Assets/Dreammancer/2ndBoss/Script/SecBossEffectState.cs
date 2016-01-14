using UnityEngine;
using System.Collections;

namespace Dreammancer{
	public enum eState{
		Idle,
		Hurtable
	}

	public class SecBossEffectState : MonoBehaviour {

		private Animator m_animator;
		private Effectable m_effect;
		[SerializeField]
		private eState m_State;
		private SpriteRenderer m_SR;
		[SerializeField]
		private GameObject BossL;
		[SerializeField]
		private GameObject BossArmors;
		[SerializeField]
		private float restoreTime = 5;
		private GameObject m_BossArm;
		// Use this for initialization
		void Start () {
			m_animator = this.gameObject.GetComponent<Animator> ();
			m_effect = this.gameObject.GetComponent<SecBossEffectable> ();
			m_SR = this.gameObject.GetComponent<SpriteRenderer> ();
			m_State = eState.Idle;
			//BossL.SetActive (false);
			//BossArmors.SetActive (false);
		}
		
		// Update is called once per frame
		void Update () {
			if (m_State == eState.Idle) {
				if (m_effect.m_motionS != motionState.None) {
					BossL.SetActive(false);
					m_animator.SetTrigger ("CanHurt");
					m_State = eState.Hurtable;
					if(m_effect.m_motionS == motionState.Angry){
						//Debug.Log("ANG");
						m_SR.color = new Color(255f/255,60f/255,60f/255);
						//m_SR.color = Color.red;

					}
					else if(m_effect.m_motionS == motionState.Sad){
						//Debug.Log("SAD");
						m_SR.color = new Color(70f/255,150f/255,255f/255);
						//m_SR.color = Color.blue;
					}
				}
			}
		}

		public void BecomeHurtable(){
			//Vector3 BosP = new Vector3(this.gameObject.transform.position
			//Debug.Log ("BECOMEHURT");
			m_BossArm = Instantiate (BossArmors, this.gameObject.transform.position, Quaternion.identity) as GameObject;
			m_BossArm.transform.SetParent (this.transform);
			SpriteRenderer[] c_SR = m_BossArm.gameObject.GetComponentsInChildren<SpriteRenderer> ();
			//Debug.Log (c_SR);
			foreach (SpriteRenderer sr in c_SR) {
				//Debug.Log("happened here?");
				if (m_effect.m_motionS == motionState.Angry) {
					sr.color = new Color(255f/255,60f/255,60f/255);
					sr.gameObject.GetComponent<LaserLightEventListener>().ChangeDamageColor(Color.red);
				}
				else if(m_effect.m_motionS == motionState.Sad){
					sr.color = new Color(70f/255,150f/255,255f/255);
					sr.gameObject.GetComponent<LaserLightEventListener>().ChangeDamageColor(Color.blue);
				}
			}
			m_State = eState.Hurtable;
			StartCoroutine ("Restore");
		}

		IEnumerator Restore(){
			yield return new WaitForSeconds (restoreTime);
			Destroy (m_BossArm);
			Repair ();
		}

		public void Repair(){
			m_effect.motion = 0;
			m_effect.m_motionS = motionState.None;
			m_SR.color = Color.white;
			BossL.SetActive (true);
			m_animator.SetTrigger ("BackToNormal");
			m_State = eState.Idle;
		}

	}
}
