using UnityEngine;
using System.Collections;

namespace Dreammancer
{
    [RequireComponent(typeof(MonsterCharacter))]
    [RequireComponent(typeof(SpriteRenderer))]
    public class SlimeMonsterControl : MonoBehaviour
    {
        [SerializeField]
        private Vector3 m_DetectRadius = new Vector3(20.0f, 6.0f, 0.0f);
        [SerializeField]
        private Color errorLight;

        private MonsterCharacter m_MonsterCharacter;
        private SpriteRenderer m_SpriteRenderer;
        private Color m_OriginColor;
        private Transform m_Target;
		private bool isCrazy;
		protected int id = 0;
        // Use this for initialization
        void Start()
        {
			isCrazy = false;
			id = gameObject.GetInstanceID();
            m_MonsterCharacter = GetComponent<MonsterCharacter>();
            m_SpriteRenderer = GetComponent<SpriteRenderer>();
            m_OriginColor = m_SpriteRenderer.color;
            m_Target = GameObject.FindGameObjectWithTag("Player").transform;

			Light2D.RegisterEventListener(LightEventListenerType.OnStay, OnLightStay);
			Light2D.RegisterEventListener(LightEventListenerType.OnEnter, OnLightEnter);
			Light2D.RegisterEventListener(LightEventListenerType.OnExit, OnLightExit);
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            int dir = transform.position.x - m_Target.position.x > 0 ? -1 : 1;
            float acc = (isCrazy) ? 2.0f : 1.0f;
            if (isInRange())
            {
                //m_MonsterCharacter.Move(dir * acc, false);
            }
        }

        private bool isInRange()
        {
            if(Mathf.Abs(transform.position.x - m_Target.position.x) < m_DetectRadius.x && Mathf.Abs(transform.position.y - m_Target.position.y) < m_DetectRadius.y)
            {
                return true;
            }
            
            return false;
            //return Vector3.Distance(transform.position, m_Target.position) < m_DetectRadius;
        }


		virtual protected void OnLightEnter(Light2D l, GameObject g)
		{
			if (g.GetInstanceID() == id)
			{
				 
			}
		}
		
		virtual protected void OnLightStay(Light2D l, GameObject g)
		{
			if (g.GetInstanceID() == id)
			{
				Debug.Log (l.LightColor+" "+errorLight);

				if(ColorUtil.colorCompareQuantRGB(l.LightColor, errorLight, 127)){
					isCrazy = true;
				}
				else
					isCrazy = false;
				
			}
		}
		
		virtual protected void OnLightExit(Light2D l, GameObject g)
		{
			if (g.GetInstanceID() == id)
			{

			}
		}
    }

}
