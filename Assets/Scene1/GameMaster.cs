using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour {

	public static GameMaster gm;

	void Start(){
		if (gm == null) {
			gm = GameObject.FindGameObjectWithTag ("GameMaster").GetComponent<GameMaster>();
		}

	}
	public Transform arrowPrefabLeft;
	public Transform arrowPrefabUp;
	public Transform arrowPrefabDown;
	public Transform arrowPrefabRight;
	public Transform spawnPointLeft;
	public Transform spawnPointUp;
	public Transform spawnPointDown;
	public Transform spawnPointRight;
	public float timeCounter=0f;
	public float spawnDelay=0.5f;
	public int score=0;

	public void Update(){
		timeCounter += Time.deltaTime;
		if (timeCounter >= spawnDelay) {
			gm.StartCoroutine (gm.SpawnArrow ((int)(Random.value * 4)));
			timeCounter -= spawnDelay;
		}
	}

	public IEnumerator SpawnArrow (int i){
		Debug.Log ("TODO:Add waiting for spawn sound");
		yield return new WaitForSeconds (spawnDelay);
	switch (i) {
		case 0:	
			{
				Instantiate (arrowPrefabLeft, spawnPointLeft.position, spawnPointLeft.rotation);
				break;	
			}	
		case 1:
			{
				Instantiate (arrowPrefabUp, spawnPointUp.position, spawnPointUp.rotation);
				break;	}
		case 2:
			{
			Debug.Log ("Now");
				Instantiate (arrowPrefabDown, spawnPointDown.position, spawnPointDown.rotation);
				break;	}

		default:
			{
				Instantiate (arrowPrefabRight, spawnPointRight.position, spawnPointRight.rotation);
			break;
		}
			}
		Debug.Log ("TODO:Add Spawn Particles");
	}
	public static void KillArrow(Arrow arrow){
		Destroy (arrow.gameObject);
	}

}
