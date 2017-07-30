using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyManager : MonoBehaviour {

	public Sprite[] Energy;
	public Image energyImage;

	private PlayerController player;

	void Start(){
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
	}

	void Update(){
		switch(player.energy){
			case 0:
				energyImage.enabled = false;
				break;
			case 1:
				energyImage.enabled = true;
				energyImage.sprite = Energy[0];
				break;
			case 2:
				//energyImage.enabled = true;
				energyImage.sprite = Energy[1];
				break;
			case 3:
				//energyImage.enabled = true;
				energyImage.sprite = Energy[2];
				break;
			case 4:
				//energyImage.enabled = true;
				energyImage.sprite = Energy[3];
				break;
			case 5:
				//energyImage.enabled = true;
				energyImage.sprite = Energy[4];
				break;
		}
	}
}
