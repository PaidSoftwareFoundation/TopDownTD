using UnityEngine;
using System.Collections;

public class UnitLogic : MonoBehaviour {

    public string lane;
    public string faction;
    public int multiplier;
	// Use this for initialization
	void Start () {
	    if(faction == "red")
        {
            multiplier = -1;
        }
        else if (faction == "blue")
        {
            multiplier = 1;
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (lane == "middle")
        {
            transform.position += new Vector3(0,0,multiplier) * 2;
        }
        else if(lane == "right")
        {
            transform.position += new Vector3(-0.4f,0,multiplier) * 2;
        }
        else if (lane == "left")
        {
            transform.position += new Vector3(0.4f,0,multiplier) * 2;
        }
    }

	void OnTriggerEnter(Collider other)
    {
		print ("collision");
        if (faction == "red")
        {
            if (other.gameObject.tag == "Blue")
                Destroy(gameObject);
        }
        else if (faction == "blue")
        {
            if (other.gameObject.tag == "Red")
                Destroy(gameObject);
        }
    }

}
