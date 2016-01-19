using UnityEngine;
using System.Collections;

namespace Dreammancer
{
    public interface CallbackObject
    {
        void Callback();
    }

    public class DestroySelf : MonoBehaviour
    {
        [SerializeField]
        private float m_Time;

        private bool isDestroy = false;

        private ArrayList m_Callbacks;
        
        public void AddCallback(CallbackObject callback)
        {
            m_Callbacks.Add(callback);
        }

        public void InvokeCallbacks()
        {
            foreach (CallbackObject obJ in m_Callbacks)
                obJ.Callback();
        }

        void Start()
        {
            m_Callbacks = new ArrayList();
            StartCoroutine(CountDown(m_Time));
        }

        // Update is called once per frame
        void Update()
        {
            if (isDestroy)
            {
                InvokeCallbacks();
                Destroy(gameObject);
            }
        }

        IEnumerator CountDown(float t)
        {
            yield return new WaitForSeconds(t);
            isDestroy = true;
        }
    }
}
