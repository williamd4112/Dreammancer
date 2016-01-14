using UnityEngine;
using System.Collections;

namespace Dreammancer{
	public class EmotionTurretRotate : MonoBehaviour {
		[SerializeField]
		private GameObject player;
		private Vector2 now;
		private Vector2 last;
		private Vector2 mid;
		private Transform m_Transform;
		private Transform p_Transform;
		private float m_Angle;
		private GameObject BigParent;
		[SerializeField]
		private float whichWay = 0; //if the turret face left, whichWay > 0, else <0

		// Use this for initialization
		void Start () {
			//player = GameObject.Find ("Player");
			m_Transform = this.gameObject.GetComponent<Transform> ();
			p_Transform = player.GetComponent<Transform> ();
			last = new Vector2 (whichWay * (m_Transform.position.x - p_Transform.position.x), m_Transform.position.y - p_Transform.position.y);
			BigParent = this.transform.parent.gameObject;
		}
		
		// Update is called once per frame
		void Update () {
			now = new Vector2 (whichWay * (m_Transform.position.x - p_Transform.position.x), m_Transform.position.y - p_Transform.position.y);
			mid = Vector2.Lerp (now, last, 0.5f);
			m_Angle = Vector2.Angle (BigParent.transform.right, mid);
			if (whichWay > 0) {
				m_Angle = Mathf.Clamp (m_Angle, 0, 90);
			} else if (whichWay < 0) {
				m_Angle = Mathf.Clamp (m_Angle, 90 , 180);
			}
			//Debug.Log (m_Angle);
			if (p_Transform.position.y < m_Transform.position.y) {
				this.transform.rotation = Quaternion.Euler (new Vector3 (0, 0, m_Angle));
			} else if (p_Transform.position.y >= m_Transform.position.y) {
				this.transform.rotation = Quaternion.Euler (new Vector3 (0, 0, -1 * m_Angle));
			}
			last = mid;
		}
	}
}
