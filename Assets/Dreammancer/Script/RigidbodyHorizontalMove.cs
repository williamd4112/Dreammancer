using UnityEngine;
using System.Collections;
using Dreammancer;

[RequireComponent(typeof(Rigidbody2D))]
public class RigidbodyHorizontalMove : MonoBehaviour {

    [SerializeField]
    private float m_Speed = 2.0f;
    public float Speed
    {
        get { return m_Speed; }
        set { m_Speed = value; }
    }

    [SerializeField]
    private float m_Offset = 0.0f;
    public float Offset
    {
        get { return m_Offset; }
        set { m_Offset = value; }
    }

    [SerializeField]
    private float m_Radius = 10.0f;
    public float Radius
    {
        get { return m_Radius; }
        set { m_Radius = value; }
    }

    [SerializeField]
    private float m_Direction = 1;
    public float Direction
    {
        get { return m_Direction; }
        set { m_Direction = value; }
    }

    private Rigidbody2D m_Rigidbody;

	// Use this for initialization
	void Start () {
        m_Rigidbody = GetComponent<Rigidbody2D>();
	}
	
    void Update()
    {
        m_Rigidbody.velocity = Vector2.right * m_Speed * m_Direction;
    }

	// Update is called once per frame
	void FixedUpdate () {

        if(m_Offset >= m_Radius)
        {
            m_Direction *= -1.0f;
            m_Offset = 0;
        }
        else
        {
            m_Offset += Mathf.Abs(m_Rigidbody.velocity.x);
        }
        
	}

}
