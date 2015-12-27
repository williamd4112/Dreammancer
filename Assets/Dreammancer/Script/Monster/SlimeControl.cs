using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using System.Collections;
using Dreammancer;


namespace UnityStandardAssets._2D
{
    [RequireComponent(typeof(PlatformerCharacter2D))]
    public class SlimeControl : MonoBehaviour
    {
        private PlatformerCharacter2D m_Character;
        private monsterAI monster;
        private bool m_Jump;
        private GameObject player;
        private SpriteRenderer m_sprite;
        private Color originColor;
        //private Light2D shield;
        [SerializeField]
        private Color errorLight;
        [SerializeField]
        private float dir;
        [SerializeField] private float speed_up;


        private void Awake()
        {
            m_Character = GetComponent<PlatformerCharacter2D>();
            monster = GetComponent<monsterAI>();
        }
        private void Start()
        {            
            m_sprite = GetComponent<SpriteRenderer>();
            originColor = m_sprite.color;
            player = GameObject.Find("Player");            
            //shield = GameObject.Find("CharacterLight").GetComponent<Light2D>();
        }

        private void FixedUpdate()
        {            
            // Read the inputs.
            bool crouch = Input.GetKey(KeyCode.LeftControl);
            walk_chase(crouch);
            //Debug.Log(m_sprite.color.GetType());            

            m_Jump = false;
        }
        private void walk_chase(bool crouch)
        {
            bool sprint = goCrazy();
            float h = 0;
            if (Mathf.Abs(player.transform.position.x - this.transform.position.x) < 20.0f &&
                Mathf.Abs(player.transform.position.y - this.transform.position.y) < 6.0f)
            {
                if (player.transform.position.x < this.transform.position.x)
                {
                    if (dir == 1)
                    {
                        dir = monster.toggleDir(dir);
                    }

                    h = dir * monster.move("forward");
                    if (sprint)
                    {
                        h = h * speed_up;
                    }
                }
                else
                {
                    if (dir == -1)
                    {
                        dir = monster.toggleDir(dir);
                    }

                    h = dir * monster.move("forward");
                    if (sprint)
                    {
                        h = h * speed_up;
                    }
                }
            }
            m_Character.Move(h, crouch, m_Jump);            
        }

        private bool goCrazy() {
                        
            //Debug.Log(m_sprite.color);            
            //Debug.Log(ColorUtil.colorSubRGB(originColor, errorLight));
            if (ColorUtil.colorSubRGB(originColor, errorLight) == m_sprite.color)
            {           
                return true;
            }
            return false;
        }
    }
}
