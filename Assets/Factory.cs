using UnityEngine;
using System.Collections;

public class Factory : MonoBehaviour {

	[Header("Prefab Sources")]
    public GameObject defaultPrefabSource;
    public GameObject[] prefabSources;

	[Header("Location to Spawn Prefabs")]
    public Transform spawnPoint;
    
	[Header("Toggle Randomization")]
	public bool useRandomFromList; //

	[Header("Automatic Instantiation Settings")]
    public bool autoGenerate = false;
	public float timeBetweenSpawns = 1f; //The amount of time that must pass before spawning another prefab.
	float timePassed; //The time passed since the last spawn, updated in our Update

	[Header("Toggle Turbo on Key Held")]
	public bool rapidFire = false;



	// Use this for initialization
	void Start () {
		SpawnObject();
	}
	
	// Update is called once per frame
	void Update () {
        if (autoGenerate) AutomaticSpawn (); //Automatically Spawn a ball when toggled.

		if(rapidFire){
			if (Input.GetKey(KeyCode.Space)) {
				if (useRandomFromList) SpawnRandomBall();
				else SpawnObject();
			}
		}
		else{
			if (Input.GetKeyDown(KeyCode.Space)) {
				if (useRandomFromList) SpawnRandomBall();
				else SpawnObject();
			}
		}
	}

	void AutomaticSpawn(){
		timePassed += Time.deltaTime;
		if (timePassed >= timeBetweenSpawns) {
			if(useRandomFromList) SpawnRandomBall();
			else SpawnObject();

			timePassed = 0;
		}
	}


	#region Spawn Object Functions
    public void SpawnObject() {
		Instantiate(defaultPrefabSource, spawnPoint.position, Quaternion.identity);
    }

    /// SpawnObject overload function: can spawn any prefab, not just the default
    public void SpawnObject(GameObject prefab) {
        Instantiate(prefab, spawnPoint.position, Quaternion.identity);
    }

    public void SpawnRandomBall() {
		if(prefabSources.Length <= 0){
			Debug.Log("No prefabs in the array");
			return; //If we have no balls in the array, don't try to pick one from it!
		}
        int randomNumber = Random.Range(0, prefabSources.Length);
        Debug.Log(randomNumber);
        SpawnObject(prefabSources[randomNumber]);
    }
	#endregion
}
