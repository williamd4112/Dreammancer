using UnityEngine;
using System.Collections;

namespace Dreammancer
{
    public class BGMEmotionReactor : MonoBehaviour
    {
        [SerializeField]
        private float m_PositivePitch = 1.3f;  
        [SerializeField]
        private float m_NormalPitch = 1.0f;
        [SerializeField]
        private float m_NegativePitch = 0.2f;

        private AudioSource m_AudioSource;

        // Use this for initialization
        void Start()
        {
            m_AudioSource = GetComponent<AudioSource>();
            SceneManager.RegisterEmotionEvent(OnEmotionChange);
        }

        void OnEmotionChange(SceneState state, int emotionVal, int emotionDiff)
        {
            switch (state)
            {
                case SceneState.NEGATIVE:
                    m_AudioSource.pitch = m_NegativePitch;
                    break;
                case SceneState.NORMAL:
                    m_AudioSource.pitch = m_NormalPitch;
                    break;
                case SceneState.POSITIVE:
                    m_AudioSource.pitch = m_PositivePitch;
                    break;
                default:
                    break;
            }
        }
    }
}
