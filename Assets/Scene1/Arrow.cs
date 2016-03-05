using UnityEngine;
using System.Collections;

public class Arrow : MonoBehaviour {

	[System.Serializable]
	public class ArrowType {
		public string direction;
	}
	Rigidbody2D rb;
	public ArrowType arrowType = new ArrowType();
	public int minH=-5;
	public int moveSpeed=10;

	void Start(){
		rb = GetComponent<Rigidbody2D> ();
	}
	void Update(){
		if(transform.position.y<=minH)
			DestroyArrow();
	}
	void FixedUpdate(){
		rb.velocity = new Vector2 (0,-moveSpeed);
	}
	public void DestroyArrow (){
			GameMaster.KillArrow (this);		
	}
}
