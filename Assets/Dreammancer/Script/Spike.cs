using UnityEngine;
using System.Collections;
using System;
using Dreammancer;

public class Spike : Trap {

    // Use this for initialization
    protected override void Start () {
        damage = new Damage(0, Damage.DamageType.CRITICAL);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public override void InvokeOnTrapEnter(Trappable trappable)
    {
        
    }

    public override void InvokeOnTrapExit(Trappable trappable)
    {
        
    }

    public override void InvokeOnTrapStay(Trappable trappable)
    {
       
    }
}
