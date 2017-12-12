using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerController : MonoBehaviour {

	public float moveSpeed;			//variable for movement speed
	public float jumpForce;			//variable for jump power

	public float jumpTime;
	private float jumpTimeCounter;

	public float playerHealth;

	public Transform playerPrefab;
	public Transform waterSourcePrefab;

	//public float pickUpTime;
	//private float pickUpTimeCounter;

	private Rigidbody2D myRigidbody;	//says this private variable of the Rigidbody 2d belongs to the object that the script is attached to 

	public bool grounded;			//variable to see if object is grounded with true or false
	public LayerMask whatIsGround;  //variable for layers
	public Transform groundCheck;
	public float groundCheckRadius;

	public bool nearWaterSource;
	public LayerMask whatIsNearWaterSource;
	public Transform nearWaterSouceCheck;
	public float waterSourceCheckRadius;

	//private Collider2D myCollider; //says this private variable of the collider2d belongs to the object that the script is attached to 

	private Animator myAnimator;
	private Animator turtleAnimator;

	public gameManager theGameManager;

	public GameObject gameManagerObject;

	public GameObject turtleMonster;

	private bool facingRight;

	public Text scoreText;
	public int score;

	public GameObject heart1;
	public GameObject heart2;
	public GameObject heart3;


	// Use this for initialization
	void Start () {
		score = 0;
		UpdateScore ();

		myRigidbody = GetComponent<Rigidbody2D> ();  //search player object and find rigidbody attached
		//myCollider = GetComponent<Collider2D> (); //search player object and find collider attached

		myAnimator = GetComponent<Animator> (); //search player object and find animator attached
		jumpTimeCounter = jumpTime;
		facingRight = true;
		turtleAnimator = turtleMonster.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {

		//grounded = Physics2D.IsTouchingLayers (myCollider, whatIsGround); //true if myCollider touches whatIsGround
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, whatIsGround);
		nearWaterSource = Physics2D.OverlapCircle (nearWaterSouceCheck.position, waterSourceCheckRadius, whatIsNearWaterSource);

		float inputX = Input.GetAxisRaw ("Horizontal");		//float varible that is either -1,0-1 depending on button pressed
		float velocity = inputX * moveSpeed;			//take speed and input to create direction

		if (inputX == -1 || inputX == 1) {
			transform.Translate (Vector2.right * velocity * Time.deltaTime);	//translate object 
		} 

		if (Input.GetKeyDown (KeyCode.Space)) {		//if space key is pressed down

			if(grounded){
				myRigidbody.velocity = new Vector2 (myRigidbody.velocity.x, jumpForce);  //the rigidbody's velocity becomes the new coordinates of the Vector2
			}
		}

		if(Input.GetKey (KeyCode.Space)){
			if (jumpTimeCounter > 0) {
				myRigidbody.velocity = new Vector2 (myRigidbody.velocity.x, jumpForce);
				jumpTimeCounter -= Time.deltaTime;
			}
		}

		if (Input.GetKeyUp (KeyCode.Space)) {
			jumpTimeCounter = 0;
		}

		if (grounded) {
			jumpTimeCounter = jumpTime;
		}

		if (Input.GetKeyDown (KeyCode.S)) {
			if (nearWaterSource) {
				score += 1;
				UpdateScore ();
			}
		}


		myAnimator.SetFloat ("Speed", Mathf.Abs(inputX));
		myAnimator.SetBool ("Grounded", grounded);	

		if (inputX > 0 && !facingRight || inputX < 0 && facingRight) {
			
			facingRight = !facingRight;

			Vector3 theScale = transform.localScale;

			theScale.x *= -1;
			transform.localScale = theScale;
		}

		if (playerHealth == 2) {
			heart3.SetActive (false);
		}

		if (playerHealth == 1) {
			heart3.SetActive (false);
			heart2.SetActive (false);
		}

		if (playerHealth < 0) {
			heart3.SetActive (false);
			heart2.SetActive (false);
			heart1.SetActive (false);
		}
		if (playerHealth < 1) {
			var script = gameManagerObject.GetComponent<gameManager> ();
			script.RestartGame ();
			playerHealth = 3;
		}

	}


	void OnCollisionEnter2D (Collision2D other){
		if (other.gameObject.tag == "killbox") {
			theGameManager.RestartGame ();
			playerHealth = 3;
		} 
		if(other.gameObject.tag =="waterSource"){
			Physics2D.IgnoreCollision (playerPrefab.GetComponent<Collider2D> (), waterSourcePrefab.GetComponent<Collider2D> ());
		}
		if(other.gameObject.tag =="turtleMonster"){
			turtleAnimator.SetTrigger ("isSteppedOn");
			//other.gameObject.GetComponent<Animation> ().Play("Turtle_Death");
			Destroy (other.gameObject);
		}

	}

	void OnTriggerEnter2D(Collider2D other){
		/*if (other.gameObject.tag == "waterSource") {
			
				score += 1;
				UpdateScore();
				
			
			//Debug.Log("Collided with: " + other);
		}*/

		if (other.gameObject.tag == "dragonMonster") {
			var script = gameManagerObject.GetComponent<gameManager> ();
			script.RestartGame ();
			playerHealth = 3;
			//Debug.Log("Collided with: " + other);
		}

		if (other.gameObject.tag == "turtleMonster") {
			playerHealth -= 1;
		}
		if (other.gameObject.tag == "bossMonster") {
			playerHealth -= 2;
		}
	}

	void UpdateScore() {
		scoreText.text = "Score: " + score;
	}

}
