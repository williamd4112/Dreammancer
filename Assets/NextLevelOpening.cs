﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NextLevelOpening : StateMachineBehaviour {

	 // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	//override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	//override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {

		GameObject start = GameObject.Find ("Start");
		GameObject delete = GameObject.Find ("Delete");
		GameObject quit = GameObject.Find ("Quit");

		start.GetComponent<Image> ().enabled = true;
		start.GetComponentInChildren<Text> ().enabled = true;

		delete.GetComponent<Image> ().enabled = true;
		delete.GetComponentInChildren<Text> ().enabled = true;

		quit.GetComponent<Image> ().enabled = true;
		quit.GetComponentInChildren<Text> ().enabled = true;
	}

	// OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
	//override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
	//override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}
}