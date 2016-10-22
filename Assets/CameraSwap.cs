using UnityEngine;
using System.Collections;

public class CameraSwap : MonoBehaviour {
	public Camera cameraOne;
	public Camera cameraTwo;

	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
	
	}

	public void Swap(){
		if (cameraOne.gameObject.activeInHierarchy) {
			cameraOne.gameObject.SetActive (false);
			cameraTwo.gameObject.SetActive (true);
		} else {
			cameraTwo.gameObject.SetActive (false);
			cameraOne.gameObject.SetActive (true);
		}
	}
}
