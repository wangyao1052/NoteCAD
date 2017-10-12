﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConstraintBehaviour : MonoBehaviour {
	public ValueConstraint constraint;
	public Text text;

	private void Awake() {
		text = GameObject.Instantiate(EntityConfig.instance.labelPrefab, Sketch.instance.labelParent.transform);
	}

	public void Update() {
		transform.position = constraint.position;
		text.transform.position = Camera.main.WorldToScreenPoint(transform.position);
		text.text = constraint.GetValue().ToString("F2");
	}

	public void OnMouseEnter() {
		Sketch.instance.hovered = constraint;
	}

	public void OnMouseExit() {
		if(Sketch.instance.hovered != constraint) return;
		Sketch.instance.hovered = null;
	}

	private void OnDestroy() {
		GameObject.Destroy(text.gameObject);
	}

}