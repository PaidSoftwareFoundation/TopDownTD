using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class EconomyManager : MonoBehaviour {

	public int blue_money = 5000;
	public int red_money = 5000;
    public int red_deadBodies = 0;
    public int blue_deadBodies = 0;
    public int upgradeCapRed = 10000;
    public int redLvl = 1;
    public int upgradeCapBlue = 10000;
    public int blueLvl = 1;
    public Text money_text;
    public Text upgrade_text;

    public GameObject up;
    public GameObject redT;
    public GameObject blueT;
    public GameObject blueBase;
    public GameObject redBase;






    // Update is called once per frame
    void Update () {
		money_text.text = "Blue has " + blue_money.ToString() + "$" + "\n" + "Red has " + red_money.ToString() + "$";
        if(red_money >= upgradeCapRed)
        {
            up.SetActive(true);
            upgrade_text.text = "Red has upgraded due to their supreme thrifitiness! \n This means they will produce even more money.";
            Invoke("disable", 5);
            createRedBonusDetonator();
            redLvl++;
            upgradeCapRed += 10000 * redLvl;
            if (redLvl > 2)
            {
                redBase.SetActive(true);
                Camera.main.GetComponent<SpawnManager>().multiplierRed += 0.5;
            }

        }
        else if(blue_money >= upgradeCapBlue)
        {
            up.SetActive(true);
            upgrade_text.text = "Blue has upgraded due to their supreme thrifitiness! \n This means they will produce even more money, will get better units, and a detonator.";
            Invoke("disable", 5);
            createBlueBonusDetonator();
            blueLvl++;
            upgradeCapBlue += 10000 * blueLvl;
            if(blueLvl > 2)
            {
                blueBase.SetActive(true);
                Camera.main.GetComponent<SpawnManager>().multiplierRed += 0.5;
            }

        }
    }
    void disable()
    {
        up.SetActive(false);
    }

    void createRedBonusDetonator()
    {
        Instantiate(redT, new Vector3(Random.value+1*200, 0, 1000), Quaternion.identity);
    }

    void createBlueBonusDetonator()
    {
        Instantiate(blueT, new Vector3(Random.value+1*200, 0, -350), Quaternion.identity);

    }
}
