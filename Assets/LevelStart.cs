using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace Dreammancer
{
    public class LevelStart : MonoBehaviour
    {
        [SerializeField]
        private float m_StartDelay = 1.0f;

        [SerializeField]
        private GameObject m_Player;
        [SerializeField]
        private GameObject m_StartText;

        private bool m_IsTimeout = false;

        // Use this for initialization
        void Start()
        {
            foreach (SpriteRenderer renderer in m_Player.GetComponentsInChildren<SpriteRenderer>())
                renderer.enabled = false;
            StartCoroutine(CountDown(m_StartDelay));
        }

        // Update is called once per frame
        void Update()
        {
            if(m_IsTimeout)
            {
                foreach (SpriteRenderer renderer in m_Player.GetComponentsInChildren<SpriteRenderer>())
                    renderer.enabled = true;
                Destroy(m_StartText);
                Destroy(this);
            }
        }

        IEnumerator CountDown(float t)
        {
            yield return new WaitForSeconds(t);
            m_IsTimeout = true;
        }
    }
}
