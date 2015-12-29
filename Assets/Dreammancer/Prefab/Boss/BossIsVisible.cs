using UnityEngine;
using System.Collections;

namespace Dreammancer{
	public class BossIsVisible : MonoBehaviour {

		Renderer m_r;
		Vector3 m_pos;
		Vector3 i_pos;
		Vector3 c_pos;
		public GameObject Player;
		Vector3 p_pos;
		Vector3 new_V3;
		public Canvas m_Can;
		private float height;
		public GameObject mainCam;
		public GameObject Imga;
		Camera m_Cam;
		float newY;
		float Can_Y;
		// Use this for initialization
		void Start () {
			m_r = this.GetComponent<Renderer> ();
			height = m_Can.GetComponent<RectTransform> ().rect.height;
			m_Cam = mainCam.GetComponent<Camera> ();
			i_pos = Imga.GetComponent<RectTransform> ().position;
		}
		
		// Update is called once per frame
		void Update () {

		}

		void FixedUpdate(){
			i_pos = Imga.GetComponent<RectTransform> ().position;
			if (!m_r.isVisible) {
				Imga.SetActive(true);
				m_pos = this.gameObject.transform.position;
				p_pos = Player.transform.position;
				c_pos = mainCam.transform.position;
				/*Debug.Log ("WithoudSTW:" + Imga.GetComponent<RectTransform>().position);
				Debug.Log ("WithSTW:" + m_Cam.ScreenToWorldPoint (Imga.GetComponent<RectTransform>().position));
				Debug.Log ("Boss Screen Pos:" + m_Cam.WorldToScreenPoint(this.transform.position));
				Debug.Log ("Player Screen Pos:" + m_Cam.WorldToScreenPoint(p_pos));
				Debug.Log ("Camera Screen Position:" + m_Cam.WorldToScreenPoint(c_pos));
				Debug.Log ("imagepos:" + i_pos);
				Debug.Log ("Rect:" + m_Can.pixelRect.width + "y:" + m_Can.pixelRect.height);*/
				newY = m_Cam.WorldToScreenPoint(this.transform.position).y;
				//newY = this.transform.position.y - p_pos.y;
				//Vector3 tempV3 = new Vector3(m_
				//new_V3 = new Vector3(0,newY,0);
				if(newY>=m_Can.pixelRect.height){
					newY = m_Can.pixelRect.height;
				}
				else if(newY<=-0){
					newY = 0;
				}
				Imga.GetComponent<RectTransform>().position = new Vector3(i_pos.x,newY,i_pos.z);
			}
			else{
				Imga.SetActive(false);
			}
		}
	}
}
