using UnityEngine;
using System.Collections;

public class Deg : MonoBehaviour {

    public int stat = 150;
	
    void OnTriggerEnter(Collider other)
    {

        if (this.tag != other.gameObject.tag)
        {
            stat -= other.GetComponent<UnitLogic>().damage;
            Destroy(other.gameObject);
        }
    }
}
