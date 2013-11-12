using UnityEngine;
using System.Collections;

public class ResetFromCrash : MonoBehaviour {

	// Use this for initialization
	void OnCollisionEnter(Collision theCollision) {
		CarDriver otherObjectsScript = theCollision.gameObject.GetComponent<CarDriver>();
		
		if(otherObjectsScript == null) return;
		
		otherObjectsScript.Respawn();
	}
}
