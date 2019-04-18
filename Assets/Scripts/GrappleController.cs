using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class GrappleController : MonoBehaviour
{
	[SerializeField] private GrappleHookController hookController;
	[SerializeField] private GrappleRopeController ropeController;

	private void Awake() {
		Assert.IsNotNull(hookController);
		Assert.IsNotNull(ropeController);
	}

	public void Launch(Vector2 position, Vector2 direction, float force) {
		gameObject.SetActive(true);
		hookController.Launch(position, direction, force);
	}

}
