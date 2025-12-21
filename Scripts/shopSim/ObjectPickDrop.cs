using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using SPACE_UTIL;

namespace SPACE_GAME
{
	public class ObjectPickDrop : MonoBehaviour
	{
		Transform pickTr = null;
		bool isPicked = false;
		public void Pick(Transform pickTr)
		{
			Debug.Log(C.method(this));
			this.isPicked = true;
			this.pickTr = pickTr;
			Rigidbody rb = this.gameObject.gc<Rigidbody>();
			rb.useGravity = false;
			rb.isKinematic = true;
		}
		public void Drop()
		{
			Debug.Log(C.method(this));
			this.isPicked = false;
			Rigidbody rb = this.gameObject.gc<Rigidbody>();
			rb.useGravity = true;
			rb.isKinematic = false;
		}
		private void FixedUpdate()
		{
			if (this.isPicked == false) // if not picked do nothing.
				return;

			Rigidbody rb = this.gameObject.gc<Rigidbody>();
			Vector3 newPos = Z.lerp(this.transform.position, this.pickTr.position, Time.unscaledDeltaTime * 20f);
			rb.MovePosition(pickTr.position);
		}
	}
}
