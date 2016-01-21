using UnityEngine;
using System.Collections;

namespace Dreammancer
{
    public interface CallbackObject
    {
        void Callback(GameObject obj);
    }

    public class DestroySelf : MonoBehaviour
    {
        [SerializeField]
        private GameObject m_DisappearEffect;
        [SerializeField]
        private float m_Time;

        private bool isDestroy = false;

        private ArrayList m_Callbacks = new ArrayList();
        
        public void AddCallback(CallbackObject callback)
        {
            m_Callbacks.Add(callback);
        }

        public void InvokeCallbacks()
        {
            foreach (CallbackObject obJ in m_Callbacks)
                if(obJ != null)
                    obJ.Callback(gameObject);
        }

        void Start()
        {
            StartCoroutine(CountDown(m_Time));
        }

        // Update is called once per frame
        void Update()
        {
            if (isDestroy)
            {
                InvokeCallbacks();
                if(m_DisappearEffect != null)
                    GameObject.Instantiate(m_DisappearEffect, transform.position, transform.rotation);
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
