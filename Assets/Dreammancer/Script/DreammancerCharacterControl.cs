using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

namespace Dreammancer
{
    public class DreammancerCharacterControl : MonoBehaviour
    {
        private class ColorList
        {
            static private Color[] colors = {Color.red, Color.green, Color.blue};
            private int m_cursor = 0;
            
            public int Cursor
            {
                get { return m_cursor; }
                set { m_cursor = value; }
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
        private float m_ColorSwitchThreshold = 2.0f;

        [SerializeField]
        private int m_StartLightIndex;

        private DreammancerCharacter m_Character;
        private CharacterLightArea m_LightArea;
        private ColorList m_ColorList;

        // Use this for initialization
        void Start()
        {
            m_Character = GetComponent<DreammancerCharacter>();
            m_LightArea = GetComponent<CharacterLightArea>();
            m_ColorList = new ColorList();
            m_ColorList.Cursor = m_StartLightIndex;
            m_LightArea.SwitchLightColor(m_ColorList.SelectedColor);
        }

        // Update is called once per frame
        void Update()
        {
            float mouseY = CrossPlatformInputManager.GetAxis("Mouse Y");
            if (mouseY > m_ColorSwitchThreshold || Input.GetKeyDown(KeyCode.DownArrow))
            {
                m_ColorList.NextColor();
                m_LightArea.SwitchLightColor(m_ColorList.SelectedColor);
            }
            else if (mouseY < -m_ColorSwitchThreshold || Input.GetKeyDown(KeyCode.UpArrow))
            {
                m_ColorList.PreColor();
                m_LightArea.SwitchLightColor(m_ColorList.SelectedColor);
            }
        }
    }
}

