using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

namespace Dreammancer
{
    public class DreammancerCharacterControl : MonoBehaviour
    {
        private class ColorList
        {
            private Color[] colors;

            private int m_cursor = 0;
            
            public int Cursor
            {
                get { return m_cursor; }
                set { m_cursor = value; }
            }

            public ColorList(Color[] colors)
            {
                this.colors = colors;
            }

            public Color SelectedColor
            {
                get { return colors[m_cursor % colors.Length]; }
            }

            public void NextColor()
            {
                m_cursor++;
                m_cursor %= colors.Length;
            }

            public void PreColor()
            {
                m_cursor--;
                if(m_cursor < 0)
                    m_cursor += colors.Length;
            }
        }

        [SerializeField]
        private Color[] colors = {new Color(1.0f, 0.0f, 0.0f, 0.5f),
                                            new Color(0.0f, 1.0f, 0.0f, 0.5f),
                                            new Color(0.0f, 0.0f, 1.0f, 0.5f)};

        [SerializeField]
        private float m_ColorSwitchThreshold = 2.0f;

        [SerializeField]
        private int m_StartLightIndex;

        private DreammancerCharacter m_Character;
        private CharacterLightArea m_LightArea;
        private ColorList m_ColorList;
        private bool hasSwitch;

        // Use this for initialization
        void Start()
        {
            m_Character = GetComponent<DreammancerCharacter>();
            m_LightArea = GetComponent<CharacterLightArea>();
            m_ColorList = new ColorList(colors);
            m_ColorList.Cursor = m_StartLightIndex;
            m_LightArea.SwitchLightColor(m_ColorList.SelectedColor);
        }

        // Update is called once per frame
        void Update()
        {
<<<<<<< HEAD
            if(CrossPlatformInputManager.GetButtonDown("ChangeColor"))
=======
			//CrossPlatformInputManager.
            float mouseY = CrossPlatformInputManager.GetAxis("Mouse Y");
            if(!hasSwitch)
>>>>>>> 1f6305318b358691a85093a7ccbc2b844e642d42
            {
                m_ColorList.NextColor();
                m_LightArea.SwitchLightColor(m_ColorList.SelectedColor);
            }
        }
    }
}

