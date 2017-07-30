using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {

	private GameObject player;
	public GameObject losePanel;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		if(player.transform.position.y < -10f){
			losePanel.SetActive(true);
		}
	}

	public void ReloadLevel(string name){
		losePanel.SetActive(false);
		SceneManager.LoadScene(name);

	}

	public void LoadLevel(string levelname){
		SceneManager.LoadScene(levelname);
	}

}
