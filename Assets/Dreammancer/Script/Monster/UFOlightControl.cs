using UnityEngine;
using System.Collections;

public class UFOlightControl : MonoBehaviour {

	const float k_epislon = 1e-1f;

	[SerializeField] private float magnification;
	[SerializeField] private float speed = 2.0f;
	private Light2D m_light;
	private bool enlarging;
	private float targetRadius;
	private float initRadius;
	
	void Start () {
		m_light = GetComponent<Light2D>();
		enlarging = false;
		initRadius = m_light.LightRadius;
		targetRadius = magnification * initRadius;
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		if(m_light.LightRadius >= targetRadius - k_epislon || 
		   m_light.LightRadius <= initRadius + k_epislon)
			enlarging = !enlarging;

		if (enlarging) {
			Debug.Log ("enlarge");
			m_light.LightRadius = Mathf.SmoothStep(m_light.LightRadius, targetRadius, Time.deltaTime * speed);

		}
		else{
			Debug.Log ("shrink");
			m_light.LightRadius = Mathf.SmoothStep(m_light.LightRadius, initRadius, Time.deltaTime * speed);
		}
	}

}
