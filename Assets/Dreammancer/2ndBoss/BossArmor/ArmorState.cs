using UnityEngine;
using System.Collections;

namespace Dreammancer{
	public class ArmorState : MonoBehaviour {
		[SerializeField]
		private int ArmorCount;
		[SerializeField]
		private GameObject m_Boss;
		private SecBossHealth b_Health;
		// Use this for initialization
		void Start () {
			ArmorCount = 4;
			m_Boss = this.transform.parent.gameObject;
			b_Health = m_Boss.GetComponent<SecBossHealth> ();
		}
		
		// Update is called once per frame
		void Update () {
		
		}

		public void ArmorDecrease(){
			ArmorCount-=1;
			if(ArmorCount == 0){
				b_Health.BossHurt();
			}
		}
	}
}
