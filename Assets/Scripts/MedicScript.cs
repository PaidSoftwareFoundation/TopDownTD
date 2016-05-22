using UnityEngine;
using System.Collections;

public class MedicScript : MonoBehaviour {

    // Use this for initialization
    string faction;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collided with grave");
        if (other.gameObject.tag == "grave")
        {
            if (faction == "red")
            {
                if (Camera.main.GetComponent<EconomyManager>().red_deadBodies > 0)
                {
                    Camera.main.GetComponent<EconomyManager>().red_deadBodies -= 1;
                    Camera.main.gameObject.GetComponent<EconomyManager>().red_money += 250;
                }
            }
            else
            {
                if (Camera.main.GetComponent<EconomyManager>().blue_deadBodies > 0)
                {
                    Camera.main.GetComponent<EconomyManager>().blue_deadBodies -= 1;
                    Camera.main.gameObject.GetComponent<EconomyManager>().blue_money += 250;
                }
            }

        }
    }
}
