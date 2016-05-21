using UnityEngine;
using System.Collections;

public class UnitLogic : MonoBehaviour {

    public string lane;
    public string faction;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (lane == "middle")
        {
            transform.position += Vector3.forward * 2;
        }
        else if(lane == "right")
        {
            transform.position += new Vector3(-1,0,1) * 2;
        }
        else if (lane == "left")
        {
            transform.position += new Vector3(1,0,1) * 2;
        }
    }
}
