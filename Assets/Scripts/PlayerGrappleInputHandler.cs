﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class PlayerGrappleInputHandler : MonoBehaviour
{
	[SerializeField] private Grapple.GrappleController hook;
	[SerializeField] private string throwButton = "Fire1";
	[SerializeField] private string returnButton = "Fire1";

	private void Awake() {
		Assert.IsNotNull(hook);
	}

    void Update() {
		if(Input.GetButtonDown(throwButton)) {
			Vector3 mouseScreenPos = Input.mousePosition;
			Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(mouseScreenPos);
			Vector2 mouseOffsetFromPlayer = new Vector2(
				mouseWorldPos.x - transform.position.x,
				mouseWorldPos.y - transform.position.y
			);

			hook.Launch(transform.position, mouseOffsetFromPlayer.normalized);
		}

		if(Input.GetButtonDown(returnButton)) {
			hook.Return();
		}
    }
}