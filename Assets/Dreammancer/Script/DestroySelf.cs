using UnityEngine;
using System.Collections;

namespace Dreammancer
{
    public class DestroySelf : MonoBehaviour
    {
        [SerializeField]
        private float m_Time;

        private bool isDestroy = false;

        void Start()
        {
            StartCoroutine(CountDown(m_Time));
        }

        // Update is called once per frame
        void Update()
        {
            if (isDestroy)
                Destroy(gameObject);
        }

        IEnumerator CountDown(float t)
        {
            yield return new WaitForSeconds(t);
            isDestroy = true;
        }
    }
}
