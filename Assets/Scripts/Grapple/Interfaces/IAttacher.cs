using UnityEngine;

namespace Grapple {
	public interface IAttacher {
		/// <summary>
		/// Attaches the hook to the given target. This will also enable the component.
		/// </summary>
		/// <param name="target">Object to attach to. Must not be null.</param>
		void Attach(GameObject target);

		/// <summary>
		/// Detaches the hook from whatever it was attached to. Disables this component and gets called when disabled.
		/// </summary>
		void Detach();

		/// <summary>
		/// Gets whatever the hook is attached to. Returns null if attached to nothing.
		/// </summary>
		GameObject Attached {
			get;
		}
	}
}
