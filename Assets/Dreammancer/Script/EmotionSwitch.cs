using UnityEngine;
using System.Collections;

namespace Dreammancer
{
    public class EmotionSwitch : MonoBehaviour
    {
        [SerializeField]
        private SceneState m_ToState = SceneState.POSITIVE;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if(other.CompareTag("Player"))
            {
                SceneManager.ChangeState(m_ToState);
                Destroy(gameObject);
            }
        }
    }
}
