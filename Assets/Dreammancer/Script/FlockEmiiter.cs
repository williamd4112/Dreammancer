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
        [SerializeField]
        private Transform m_Target;

        private bool m_Ready = true;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (m_Ready)
            {
                GameObject dummy = GameObject.Instantiate(m_Template, transform.position, transform.rotation) as GameObject;
                dummy.GetComponent<BirdsMonsterControl>().SetTarget(m_Target);
                
                m_Ready = false;
                StartCoroutine(Timer(m_Delay));
            }
        }

        IEnumerator Timer(float t)
        {
            yield return new WaitForSeconds(t);
            m_Ready = true;
        }
    }
}
