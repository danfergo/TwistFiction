using UnityEngine;
using System.Collections;

public class MoveTrail : MonoBehaviour {

	public int moveSpeed=230;
	public bool isRight = true;
	// Update is called once per frame
	void Update () {
		Vector3 direction = isRight ? Vector3.right : Vector3.left;
		transform.Translate (direction*Time.deltaTime*moveSpeed);
		Destroy (gameObject,10);
	}
}
