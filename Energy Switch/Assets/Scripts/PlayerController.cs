using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float maxSpeed;
	public float jumpForce;
	public float fallMultiplier = 2.5f;
	public float lowJumpMultiplier = 2f;
	public int energy;
	public Animator anim;

	private Rigidbody2D rb2d;
	private BoxCollider2D boxC;
	private CircleCollider2D circleC;
	private bool facingRight = true;

	public GameObject[] bodyParts;
	private GameObject[] jumppads;



	//control grounded state
	private bool grounded = false;
	public Transform groundCheck;
	private float groundRadius = 0.2f;
	public LayerMask ground;

	public bool dead;
	public bool poweredUp;
	public bool onJumppad;




	void Start(){

		rb2d = GetComponent<Rigidbody2D>();
		boxC = GetComponent<BoxCollider2D>();
		circleC = GetComponent<CircleCollider2D>();
		jumppads = GameObject.FindGameObjectsWithTag("JumpPad");
	}

	void FixedUpdate(){

		grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, ground);

		if(onJumppad){
			anim.SetBool("Ground", true);
		}else{
			anim.SetBool("Ground", grounded);
		}

	if(!dead){


			float move = Input.GetAxis("Horizontal");

			anim.SetFloat("Speed", Mathf.Abs(move));

			rb2d.velocity = new Vector2(move * maxSpeed, rb2d.velocity.y);

			if(move > 0 && !facingRight){
				Flip();
			}else if(move < 0 && facingRight){
				Flip();
			}
		}
	}

	void Update(){

		
		if(energy > 0){
			poweredUp = true;
		}else{
			poweredUp = false;
		}

		if(!dead && grounded && Input.GetKeyDown(KeyCode.Space)){
			Jump();
		}

		if(!dead && !grounded && rb2d.velocity.y < 0){
			rb2d.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier -1) * Time.deltaTime;
		} else if(!dead && !grounded && rb2d.velocity.y > 0){
			rb2d.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier -1) * Time.deltaTime;
		}
	}

	void OnCollisionEnter2D(Collision2D other){
		if(other.collider.tag == "JumpPad"){
			onJumppad = true;
		}
	}

	void OnCollisionExit2D(Collision2D other){
		if(other.collider.tag == "JumpPad"){
			onJumppad = false;
		}
	}

	public void Die(){
		dead = true;
		boxC.enabled = false;
		circleC.enabled = false;
		for (int i = 0; i < bodyParts.Length; i++) {
			bodyParts[i].GetComponent<SpriteRenderer>().color = new Color(1, 0, 0 ,1);
		}
		rb2d.AddForce(new Vector2(0, Random.Range(150f, 400f)));
		transform.rotation = new Quaternion(1,1,Random.Range(-360f, 360f),Random.Range(-360f, 360f));


	}

	public void Bounce(){
		rb2d.velocity = new Vector2(0,0);
		rb2d.AddForce(new Vector2(0, jumpForce * 2f));

	}

	public void Jump(){
		rb2d.AddForce(new Vector2(0, jumpForce));
	}

	public void Flip(){
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;

	}
}
















