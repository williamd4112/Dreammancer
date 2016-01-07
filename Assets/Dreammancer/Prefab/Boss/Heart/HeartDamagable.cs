using UnityEngine;
using System.Collections;

namespace Dreammancer{
	public class HeartDamagable : MonoBehaviour {

		private Health m_Health;
		private GameObject m_Boss;
		private BossState m_Bstate;
		private Animator b_Animator;
		// Use this for initialization
		void Start () {
			m_Health = GetComponent<Health>();
			m_Health.RegisterHealthEvent(OnHeartChange);
			m_Boss = GameObject.Find ("Boss");
			m_Bstate = m_Boss.GetComponent<BossState> ();
			//b_Animator = m_Boss.GetComponent<Animator> ();
		}
		
		// Update is called once per frame
		void Update () {
		
		}
		void OnHeartChange(int hp, int diff)
		{
			//Debug.Log ("Ouch");
			if (hp <= 0) {
				Debug.Log ("Ouch");
				m_Bstate.bossHurt ();
			}
		}
	}
}
