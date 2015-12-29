using UnityEngine;
using System.Collections;

public class PlatformVisible : MonoBehaviour {
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
	Camera m_Cam;
	private Vector3 RTpos;
	private Vector3 LBpos;
	public GameObject RT;
	public GameObject LB;
	public GameObject Arrow;
	private GameObject m_ArrowD;
	private GameObject m_ArrowU;
	private bool hasImage;
	private bool hasUp;
	private bool hasDown;

	// Use this for initialization
	void Start () {
		hasImage = false;
		m_r = this.GetComponent<Renderer> ();
		height = m_Can.GetComponent<RectTransform> ().rect.height;
		m_Cam = mainCam.GetComponent<Camera> ();
		//i_pos = Imga.GetComponent<RectTransform> ().position;
		hasUp = false;
		hasDown = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate(){
		RTpos = m_Cam.ScreenToWorldPoint (RT.GetComponent<RectTransform> ().position);
		LBpos = m_Cam.ScreenToWorldPoint (LB.GetComponent<RectTransform> ().position);
		//Debug.Log ("RT: " + RTpos);
		//Debug.Log ("LB: " + LBpos);
		if (!m_r.isVisible) {
			if(this.transform.position.x <= RTpos.x && this.transform.position.x >= LBpos.x){
				if(!hasImage){
					hasImage = true;
					if(this.transform.position.y > RTpos.y && (!hasUp)){
						m_ArrowU = Instantiate(Arrow,new Vector2(this.transform.position.x,RTpos.y),Quaternion.Euler(new Vector3(0,0,180))) as GameObject;
						hasUp = true;
						m_ArrowU.transform.parent = this.gameObject.transform;
						m_ArrowU.GetComponent<SpriteRenderer>().color = new Color(this.GetComponent<SpriteRenderer>().color.r,this.GetComponent<SpriteRenderer>().color.g,this.GetComponent<SpriteRenderer>().color.b);
					}
					else if(this.transform.position.y < LBpos.y && (!hasDown)){
						m_ArrowD = Instantiate(Arrow,new Vector2(this.transform.position.x,LBpos.y),Quaternion.Euler(new Vector3(0,0,0))) as GameObject;
						hasDown = true;
						m_ArrowD.transform.parent = this.gameObject.transform;
						m_ArrowD.GetComponent<SpriteRenderer>().color = new Color(this.GetComponent<SpriteRenderer>().color.r,this.GetComponent<SpriteRenderer>().color.g,this.GetComponent<SpriteRenderer>().color.b);
					}
				}
				else{

					if(this.transform.position.y > RTpos.y){
						m_ArrowU.SetActive(true);
						m_ArrowU.transform.position = new Vector3 (m_ArrowU.transform.position.x,RTpos.y,m_ArrowU.transform.position.z);
					}
					else if(this.transform.position.y < LBpos.y){
						m_ArrowD.SetActive(true);
						m_ArrowD.transform.position = new Vector3 (m_ArrowD.transform.position.x,LBpos.y,m_ArrowD.transform.position.z);
					}
				}
			}

		} else {
			if(hasUp){
				m_ArrowU.SetActive(false);
			}
			if(hasDown){
				m_ArrowD.SetActive(false);
			}
		}
	}
}
