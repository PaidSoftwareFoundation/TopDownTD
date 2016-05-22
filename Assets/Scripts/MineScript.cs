using UnityEngine;
using System.Collections;

public class MineScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		InvokeRepeating ("generateMoney", 0.5f, 0.5f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void generateMoney() {
		if (this.tag == "blueMine") {
			Camera.main.gameObject.GetComponent<EconomyManager> ().blue_money += 5;
		} else if (this.tag == "redMine") {
			Camera.main.gameObject.GetComponent<EconomyManager> ().red_money += 5;
		}
	}


	void OnTriggerEnter(Collider other){
		
		if (this.tag == "blueMine" && other.gameObject.tag == "red") {
			Destroy (other.gameObject);


		} else if (this.tag == "redMine" && other.gameObject.tag == "blue") {
			Destroy(other.gameObject);
		}
	}


}
