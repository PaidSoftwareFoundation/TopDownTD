using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class EconomyManager : MonoBehaviour {
	public int blue_money = 0;
	public int red_money = 0;
	public Text money_text;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		money_text.text = "Blue has " + blue_money.ToString() + "$" + "\n" + "Red has " + red_money.ToString() + "$";
	}
}
