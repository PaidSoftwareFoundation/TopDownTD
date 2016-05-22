using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BaseScript : MonoBehaviour {

    public Text healthText;
    public GameObject redWins;
    public GameObject blueWins;
    int health = 10000;
    int dead = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        
        if (health <= 0)
        {
            Destroy(gameObject);
            healthText.gameObject.SetActive(false);
            if(gameObject.tag == "red")
            {
                redWins.SetActive(true);
            }
            else
            {
                blueWins.SetActive(true);
            }
        }

        if (gameObject.tag == "red")
        {
            dead = Camera.main.GetComponent<EconomyManager>().red_deadBodies;
        }
        else
        {
            dead = Camera.main.GetComponent<EconomyManager>().blue_deadBodies;
        }

        healthText.text = "Base Health: " + health + "\nDead bodies: " + dead;

    }
    void OnTriggerEnter(Collider other)
    {

        if (this.tag != other.gameObject.tag)
        {
            health -= other.GetComponent<UnitLogic>().damage;
        }
    }
}
