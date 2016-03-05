using UnityEngine;
using System.Collections;

public class ArrowCollision : MonoBehaviour {
	public GameMaster gm;
	void Start(){
		gm = GameObject.FindGameObjectWithTag ("GameMaster").GetComponent<GameMaster> ();
		if (gm == null)
			Debug.Log ("FAIL");
	}

	void OnTriggerStay2D(Collider2D other){
		if (Input.GetButtonDown (other.tag)) {
			Destroy (other.gameObject);
			gm.score++;
			Debug.Log (other.tag + " " + gm.score);
		}
		else {
			gm.score--;
			Debug.Log ( "fail " + gm.score);
		}
	}
}
