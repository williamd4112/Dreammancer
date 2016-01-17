using UnityEngine;
using System.Collections;

namespace Dreammancer
{
	public class LightEmotionReactor : MonoBehaviour {

		[SerializeField]
		private const float k_NegativeIntensity = 3.0f;
		[SerializeField]
		private const float k_NomralIntensity = 6.0f;
		[SerializeField]
		private const float k_PositiveIntensity = 8.0f;

		private Light m_Light;

		// Use this for initialization
		void Start () {
			m_Light = GetComponent<Light> ();
			SceneManager.RegisterEmotionEvent (OnEmotionChange);
		}
		
		// Update is called once per frame
		void Update () {
			
		}

		void OnEmotionChange(SceneState state, int emotionVal, int emotionDiff)
		{
			float intensity = m_Light.intensity;
			switch(state)
			{
			case SceneState.NEGATIVE:
				intensity = k_NegativeIntensity;
				break;
			case SceneState.NORMAL:
				intensity = k_NomralIntensity;
				break;
			case SceneState.POSITIVE:
				intensity = k_PositiveIntensity;
				break;
			default:
				break;
			}
			m_Light.intensity = intensity;
		}
	}
}
