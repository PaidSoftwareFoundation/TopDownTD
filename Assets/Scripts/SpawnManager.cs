using UnityEngine;
using System.Collections;

public class SpawnManager : MonoBehaviour {

    public GameObject runit;
    public GameObject bunit;
    GameObject unit;

    public static string lane;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
        {
            Camera.main.GetComponent<EconomyManager>().red_money -= 5;
            createUnit("red", 1000, runit);
        }
        else if (Input.GetKeyDown(KeyCode.U) || Input.GetKeyDown(KeyCode.I) || Input.GetKeyDown(KeyCode.O) ||  Input.GetKeyDown(KeyCode.J) || Input.GetKeyDown(KeyCode.K) || Input.GetKeyDown(KeyCode.L))
        {
            Camera.main.GetComponent<EconomyManager>().blue_money -= 5;
			createUnit ("blue", -500, bunit);
        }
    }
    void createUnit(string faction, int z, GameObject aunit) {
        unit = aunit;
        float x = Random.value;
        GameObject spawned_unit;
        if (x <= 0.33)
        {
            spawned_unit = Instantiate(unit, new Vector3(200, 0, z), Quaternion.identity) as GameObject;
            spawned_unit.GetComponent<UnitLogic>().lane = "middle";
            spawned_unit.GetComponent<UnitLogic>().faction = faction;

        }
        else if (x >= 0.34 & x <= 0.66)
        {
            spawned_unit = Instantiate(unit, new Vector3(400, 0, z), Quaternion.identity) as GameObject;
            spawned_unit.GetComponent<UnitLogic>().lane = "right";
            spawned_unit.GetComponent<UnitLogic>().faction = faction;

        }
        else if (x >= 0.67 & x <= 1.0)
        {
            spawned_unit = Instantiate(unit, new Vector3(0, 0, z), Quaternion.identity) as GameObject;
            spawned_unit.GetComponent<UnitLogic>().lane = "left";
            spawned_unit.GetComponent<UnitLogic>().faction = faction;

        }
    }


}
