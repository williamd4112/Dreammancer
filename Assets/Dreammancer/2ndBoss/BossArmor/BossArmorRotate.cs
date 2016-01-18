using UnityEngine;
using System.Collections;

namespace Dreammancer{
	public class BossArmorRotate : MonoBehaviour {

        const float k_epislon = 1e-1f;

		private Transform m_Trans;
		[SerializeField]
		private int RotateSpeed = 60;
        [SerializeField]
        private float magnification = 1.2f;
        [SerializeField]
        private float speed = 2.0f;
        private bool enlarging;
        private float targetScale;
        private float initScale;

		// Use this for initialization
		void Start () {
			m_Trans = this.GetComponent<Transform> ();
            initScale = m_Trans.localScale.x;
            targetScale = initScale * magnification;
		}
		
		// Update is called once per frame
		void FixedUpdate () {
            float temp;
            m_Trans.RotateAround (m_Trans.position, Vector3.forward, RotateSpeed * Time.deltaTime);

            if (m_Trans.localScale.x >= targetScale - k_epislon || m_Trans.localScale.x <= initScale + k_epislon)
                enlarging = !enlarging;

            if (enlarging)
            {
                temp = Mathf.SmoothStep(m_Trans.localScale.x, targetScale, Time.deltaTime * speed);
                m_Trans.localScale = new Vector2(temp, temp);
            }
            else
            {
                temp = Mathf.SmoothStep(m_Trans.localScale.x, initScale, Time.deltaTime * speed);
                m_Trans.localScale = new Vector2(temp, temp);
            }

		}
	}
}