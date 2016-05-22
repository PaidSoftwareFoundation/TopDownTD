using UnityEngine;
using System.Collections;
using System;

public class SpawnManager : MonoBehaviour {

    public GameObject rsniper;
    public GameObject rbomber;
    public GameObject rgrenade;
    public GameObject rsoldier;
    public GameObject rmedic;
    public GameObject runit;
    public GameObject rpyro;
    public GameObject rcatapult;


    public GameObject bsniper;
    public GameObject bgrenade;
    public GameObject bmedic;
    public GameObject bbomber;
    public GameObject bsoldier;
    public GameObject bunit;
    public GameObject bcatapult;
    public GameObject bpyro;

    public int numMedic = 0;
    public double multiplierRed = 1;
    public double multiplierBlue = 1;





    GameObject unit;

    public static string lane;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            createUnit("red", 1000, rsoldier, 70, 9, 4*multiplierRed, 1250);

        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            createUnit("red", 1000, rsniper, (int)(35 * multiplierRed), 15, 3, 1800);

        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            createUnit("red", 1000, rgrenade, 120,(int) (15*multiplierRed), 2, 2600);

        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            createUnit("red", 1000, rbomber, (int)(90 * (multiplierRed -.3)), 70, 2, 3200);

        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            createMedic("red", 2300, rmedic);

        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            createUnit("red", 1000, rpyro, 60, 90, 3, 1400);

        }
        else if (Input.GetKeyDown(KeyCode.F))
        {
            createUnit("red", 1000, rcatapult, 500, 200, 1, 5000);

        }
        else if (Input.GetKeyDown(KeyCode.U))
        {
            createUnit("blue", -350, bsoldier, 70, 9, 4 * multiplierBlue, 1250);

        }
        else if (Input.GetKeyDown(KeyCode.I))
        {
            createUnit("blue", -350, bsniper, (int)(35 * multiplierBlue), 15, 3, 1800);

        }
        else if (Input.GetKeyDown(KeyCode.O))
        {
            createUnit("blue", -350, bgrenade, 120, (int)(15 * multiplierBlue), 2, 2600);

        }
        else if (Input.GetKeyDown(KeyCode.J))
        {
            createUnit("blue", -350, bbomber, (int)(90 * (multiplierBlue - .3)), 70, 2, 3200);

        }
        else if (Input.GetKeyDown(KeyCode.K))
        {
            createMedic("blue", 2300, bmedic);

        }
        else if (Input.GetKeyDown(KeyCode.L))
        {
            createUnit("blue", -350, bpyro, 60, (int) (90 * multiplierBlue-.3), 3, 1400);

        }
        else if (Input.GetKeyDown(KeyCode.Semicolon))
        {
            createUnit("blue", -350, bcatapult,(int) (500 * multiplierBlue-.4),(int)(200 * multiplierBlue - .4), 1, 5000);

        }

    }
    void createUnit(string faction, int z, GameObject aunit, int health, int dmg, double moveSpeed, int cost) {
        if (hasMoney(faction, cost))
        {
            if(faction == "red")
            {
                Camera.main.GetComponent<EconomyManager>().red_money -= cost;

            }
            else if (faction == "blue")
            {
                Camera.main.GetComponent<EconomyManager>().blue_money -= cost;

            }
            unit = aunit;
            float x = 0.1f;
            if (moveSpeed > 1 && health != 60)
            {
                x = UnityEngine.Random.value;
            }
            GameObject spawned_unit;
            if (x <= 0.33)
            {
                spawned_unit = Instantiate(unit, new Vector3(200, 0, z), Quaternion.Euler(0, 270, 0)) as GameObject;
                spawned_unit.GetComponent<UnitLogic>().lane = "middle";
                spawned_unit.GetComponent<UnitLogic>().faction = faction;
                spawned_unit.GetComponent<UnitLogic>().health = health;
                spawned_unit.GetComponent<UnitLogic>().damage = dmg;
                spawned_unit.GetComponent<UnitLogic>().moveSpeed = moveSpeed;



            }
            else if (x >= 0.34 & x <= 0.66)
            {
                spawned_unit = Instantiate(unit, new Vector3(400, 0, z), Quaternion.Euler(0, 270, 0)) as GameObject;
                spawned_unit.GetComponent<UnitLogic>().lane = "right";
                spawned_unit.GetComponent<UnitLogic>().faction = faction;
                spawned_unit.GetComponent<UnitLogic>().health = health;
                spawned_unit.GetComponent<UnitLogic>().damage = dmg;
                spawned_unit.GetComponent<UnitLogic>().moveSpeed = moveSpeed;



            }
            else if (x >= 0.67 & x <= 1.0)
            {
                spawned_unit = Instantiate(unit, new Vector3(0, 0, z), Quaternion.Euler(0, 270, 0)) as GameObject;
                spawned_unit.GetComponent<UnitLogic>().lane = "left";
                spawned_unit.GetComponent<UnitLogic>().faction = faction;
                spawned_unit.GetComponent<UnitLogic>().health = health;
                spawned_unit.GetComponent<UnitLogic>().damage = dmg;
                spawned_unit.GetComponent<UnitLogic>().moveSpeed = moveSpeed;



            }
        }
    }
    bool hasMoney(string faction, int cost)
    {
        bool money = false;
        if (faction == "red")
            money = (Camera.main.GetComponent<EconomyManager>().red_money > cost);
        else if (faction == "blue")
            money = (Camera.main.GetComponent<EconomyManager>().blue_money > cost);
        return money;
    }

    void createMedic(string faction, int cost, GameObject aunit)
    {
        GameObject spawned_medic;
        int pos = 0;
        if (faction == "red")
            pos = 1000;
        else if(faction == "blue")
            pos = -350;
        if(hasMoney(faction, cost) && numMedic < 5)
        {
            Camera.main.GetComponent<EconomyManager>().blue_money -= cost;
            spawned_medic = Instantiate(aunit, new Vector3(500, 0, pos), Quaternion.Euler(0, 270, 0)) as GameObject;
            numMedic++;
        }
    }

    
}
