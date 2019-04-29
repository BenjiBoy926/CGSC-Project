using UnityEngine;

namespace Grapple {
	public interface IReturner {

		/// <summary>
		/// Starts returning the hook. Upon reaching the player, the component will disable itself
		/// and then disable the main hook.
		/// </summary>
		void Return();
	}
}
