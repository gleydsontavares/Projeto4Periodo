using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DentedPixel;

public class LogoCinematic : MonoBehaviour
{

	public GameObject lean;

	public GameObject tween;

	void Awake()
	{

	}


	void Start()
	{
		//Time.timeScale = 0.2f;

		// Slide in
		tween.transform.localPosition += -Vector3.right * 15f;
		LeanTween.moveLocalX(tween, tween.transform.localPosition.x + 15f, 0.4f).setEase(LeanTweenType.linear).setDelay(0f);

		// Drop Down tween down
		tween.transform.RotateAround(tween.transform.position, Vector3.forward, -30f);
		LeanTween.rotateAround(tween, Vector3.forward, 30f, 0.4f).setEase(LeanTweenType.easeInQuad).setDelay(0.4f);

		// Drop Lean In
		lean.transform.position += Vector3.up * 5.1f;
		LeanTween.moveY(lean, lean.transform.position.y - 5.1f, 0.6f).setEase(LeanTweenType.easeInQuad).setDelay(0.6f);
	}

}
