using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace Grapple {

	public class HookReturner : MonoBehaviour {
		[SerializeField] private Rigidbody2D retractTarget;
		[SerializeField] private float speed = 20f;

		private Rigidbody2D rb;

		private void Awake() {
			rb = GetComponent<Rigidbody2D>();
			Assert.IsNotNull(rb);
		}

		public void Update() {
			rb.MovePosition(Vector2.MoveTowards(rb.position, retractTarget.position, speed * Time.deltaTime));
		}
	}
}
