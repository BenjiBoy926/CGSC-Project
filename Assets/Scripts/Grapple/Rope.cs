using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

#pragma warning disable CS0649

namespace Grapple {
	public class Rope : MonoBehaviour {
		[SerializeField] private Line ropeLine;
		[SerializeField] private Transform start;
		[SerializeField] private Transform end;

		[Space(10)]
		[SerializeField] private float ropeWidth;
		[SerializeField] private Color ropeColor;

		private void Awake() {
			Assert.IsNotNull(ropeLine);
			Assert.IsNotNull(start);
			Assert.IsNotNull(end);
		}

		void Start() {
			UpdateRopeEnds();
			ropeLine.width = ropeWidth;
			ropeLine.color = ropeColor;
		}

		void Update() {
			UpdateRopeEnds();
		}

		private void UpdateRopeEnds() {
			ropeLine.start = start.position;
			ropeLine.end = end.position;
		}

#if UNITY_EDITOR
		private void OnValidate() {
			if(UnityEditor.EditorApplication.isPlaying) {
				ropeLine.width = ropeWidth;
				ropeLine.color = ropeColor;
			}
		}
#endif
	}
}
