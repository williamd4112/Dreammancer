using UnityEngine;
using System.Collections;

namespace Dreammancer
{
    public delegate void BackRefEvent();

    public class BackRef : MonoBehaviour
    {
        private BackRefEvent m_backRefEvents;

        public void AddBackRefEvent(BackRefEvent e)
        {
            m_backRefEvents += e;
        }

    }

}