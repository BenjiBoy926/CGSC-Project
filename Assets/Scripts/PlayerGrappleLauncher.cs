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

	//Update looks for the throw button to be pressed.
	//throw button launches if the hook is inactive and retracts if the hook is active.
	//the grappleIsActive bool is changed within the GrappleHookController.
	void Update() 
	{
		if(Input.GetButtonDown(throwButton) && !hook.grappleIsActive) 
		{
			Vector3 mouseScreenPos = Input.mousePosition;
			Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(mouseScreenPos);
			Vector2 mouseOffsetFromPlayer = new Vector2(
				mouseWorldPos.x - transform.position.x,
				mouseWorldPos.y - transform.position.y
			);

			hook.grappleIsActive = true;
			grapple.Launch(transform.position, mouseOffsetFromPlayer.normalized, throwSpeed);
			Debug.Log("Grapple has Launched");
		}

		//second else-if changes a bool to true so that the third else-if
		//can call the retract function for as long as it takes to reach the player.
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
