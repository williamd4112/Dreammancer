using UnityEngine;
using System.Collections;

public class Warning : MonoBehaviour {


	public Canvas m_Can;
	float temp_h;
	float temp_w;
	private Rect m_rect;
	// Use this for initialization
	void Start () {
		temp_h = m_Can.pixelRect.height;
		temp_w = m_Can.pixelRect.width;
		m_rect = new Rect (m_Can.pixelRect.x, m_Can.pixelRect.y, m_Can.pixelRect.width, m_Can.pixelRect.height);
		this.GetComponent<RectTransform> ().sizeDelta = new Vector2(m_Can.pixelRect.width,m_Can.pixelRect.height);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
