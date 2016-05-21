using UnityEngine;
using System.Collections;

public class SpawnManager : MonoBehaviour {

    public GameObject unit;
    public static string lane;
	// Use this for initialization
    public void pressed(string x)
    {
        if (x == "Blue")
        {
            createUnit("blue", 50);
            Debug.Log("called pressed");
        }
        else if (x == "Red")
        {
            createUnit("red", 1800);
        }
    }
    // Update is called once per frames
    void createUnit(string faction, int z) {
        Debug.Log("called createUnit");

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
