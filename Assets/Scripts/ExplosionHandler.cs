using UnityEngine;
using System.Collections;

public class ExplosionHandler : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Invoke ("Explosion", 1.0f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Explosion() {
		Destroy (gameObject);
	}


}
