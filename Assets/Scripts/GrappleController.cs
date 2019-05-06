using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class GrappleController : MonoBehaviour
{
	private GrappleHookController hookController;
	private GrappleRopeController ropeController;
	
	private void Awake() 
	{
		hookController = gameObject.GetComponentInChildren<GrappleHookController>();
		ropeController = gameObject.GetComponentInChildren<GrappleRopeController>();

		Assert.IsNotNull(hookController);
		Assert.IsNotNull(ropeController);
	}

	public void Launch(Vector2 homePosition, Vector2 direction, float force) 
	{
		gameObject.SetActive(true);
		hookController.Launch(homePosition, direction, force);
	}

	public void Retract(Vector2 homePosition, float force)
	{
		hookController.Retract(homePosition, force);
	}
}
