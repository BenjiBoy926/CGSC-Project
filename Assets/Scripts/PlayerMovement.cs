using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
	[SerializeField] private string horizontalAxisName = "Horizontal";
	[SerializeField] private string verticalAxisName = "Vertical";
	//[SerializeField] private float moveForce = 1f;
	[SerializeField] private float moveSpeed = 1f;

	private Rigidbody2D rb;

	private void Awake() {
		rb = GetComponent<Rigidbody2D>();
	}


    void FixedUpdate()
    {
		float desiredHorizontal = Input.GetAxis(horizontalAxisName);
		float desiredVertical = Input.GetAxis(verticalAxisName);

		//rb.AddForce(new Vector2(desiredHorizontal, desiredVertical) * moveForce);
		rb.MovePosition(rb.position + new Vector2(desiredHorizontal, desiredVertical) * moveSpeed * Time.fixedDeltaTime);

    }
}
