using UnityEngine;
using System.Collections;

namespace Dreammancer
{
    public class FlockEmiiter : MonoBehaviour
    {
        [SerializeField]
        private GameObject m_Template;
        [SerializeField]
        private float m_Delay = 1.0f;

        private bool m_Ready = true;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (m_Ready)
                GameObject.Instantiate(m_Template, transform.position, transform.rotation);
        }

        IEnumerator Timer(float t)
        {
            yield return new WaitForSeconds(t);
            m_Ready = true;
        }
    }
}
