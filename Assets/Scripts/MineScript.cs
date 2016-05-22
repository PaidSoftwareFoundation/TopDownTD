using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class MineScript : MonoBehaviour {
    public Text healthText;
    public int stat = 2000;
    public int baseIncr = 200;
    public int redLvl = Camera.main.gameObject.GetComponent<EconomyManager>().redLvl;
    public int blueLvl = Camera.main.gameObject.GetComponent<EconomyManager>().blueLvl;
    // Use this for initialization
    void Start () {
		InvokeRepeating ("generateMoney", 0.5f, 0.5f);
        InvokeRepeating("generateHealth", 0.5f, 0.5f);

    }

    // Update is called once per frame
    void Update () {
        if (stat <= 0)
        {
            Destroy(gameObject);
            healthText.gameObject.SetActive(false);
        }
        
        healthText.text = "Mine Health: " + stat.ToString();
        redLvl = Camera.main.gameObject.GetComponent<EconomyManager>().redLvl;
        blueLvl = Camera.main.gameObject.GetComponent<EconomyManager>().blueLvl;

    }

	void generateMoney() {
		if (this.tag == "blue")
        {
			Camera.main.gameObject.GetComponent<EconomyManager> ().blue_money += baseIncr * blueLvl;
		}
        else if (this.tag == "red")
        {
			Camera.main.gameObject.GetComponent<EconomyManager> ().red_money += baseIncr * redLvl;
		}
	}
    void generateHealth()
    {
        stat += 2;
    }


	void OnTriggerEnter(Collider other)
    {
		
		if (this.tag != other.gameObject.tag) {
            stat -= other.GetComponent<UnitLogic>().damage;
            Destroy(other.gameObject);    
		}
	}


}
