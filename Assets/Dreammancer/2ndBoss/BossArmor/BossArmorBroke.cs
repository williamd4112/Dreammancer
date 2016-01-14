using UnityEngine;
using System.Collections;

namespace Dreammancer{
	public class BossArmorBroke : MonoBehaviour {
		private Health m_Health;
		private GameObject m_Boss;
		private GameObject allArmors;
		// Use this for initialization
		void Start () {
			m_Health = this.GetComponent<Health> ();
			m_Health.RegisterHealthEvent(OnHeartChange);
			allArmors = this.transform.parent.gameObject;
		}
		
		// Update is called once per frame
		void Update () {
		
		}
		void OnHeartChange(int hp, int diff)
		{
			//Debug.Log ("Ouch");
			if (hp <= 0) {
				allArmors.GetComponent<ArmorState>().ArmorDecrease();
			}
		}
	}
}
