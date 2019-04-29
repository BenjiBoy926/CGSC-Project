using UnityEngine;
using UnityEngine.Assertions;

namespace Grapple {
	public class HookLauncher : MonoBehaviour {
		[SerializeField] private float launchForce;

		private Rigidbody2D hookRigidbody;


		private void Awake() {
			hookRigidbody = GetComponent<Rigidbody2D>();
			Assert.IsNotNull(hookRigidbody);
		}

		void OnEnable() {
			//Launch(transform.right, launchForce);
		}

		private void OnDisable() {
			//hookRigidbody.simulated = false;
			hookRigidbody.velocity = Vector2.zero;
			hookRigidbody.angularVelocity = 0f;
		}

		private void OnCollisionEnter2D(Collision2D collision) {
			enabled = false;
		}

		void FixedUpdate() {
		}

		public void Launch(Vector2 position, Vector2 direction) {
			enabled = true;
			gameObject.SetActive(true);
			hookRigidbody.simulated = true;

			hookRigidbody.position = position;
			hookRigidbody.rotation = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;

			hookRigidbody.velocity = Vector2.zero;
			hookRigidbody.angularVelocity = 0f;

			hookRigidbody.AddForce(direction.normalized * launchForce, ForceMode2D.Impulse);
		}

	}
}
