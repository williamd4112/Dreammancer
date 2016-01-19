using UnityEngine;
using System.Collections;

namespace Dreammancer
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(Collider2D))]
    public class MovingPlatrformEmotionReactor : MonoBehaviour
    {
        [SerializeField]
        private float m_NegativeGravity = 0.0f;
        [SerializeField]
        private float m_NormalGravity = 3.0f;
        [SerializeField]
        private float m_PositiveGravity = 6.0f;

        private Rigidbody2D m_Rigidbody;
        private bool m_DropFlag = false;

        // Use this for initialization
        void Start()
        {
            m_Rigidbody = GetComponent<Rigidbody2D>();

            SceneManager.RegisterEmotionEvent(OnEmotionChange);
        }

        void OnEmotionChange(SceneState state, int emotionVal, int emotionDiff)
        {
            switch (state)
            {
                case SceneState.NEGATIVE:
                    m_DropFlag = false;
                    break;
                case SceneState.NORMAL:
                    m_DropFlag = false;
                    break;
                case SceneState.POSITIVE:
                    m_DropFlag = true;
                    break;
                default:
                    break;
            }
        }

        void OnCollisionEnter2D(Collision2D other)
        {
            if(m_DropFlag && other.gameObject.CompareTag("Player"))
            {
                m_Rigidbody.isKinematic = false;
                m_Rigidbody.gravityScale = m_PositiveGravity;
            }
        }
    }

}