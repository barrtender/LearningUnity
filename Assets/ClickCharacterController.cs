using UnityEngine;
using System.Collections;

public class ClickCharacterController : MonoBehaviour {
	
	private int groundLayer = 9;
	private Vector3 targetPosition;
	private Vector3 directionVector;
	
	public Camera mainCamera;
	public float smooth = 1f;
	
	public GUIText debugOutput;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0)) {
			LayerMask lMask = 1 << groundLayer;
			RaycastHit hit;
			if(!Physics.Raycast(mainCamera.ScreenPointToRay(Input.mousePosition), out hit, 100, lMask)) return;
			if(!hit.transform) return;
			
			targetPosition = hit.point;
			targetPosition.y=0;
			
			//debugOutput.text = "point: x=" + targetPosition.x + ", y=" + targetPosition.y + ", z=" + targetPosition.z;
			
			directionVector = hit.point - transform.position;
			directionVector.y = 0;
			if (directionVector.magnitude>1)
				directionVector = directionVector.normalized;
			
			// Apply direction
			transform.LookAt(targetPosition);
		}
		
		transform.position = Vector3.MoveTowards(transform.position, targetPosition, directionVector.magnitude * smooth);
		if (directionVector.magnitude < .1f)
		{
			targetPosition = transform.position;
		}
	}
}
