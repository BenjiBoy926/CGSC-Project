using UnityEngine;

namespace Grapple {
	public interface ILauncher {

		/// <summary>
		/// Launches the hook with a predetermined (default) force.
		/// </summary>
		/// <param name="startPosition">Position to launch from.</param>
		/// <param name="direction">Direction to launch to.</param>
		void Launch(Vector2 startPosition, Vector2 direction);

		/// <summary>
		/// Returns true if the grapple is still flying/being launched/etc.
		/// </summary>
		bool IsLaunching {
			get;
		}

		/// <summary>
		/// This is called the moment we bump into something. Even if this is unset, the
		/// grapple will still stick to the thing we bump.
		/// </summary>
		System.Action<GameObject> CollideCallback {
			get; set;
		}
	}
}

