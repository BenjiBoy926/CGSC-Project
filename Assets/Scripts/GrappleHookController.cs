using UnityEngine;
using UnityEngine.Assertions;

public class GrappleHookController : MonoBehaviour
{
	private Rigidbody2D homeRigidbody;
	private Rigidbody2D hookRigidbody;
	private GameObject grapple;
	[HideInInspector] public bool grappleIsActive;
	[HideInInspector] public bool grappleIsRetracting;


	private void Awake() 
	{
		hookRigidbody = GetComponent<Rigidbody2D>();
		homeRigidbody = gameObject.transform.root.GetComponent<Rigidbody2D>();
		grapple = transform.parent.gameObject;

		Assert.IsNotNull(hookRigidbody);
		Assert.IsNotNull(homeRigidbody);
		Assert.IsNotNull(grapple);
	}

	void OnEnable()
  {
		//Launch(transform.right, launchForce);
  }

	private void OnCollisionEnter2D(Collision2D collision) 
	{
		if(grappleIsRetracting == true)
		{
			Debug.Log("GrappleHookController Collision");

			//gameObject.transform.position = homeRigidbody.position;
			gameObject.SetActive(false);
			grapple.SetActive(false);

			grappleIsRetracting = false;
			grappleIsActive = false;
		}
	}

	void FixedUpdate()
  {
  }

	public void Launch(Vector2 homePosition, Vector2 direction, float force) 
	{
		grappleIsActive = true;
		gameObject.SetActive(true);
		hookRigidbody.simulated = true;

		hookRigidbody.position = homePosition;
		hookRigidbody.rotation = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;

		hookRigidbody.velocity = Vector2.zero;
		hookRigidbody.angularVelocity = 0f;

		hookRigidbody.AddForce(direction.normalized * force, ForceMode2D.Impulse);
	}

	public void Retract(Vector2 homePosition, float force)
	{
		grappleIsRetracting = true;
		hookRigidbody.simulated = true;

		Vector2 direction = (homePosition - hookRigidbody.position).normalized;
		hookRigidbody.rotation = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;

		hookRigidbody.velocity = Vector2.zero;
		hookRigidbody.angularVelocity = 0f;

		hookRigidbody.AddForce(direction * force, ForceMode2D.Impulse);
	}
}
