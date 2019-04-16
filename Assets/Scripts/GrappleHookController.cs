using UnityEngine;
using UnityEngine.Assertions;

public class GrappleHookController : MonoBehaviour
{
	private Rigidbody2D hookRigidbody;

	private void Awake() {
		hookRigidbody = GetComponent<Rigidbody2D>();
		Assert.IsNotNull(hookRigidbody);
	}

	// Start is called before the first frame update
	void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
