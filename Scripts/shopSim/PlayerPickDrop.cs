using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using SPACE_UTIL;

namespace SPACE_GAME
{
	public class PlayerPickDrop : MonoBehaviour
	{
		[SerializeField] Camera _cam;
		[SerializeField] LayerMask _pickDropLayer;
		[SerializeField] Transform _pickDropTr;
		[SerializeField] float _rayCastDist = 5f;

		[Header("just to log")]
		[SerializeField] bool hasPickedSomthng = false;
		[SerializeField] ObjectPickDrop objPickDrop;
		//
		private void Update()
		{
			if (this.hasPickedSomthng == false)
			{
				// 0. keep rayCasting
				// 1. instant KeyCode.E down is made, pick it up

				Ray ray = new Ray(this._cam.transform.position, this._cam.transform.forward);
				if (Physics.Raycast(ray, out RaycastHit hit, this._rayCastDist, this._pickDropLayer) == true)
					if (INPUT.K.InstantDown(KeyCode.E))
					{
						Debug.Log("interact instant down".colorTag("cyan"));
						if (hit.transform.gameObject.TryGetComponent(out ObjectPickDrop objPickDrop) == true)
						{
							this.hasPickedSomthng = true;
							objPickDrop.Pick(this._pickDropTr);
							this.objPickDrop = objPickDrop;
						}
					}
			}
			else if(this.hasPickedSomthng == true)
			{
				// 0. instant KeyCode.E is made drop it.
				if(INPUT.K.InstantDown(KeyCode.E))
				{
					this.hasPickedSomthng = false;
					this.objPickDrop.Drop();
				}
			}
		}
		//
	} 


	
}
