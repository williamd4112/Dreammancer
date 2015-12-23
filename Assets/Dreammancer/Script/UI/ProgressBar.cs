using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace Dreammancer
{
    abstract public class ProgressBarContentProvider : MonoBehaviour
    {
        abstract public int OnProvideProgressBarContent();
    }

    public class ProgressBar : MonoBehaviour
    {
        [SerializeField]
        private ProgressBarContentProvider m_Provider;

        private Image m_Image;

        // Use this for initialization
        void Start()
        {
            m_Image = GetComponent<Image>();
        }

        // Update is called once per frame
        void Update()
        {
            m_Image.rectTransform.sizeDelta = 
                new Vector2(m_Provider.OnProvideProgressBarContent(), m_Image.rectTransform.sizeDelta.y);
        }
    }
}
