using UnityEngine;
using System.Collections;

namespace Dreammancer
{
	public class BGFloorEmotionReactor : MonoBehaviour {

		[SerializeField]
		private Color k_NegativeColor = Color.blue;
		[SerializeField]
		private Color k_NormalColor = Color.white;
		[SerializeField]
		private Color k_PositiveColor = Color.red;

		private SpriteRenderer[] m_SpriteRenderers;

		// Use this for initialization
		void Start () {
			m_SpriteRenderers = GetComponentsInChildren<SpriteRenderer> ();

			SceneManager.RegisterEmotionEvent (OnEmotionChange);	
		}

		void OnEmotionChange(SceneState state, int emotionVal, int emotionDiff)
		{
			Color color = Color.white;
			switch(state)
			{
			case SceneState.NEGATIVE:
				color = k_NegativeColor;
				break;
			case SceneState.NORMAL:
				color = k_NormalColor;
				break;
			case SceneState.POSITIVE:
				color = k_PositiveColor;
				break;
			default:
				break;
			}
			SetColorRecursively (color);
		}

		void SetColorRecursively(Color c)
		{
			foreach (SpriteRenderer render in m_SpriteRenderers) {
				render.color = c;
			}
		}
	}

}