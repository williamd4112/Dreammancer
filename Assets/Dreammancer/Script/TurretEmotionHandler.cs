using UnityEngine;
using System.Collections;

namespace Dreammancer
{
    [RequireComponent(typeof(ShootDamageEmitter))]
    public class TurretEmotionHandler : MonoBehaviour
    {
        [SerializeField]
        private const float k_PositiveShootingRate = 5.0f;
        [SerializeField]
        private const float k_NormalShootingRate = 2.0f;
        [SerializeField]
        private const float k_NegativeShootingRate = 1.0f;

        [SerializeField]
        private float m_ShootingRate = 3.0f;

        private ShootDamageEmitter m_ShootDamageEmitter;

        // Use this for initialization
        void Start()
        {
            m_ShootDamageEmitter = GetComponent<ShootDamageEmitter>();

            SceneManager.RegisterEmotionEvent(OnEmotionChange);
        }

        // Update is called once per frame
        void Update()
        {

        }

        void OnEmotionChange(SceneState state, int emotionVal, int emotionDiff)
        {
            switch (state)
            {
                case SceneState.NEGATIVE:
                    m_ShootDamageEmitter.SetShootingRate(k_NegativeShootingRate);
                    break;
                case SceneState.NORMAL:
                    m_ShootDamageEmitter.SetShootingRate(k_NormalShootingRate);
                    break;
                case SceneState.POSITIVE:
                    m_ShootDamageEmitter.SetShootingRate(k_PositiveShootingRate);
                    break;
                default:
                    break;
            }
        }
    }
}
