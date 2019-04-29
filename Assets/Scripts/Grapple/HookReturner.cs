using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace Grapple {

	public class HookReturner : MonoBehaviour, IReturner {
		[SerializeField] private Rigidbody2D retractTarget;
		[SerializeField] private float speed = 20f;

		[Space(10)]
		[Tooltip("Disable this game object upon getting close enough to the retract target.")]
		[SerializeField] private GameObject vanishTarget;
		[SerializeField] private float vanishDistance = 0.5f;

		private Rigidbody2D rb;

		public void Return() {
			enabled = true;
		}

		private void Awake() {
			rb = GetComponent<Rigidbody2D>();
			Assert.IsNotNull(rb);
		}

		private void Update() {
			rb.MovePosition(Vector2.MoveTowards(rb.position, retractTarget.position, speed * Time.deltaTime));

			if((rb.position - retractTarget.position).sqrMagnitude < vanishDistance * vanishDistance) {
				FinishReturn();
			}
		}

		private void FinishReturn() {
			vanishTarget.SetActive(false);
			enabled = false;
		}

	}
}
