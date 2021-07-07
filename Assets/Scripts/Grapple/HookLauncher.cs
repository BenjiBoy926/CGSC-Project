using UnityEngine;
using UnityEngine.Assertions;

namespace Grapple {
	public class HookLauncher : MonoBehaviour, ILauncher {
		[SerializeField] private float launchForce;

		public System.Action<GameObject> CollideCallback {
			get; set;
		}

		private Rigidbody2D hookRigidbody;
		private Collider2D hookCollider;

		public bool IsLaunching {
			get {
				return enabled;
			}
		}

		private void Awake() {
			hookRigidbody = GetComponent<Rigidbody2D>();
			hookCollider = GetComponent<Collider2D>();

			Assert.IsNotNull(hookRigidbody);
			Assert.IsNotNull(hookCollider);
		}

		private void OnCollisionEnter2D(Collision2D collision) {
			enabled = false;
			hookCollider.enabled = false;
			hookRigidbody.velocity = Vector2.zero;
			hookRigidbody.angularVelocity = 0f;

			CollideCallback?.Invoke(collision.gameObject);
		}

		public void Launch(Vector2 startPosition, Vector2 direction) {
			enabled = true;
			hookCollider.enabled = true;

			gameObject.SetActive(true);
			hookRigidbody.simulated = true;

			hookRigidbody.position = startPosition;
			hookRigidbody.rotation = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;

			hookRigidbody.velocity = Vector2.zero;
			hookRigidbody.angularVelocity = 0f;

			hookRigidbody.AddForce(direction.normalized * launchForce, ForceMode2D.Impulse);
		}

	}
}
