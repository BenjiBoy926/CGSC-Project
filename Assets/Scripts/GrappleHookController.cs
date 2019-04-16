using UnityEngine;
using UnityEngine.Assertions;

public class GrappleHookController : MonoBehaviour
{
	[SerializeField] private float launchForce;

	private Rigidbody2D hookRigidbody;


	private void Awake() {
		hookRigidbody = GetComponent<Rigidbody2D>();
		Assert.IsNotNull(hookRigidbody);
	}

	void OnEnable()
    {
		Launch(transform.right, launchForce);
    }

	private void OnCollisionEnter2D(Collision2D collision) {
		hookRigidbody.simulated = false;
		hookRigidbody.velocity = Vector2.zero;
	}

	void FixedUpdate()
    {
    }

	public void Launch(Vector2 direction, float force) {
		hookRigidbody.AddForce(direction.normalized * force, ForceMode2D.Impulse);

	}
}
