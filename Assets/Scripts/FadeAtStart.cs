using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Com.LuisPedroFonseca.ProCamera2D;

public class FadeAtStart : MonoBehaviour {

	ProCamera2DTransitionsFX transition;

	void Start () {
		transition = GetComponent<ProCamera2DTransitionsFX>();
		transition.TransitionEnter();
	}

}
