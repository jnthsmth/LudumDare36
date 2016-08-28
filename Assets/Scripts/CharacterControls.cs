using UnityEngine;
using System.Collections;

public class CharacterControls : MonoBehaviour {

	public Vector2 controlVector = Vector2.zero;
	public bool jump = false;
	public bool attack = false;
	public bool facingLeft = false;
	public float attackTimer = .5f;
	public bool stasis = false;
	public bool grounded = true;
	public bool groundedLastFrame = true;
	public bool frontBlocked = false;
	public bool backBlocked = false;
	public bool leftBlocked = false;
	public bool rightBlocked = false;
	public bool groundAhead = false;
	public bool pathObstructed = false;

	public void Update() {
		checkProximity();
		updateControls();
		if (controlVector.x > 0) facingLeft = false;
		if(controlVector.x < 0) facingLeft = true;

		Vector3 atGroundAhead = transform.TransformDirection (new Vector3 (1f, -0.6f, 0f));
		groundAhead = Physics.Raycast (transform.position, atGroundAhead, atGroundAhead.magnitude);
		RaycastHit h = new RaycastHit();
		pathObstructed = false;
		if ( Physics.Raycast(new Ray(transform.position,Vector3.right), out h, 1.3f) &&
			h.collider.gameObject.tag == "Obstruction")
			pathObstructed = true;
	}

	public virtual void updateControls() {}
		
	void checkProximity() {
		groundedLastFrame = grounded;
		grounded = Physics.Raycast (transform.position, Vector3.down, 1f);
		rightBlocked = 
			Physics.Raycast(transform.position, Vector3.right, 1.3f) || 
			Physics.Raycast(transform.position + new Vector3(0f,0.65f,0f), Vector3.right, 1.3f) || 
			Physics.Raycast(transform.position - new Vector3(0f,0.65f,0f), Vector3.right, 1.3f);
		leftBlocked =
			Physics.Raycast(transform.position, Vector3.left, 1.3f) || 
			Physics.Raycast(transform.position + new Vector3(0f,0.65f,0f), Vector3.left, 1.3f) || 
			Physics.Raycast(transform.position - new Vector3(0f,0.65f,0f), Vector3.left, 1.3f);

		Debug.DrawRay(transform.position + new Vector3 (0f, 0.65f, 0f), Vector3.right*1.3f);
		Debug.DrawRay(transform.position - new Vector3 (0f, 0.65f, 0f), Vector3.right*1.3f);
		Debug.DrawRay(transform.position, Vector3.right*1.3f);
		Debug.DrawRay(transform.position + new Vector3 (0f, 0.65f, 0f), Vector3.left*1.3f);
		Debug.DrawRay(transform.position - new Vector3 (0f, 0.65f, 0f), Vector3.left*1.3f);
		Debug.DrawRay(transform.position, Vector3.left*1.3f);
		Debug.DrawRay(transform.position, Vector3.down);
		frontBlocked = (facingLeft && leftBlocked) || (!facingLeft && rightBlocked);
		backBlocked = (!facingLeft && leftBlocked) || (facingLeft && rightBlocked);
	}

}
