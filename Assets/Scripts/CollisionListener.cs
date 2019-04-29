using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionListener : MonoBehaviour {
	public delegate void CollisionCallback(Collision collision);
	public delegate void TriggerCallback(Collider other);

	public CollisionCallback CollisionEnterCallback;
	public CollisionCallback CollisionStayCallback;
	public CollisionCallback CollisionExitCallback;

	public TriggerCallback TriggetEnterCallback;
	public TriggerCallback TriggetStayCallback;
	public TriggerCallback TriggetExitCallback;

	private void OnCollisionEnter(Collision collision) {
		CollisionEnterCallback?.Invoke(collision);
	}

	private void OnCollisionStay(Collision collision) {
		CollisionStayCallback?.Invoke(collision);
	}

	private void OnCollisionExit(Collision collision) {
		CollisionExitCallback?.Invoke(collision);
	}

	private void OnTriggerEnter(Collider other) {
		TriggetEnterCallback?.Invoke(other);
	}

	private void OnTriggerStay(Collider other) {
		TriggetStayCallback?.Invoke(other);
	}

	private void OnTriggerExit(Collider other) {
		TriggetExitCallback?.Invoke(other);
	}

}
