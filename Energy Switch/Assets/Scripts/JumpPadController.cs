using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPadController : MonoBehaviour {

	public bool active;
	public SpriteRenderer spriteRenderer;
	public Sprite activeSprite;
	public Sprite deactiveSprite;

	private PlayerController player;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {

		if(active){
			spriteRenderer.sprite = activeSprite;
		}else{
			spriteRenderer.sprite = deactiveSprite;
		}
	}

	public void OnCollisionEnter2D(Collision2D other){
		if(!active && player.poweredUp && other.collider.tag == "Player" && other.transform.position.y > transform.position.y + 0.65f){
			Activate();
		}else if(active && other.collider.tag == "Player"){
			//player.Die();
		}
	}

	public void Activate(){
		active = true;
		Invoke("Deactivate", 1f);
		player.Bounce();
		player.energy--;
	}

	public void Deactivate(){
		active = false;
	}

}
