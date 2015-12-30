using UnityEngine;
using System.Collections;

namespace Dreammancer
{
    public class DeathTrigger : MonoBehaviour
    {
        [SerializeField]
        private Transform[] m_ListeningDeaths;

        [SerializeField]
        private Transform[] m_ToTriggers;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            bool result = true;
            foreach(Transform trans in m_ListeningDeaths)
            {
                if (trans != null)
                {
                    result = false;
                    break;
                }
            }

            if(result)
            {
                foreach (Transform trans in m_ToTriggers)
                    trans.gameObject.SetActive(true);
            }
        }
    }
}
