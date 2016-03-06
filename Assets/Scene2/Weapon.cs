using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {

	public float fireRate=0;
	public float damage=10;
	public LayerMask whatToHit;

	public Transform BulletTrailPrefab;
	public Transform MuzzleFlashPrefab;
	float timeToSpawnEffect=0;
	public float effectSpawnRate=10;

	float timeToFire = 0;
	Transform firePoint;
	Transform firePointNext;
	Transform fireFromHere;
	// Use this for initialization
	void Awake () {
		firePoint = transform.FindChild ("FirePoint");
		firePointNext = transform.FindChild ("FirePointNext");
		fireFromHere = transform.FindChild ("FireFromHere");
		if (firePoint == null) {
			Debug.LogError ("No firepoint");
		}
	}

	// Update is called once per frame
	void Update () {
		if (fireRate == 0) {
			if (Input.GetButtonDown ("Z")) {
				Shoot ();
			}
		}
		else {
			if (Input.GetButton ("Z") && Time.time > timeToFire) {
				Debug.Log ("Pew");
				timeToFire = Time.time + 1 / fireRate;
				Shoot ();
			}
		}
	}
	void Shoot(){
		Vector2 firePointPosition = new Vector2 (firePoint.position.x,firePoint.position.y);
		Vector2 firePointNextPosition = new Vector2 (firePointNext.position.x, firePointNext.position.y);
		Vector2 fireFromHerePosition = new Vector2 (fireFromHere.position.x,fireFromHere.position.y);
		RaycastHit2D hit = Physics2D.Raycast (fireFromHerePosition, firePointNextPosition-firePointPosition, 100000, whatToHit);
		if (Time.time >= timeToSpawnEffect) {
			Effect ();
			timeToSpawnEffect = Time.time + 1 / effectSpawnRate;
		}
		Debug.DrawLine (firePointPosition, (firePointNextPosition-firePointPosition)*100,Color.cyan);
		if (hit.collider != null) {
			Debug.DrawLine (firePointPosition, hit.point, Color.red);
			Debug.Log ("We hit " + hit.collider.name + " and did " + damage + " damage.");
		}
	}
	void Effect(){
		Transform trail = (Transform)Instantiate (BulletTrailPrefab,fireFromHere.position,firePoint.rotation);
		trail.gameObject.GetComponent<MoveTrail>().isRight = firePoint.position.x < firePointNext.position.x;
		Transform clone = Instantiate (MuzzleFlashPrefab, fireFromHere.position, firePoint.rotation) as Transform;
		clone.parent = firePoint;
		float size = Random.Range (0.6f, 0.9f);
		clone.localScale = new Vector3 (size, size, size);
		Destroy (clone.gameObject,0.02f);
	}
}
