using UnityEngine;
using System.Collections;

public class UnitLogic : MonoBehaviour {

    public string lane;
    public string faction;

    public int multiplier;
    public double moveSpeed = 2;
    public int health = 1;
    public int damage = 1;

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
            transform.position += new Vector3(0,0,multiplier) * (int) moveSpeed;
        }
        else if(lane == "right")
        {
            transform.position += new Vector3(-0.42f,0,multiplier) * (int) moveSpeed;
        }
        else if (lane == "left")
        {
            transform.position += new Vector3(0.42f,0,multiplier) * (int) moveSpeed;
        }
    }

	void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "wall")
        {
            Destroy(gameObject);
        }
        else if(other.gameObject.tag == "grave")
        {
            if (faction == "red")
            {
                Camera.main.GetComponent<EconomyManager>().red_money += 10;
                Camera.main.GetComponent<EconomyManager>().blue_money -= 10;
                die();

            }
            else if (faction == "blue")
            {
                Camera.main.GetComponent<EconomyManager>().blue_money += 10;
                Camera.main.GetComponent<EconomyManager>().red_money -= 10;
                die();
            }
        }

        if (faction == "red")
        {
            if (other.gameObject.tag == "blue")
            {
                health -= other.GetComponent<UnitLogic>().damage;
                if (health < 1)
                    die();
            }

        }
        else if (faction == "blue")
        {
            if (other.gameObject.tag == "red")
            {
                health -= other.GetComponent<UnitLogic>().damage;
                if (health < 1)
                    die();
            }
        }
    }

    public void die()
    {
        Destroy(gameObject);
        float f = Random.value;
        if (f <= 0.333)
        {       
           if (gameObject.tag == "red")
                Camera.main.GetComponent<EconomyManager>().red_deadBodies += 1;
        }
        else if(f >= 0.666)
        {
            if (gameObject.tag == "blue")
                Camera.main.GetComponent<EconomyManager>().blue_deadBodies += 1;
        }
    }

}
