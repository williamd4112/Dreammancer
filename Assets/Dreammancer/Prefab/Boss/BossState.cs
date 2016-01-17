using UnityEngine;
using System.Collections;

namespace Dreammancer{
	public class BossState : MonoBehaviour {

		public int bossLife;
		private Animator m_ani;
		private Animator bp_ani;
		public bool isDead;
		public GameObject Explo;
		private Animator e_Explo;
		public GameObject MissionCom;
		public GameObject m_Cam;
		private CamShake m_Cs;

		// Use this for initialization
		void Start () {
			m_ani = this.GetComponent<Animator> ();
			bp_ani = this.transform.parent.GetComponent<Animator> ();
			isDead = false;
			e_Explo = Explo.GetComponent<Animator> ();
			m_Cs = m_Cam.GetComponent<CamShake> ();

		}
		
		// Update is called once per frame
		void Update () {
		
		}

		public void bossHurt(){
			bossLife -=1;
			if (bossLife <= 0) {
				m_ani.SetTrigger ("Dead");
				bp_ani.Stop();
				e_Explo.SetTrigger("Explo");
				m_Cs.shakeAmt = 5f;
				m_Cs.shakePeriodTime = 0.2f;
				m_Cs.dropOffTime = 3f;
				m_Cs.shakeAndBake();
				isDead = true;
			}
			else if (bossLife > 0) {
				m_Cs.shakeAndBake();
				m_ani.SetBool ("Hurt", true);
				StartCoroutine("returnIdle");
			}
		}

		void endGame(){
			MissionCom.SetActive (true);
		}

		IEnumerator returnIdle(){
			yield return new WaitForSeconds (1);
			m_ani.SetBool ("Hurt", false);
		}

	}
}
