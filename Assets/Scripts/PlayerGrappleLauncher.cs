using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class PlayerGrappleLauncher : MonoBehaviour
{
	private GrappleController grapple;
	private GrappleHookController hook;
	[SerializeField] private string throwButton = "Fire1";
	[SerializeField] private float throwSpeed = 5f;

	private void Awake() 
	{
		grapple = gameObject.GetComponentInChildren<GrappleController>();
		hook = gameObject.GetComponentInChildren<GrappleHookController>();

		Assert.IsNotNull(grapple);
		Assert.IsNotNull(hook);
	}

	void Update() 
	{
		if(Input.GetButtonDown(throwButton) && !hook.grappleIsActive) 
		{
			hook.grappleIsActive = true;
			Vector3 mouseScreenPos = Input.mousePosition;
			Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(mouseScreenPos);
			Vector2 mouseOffsetFromPlayer = new Vector2(
				mouseWorldPos.x - transform.position.x,
				mouseWorldPos.y - transform.position.y
			);

			grapple.Launch(transform.position, mouseOffsetFromPlayer.normalized, throwSpeed);
			Debug.Log("Grapple has Launched");
		}

		else if(Input.GetButtonDown(throwButton))
		{
			hook.grappleIsRetracting = true;
		}
		
		else if(hook.grappleIsRetracting)
		{
			grapple.Retract(transform.position, throwSpeed);
			Debug.Log("Grapple Retracting");
		}
	}
}
