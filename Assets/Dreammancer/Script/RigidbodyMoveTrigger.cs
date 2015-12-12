using UnityEngine;
using System.Collections;
using Dreammancer;
using System;

[RequireComponent(typeof(MovingPlatform))]
public class RigidbodyMoveTrigger : Trap{

    [SerializeField]
    private bool InverseTrigger = false;

    [SerializeField]
    private bool TriggerOnce = true;

    [SerializeField]
    private float m_Speed = 2.0f;

    private bool isOnto = false;
    private bool hasTrigger = false;
    private MovingPlatform m_Platform;

    // Use this for initialization
    protected override void Start () {
        base.Start();
        m_Platform = GetComponent<MovingPlatform>();
	}
	
	// Update is called once per frame
	void Update () {
        if (InverseTrigger)
            isOnto = !isOnto;

        if (isOnto)
            hasTrigger = true;

        if (isOnto)
            m_Platform.platformSpeed = m_Speed;
        else
            m_Platform.platformSpeed = 0;
    }

    public override void InvokeOnTrapEnter(Trappable trappable)
    {
        if(!(TriggerOnce && hasTrigger))
            isOnto = true;
    }

    public override void InvokeOnTrapExit(Trappable trappable)
    {
        if (!(TriggerOnce && hasTrigger))
            isOnto = false;
    }

    public override void InvokeOnTrapStay(Trappable trappable)
    {
        if (!(TriggerOnce && hasTrigger))
            isOnto = true;
    }

}
