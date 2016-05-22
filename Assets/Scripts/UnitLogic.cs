using UnityEngine;
using System.Collections;

public class UnitLogic : MonoBehaviour {

    public string lane;
    public string faction;

    public int multiplier;
    public int moveSpeed = 2;
    public int health = 1;

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
            transform.position += new Vector3(-0.42f,0,multiplier) * 2;
        }
        else if (lane == "left")
        {
            transform.position += new Vector3(0.42f,0,multiplier) * 2;
        }
    }

	void OnTriggerEnter(Collider other)
    {
		print ("collision");
        if (faction == "red")
        {
            if (other.gameObject.tag == "blue")
            {
                health -= 1;
                if (health < 1)
                    Destroy(gameObject);
            }
        }
        else if (faction == "blue")
        {
            if (other.gameObject.tag == "red")
            {
                health -= 1;
                if (health < 1)
                    Destroy(gameObject);
            }
        }
    }

}
