using UnityEngine;
using System.Collections;

namespace Dreammancer
{
	public class FixedPlatformEmotionReactor : MonoBehaviour {

		[SerializeField]
		private GameObject m_Spike;

		// Use this for initialization
		void Start () {
			m_Spike.SetActive (false);

			SceneManager.RegisterEmotionEvent (OnEmotionChange);
		}
		
		// Update is called once per frame
		void Update () {
			
		}

		void OnEmotionChange(SceneState state, int emotionVal, int emotionDiff)
		{
			switch(state)
			{
			case SceneState.NEGATIVE:
				NegativeChange();
				break;
			case SceneState.NORMAL:
				NormalChange();
				break;
			case SceneState.POSITIVE:
				PositiveChange();
				break;
			default:
				break;
			}

		}

		void PositiveChange()
		{
			m_Spike.SetActive (true);
		}

		void NormalChange()
		{
			m_Spike.SetActive (false);
		}

		void NegativeChange()
		{
			m_Spike.SetActive (false);
		}
	}
}
