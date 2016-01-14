using UnityEngine;
using System.Collections;

namespace Dreammancer{
	public class SecBossHealth : MonoBehaviour {
		[SerializeField]
		private int bossLife;
		private Animator m_ani;
		[SerializeField]
		private GameObject mainCam;
		private CamShake m_Cs;
		[SerializeField]
		private GameObject BossBody;
		private Animator BodyAni;
		[SerializeField]
		private GameObject BossPos;
		private Animator PosAni;
		// Use this for initialization
		void Start () {
			m_ani = this.GetComponent<Animator> ();
			m_Cs = mainCam.GetComponent<CamShake> ();
			BodyAni = BossBody.GetComponent<Animator> ();
			//PosAni = BossPos.GetComponent<Animator> ();
		}
		
		// Update is called once per frame
		void Update () {
		
		}

		public void BossHurt(){
			bossLife -= 1;
			if (bossLife <= 0) {
				m_ani.SetTrigger ("Dead");
				BodyAni.Stop ();
				//PosAni.Stop ();
				m_Cs.shakeAmt = 5f;
				m_Cs.shakePeriodTime = 0.2f;
				m_Cs.dropOffTime = 3f;
				m_Cs.shakeAndBake ();
			} else if (bossLife > 0) {
				m_Cs.shakeAndBake ();
				m_ani.SetBool ("BeHurt", true);
				StartCoroutine ("returnIdle");
				this.GetComponent<SecBossEffectState>().Repair();
			}
		}

		IEnumerator returnIdle(){
			yield return new WaitForSeconds (1);
			m_ani.SetBool ("BeHurt", false);
		}
	}
}
