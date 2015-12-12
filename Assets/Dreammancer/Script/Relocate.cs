using UnityEngine;
using System.Collections;

public class Relocate : MonoBehaviour {

    private Vector3 m_OriginPos;
    private Quaternion m_OriginRot;

    private bool m_RelocateFlag = false;

    void Start()
    {
        m_OriginPos = transform.position;
        m_OriginRot = transform.rotation;
    }

    public void OnUnavailable()
    {
        transform.position = m_OriginPos;
        transform.rotation = m_OriginRot;

        Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();
        if (rigidbody != null)
        {
            rigidbody.velocity = Vector2.zero;
            rigidbody.angularVelocity = 0;
        }
    }
}
