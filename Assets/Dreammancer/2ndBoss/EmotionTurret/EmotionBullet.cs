using UnityEngine;
using System.Collections;


namespace Dreammancer{
	public class EmotionBullet : MotionEffect {

		[SerializeField]
		public GameObject m_EmotionTurret;

		public override void BlueHandler(){;
			m_EmotionTurret.GetComponent<EmotionTurretShoot> ().SaQueue.Enqueue (this.gameObject);
			Debug.Log ("Come Back Sad");
		}

		public override void RedHandler(){
			m_EmotionTurret.GetComponent<EmotionTurretShoot> ().AnQueue.Enqueue (this.gameObject);
			Debug.Log ("Come Back Anger");
		}

	}
}
