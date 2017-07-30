using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxEnemyController : MonoBehaviour {

	public bool active;
	public SpriteRenderer spriteRenderer;
	public Sprite activeSprite;
	public Sprite deactiveSprite;

	private PlayerController player;
	private BoxCollider2D boxC;



	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
		boxC = GetComponent<BoxCollider2D>();

	}
	
	// Update is called once per frame
	void Update () {
		if(active){
			spriteRenderer.sprite = activeSprite;
		}else{
			spriteRenderer.sprite = deactiveSprite;
		}
	}

	public void Deactivate(){
		active = false;
		if(player.energy < 5){
			player.energy++;
		}
		Invoke("Activate", 5f);
		Debug.Log("Deactivating");
	}

	public void Activate(){
		active = true;
		if(player.GetComponent<CircleCollider2D>().IsTouching(boxC)){
			player.Die();
		}

		Debug.Log("Activating");
	}

	public void OnCollisionEnter2D(Collision2D other){
		if(active && other.collider.tag == "Player" && other.transform.position.y > transform.position.y + 1.3f){
			Deactivate();
		}else if(active && other.collider.tag =="Player"){
			player.Die();
		}
	}

}
