using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace Grapple {
	public class HookAttacher : MonoBehaviour, IAttacher {

		public GameObject Attached {
			get; private set;
		}

		public void Attach(GameObject target) {
			Assert.IsNotNull(target);

			Attached = target;
			//transform.parent = target.transform;
		}

		public void Detach() {
			Attached = null;
			//transform.parent = null;
		}

		private void OnDisable() {
			if(Attached != null) {
				Detach();
			}
		}

	}
}
