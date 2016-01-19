using UnityEngine;
using System.Collections;

namespace Dreammancer
{
	public enum SceneState
	{
		POSITIVE,
		NORMAL,
		NEGATIVE
	}

	public delegate void EmotionEvent(SceneState state, int emotionVal, int emotionDiff);

	public class SceneManager : MonoBehaviour {

		[SerializeField]
		private const int k_MaxEmotion = 90;
		private const int k_EmotionGap = k_MaxEmotion / 3;

		[SerializeField]
		private static SceneState m_SceneState;
		[SerializeField]
		private static int m_SceneEmotion = k_EmotionGap;
		[SerializeField]
		private static GameObject m_SceneDirectionalLight;

		private static EmotionEvent m_EmotionEvents;

		// Use this for initialization
		void Start () {
			m_SceneState = SceneState.NORMAL;
		}
		
		// Update is called once per frame
		void Update () {
			
		}

		public static void ChangeEmotion(int diff)
		{
			m_SceneEmotion = Mathf.Clamp (m_SceneEmotion + diff, 0, k_MaxEmotion);
			if (m_SceneEmotion < k_EmotionGap) {
				m_SceneState = SceneState.NEGATIVE;
			} else if (m_SceneEmotion < 2 * k_EmotionGap) {
				m_SceneState = SceneState.NORMAL;
			} else if (m_SceneEmotion < 3 * k_EmotionGap) {
				m_SceneState = SceneState.POSITIVE;
			}
			Debug.LogFormat ("{0} {1} {2}",m_SceneState,m_SceneEmotion,diff);
			InvokeEmotionEvent (diff);
		}

        public static void ChangeState(SceneState state)
        {
            int diff = 0;
            m_SceneState = state;
            switch(state)
            {
                case SceneState.NEGATIVE:
                    diff = m_SceneEmotion - 0;
                    m_SceneEmotion = 0;
                    break;
                case SceneState.NORMAL:
                    diff = m_SceneEmotion - k_EmotionGap;
                    m_SceneEmotion = k_EmotionGap;
                    break;
                case SceneState.POSITIVE:
                    diff = m_SceneEmotion - 2 * k_EmotionGap;
                    m_SceneEmotion = 2 * k_EmotionGap;
                    break;
                default:
                    break;
            }
            InvokeEmotionEvent(diff);
        }

		public static void RegisterEmotionEvent(EmotionEvent e)
		{
			m_EmotionEvents += e;
		}

		public static void InvokeEmotionEvent(int diff)
		{
			if (m_EmotionEvents != null)
				m_EmotionEvents.Invoke (m_SceneState, m_SceneEmotion, diff);
		}
	}
}
