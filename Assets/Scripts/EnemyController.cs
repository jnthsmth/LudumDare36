using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	public bool groundAhead = false;
	public bool pathObstructed = false;
	public float speed = 1f;

	void Update () {
		Vector3 atGroundAhead = transform.TransformDirection (new Vector3 (1f, -0.6f, 0f));
		groundAhead = Physics.Raycast (transform.position, atGroundAhead, atGroundAhead.magnitude);
		RaycastHit h = new RaycastHit();
		pathObstructed = false;
		if ( Physics.Raycast(new Ray(transform.position,Vector3.right), out h, 1.3f) &&
				h.collider.gameObject.tag == "Obstruction")
			pathObstructed = true;

		if (!groundAhead || pathObstructed) {
			Vector3 angles = transform.rotation.eulerAngles;
			angles.y += 180;
			transform.rotation = Quaternion.Euler (angles);
		} else {
			transform.position += transform.right * Time.deltaTime *speed;
		}
	}
}
