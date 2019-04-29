using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace Grapple {
	public class GrappleController : MonoBehaviour {
		// TODO These should all bei nterfaces but Unity is dumb
		[SerializeField] private HookLauncher launcher;
		[SerializeField] private HookReturner returner;
		[SerializeField] private HookAttacher attacher;
		[SerializeField] private Rope rope;

		private void Awake() {
			Assert.IsNotNull(launcher);
			Assert.IsNotNull(returner);
			Assert.IsNotNull(attacher);
			Assert.IsNotNull(rope);

			launcher.CollideCallback += attacher.Attach;
		}

		public void Launch(Vector2 position, Vector2 direction) {

			if(!gameObject.activeSelf) {
				Debug.Log("Launching");

				gameObject.SetActive(true);
				launcher.Launch(position, direction);
			}
		}

		public void Return() {

			if(attacher.Attached != null) {
				Debug.Log("Returning");
				attacher.Detach();
				returner.Return();
			}
		}

	}
}
