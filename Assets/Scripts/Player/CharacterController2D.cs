using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class CharacterController2D : MonoBehaviour
{
	[SerializeField] private float m_JumpForce = 500f;							// Amount of force added when the player jumps.
	[Range(0, 1)] [SerializeField] private float m_CrouchSpeed = .36f;			// Amount of maxSpeed applied to crouching movement. 1 = 100%
	[Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;	// How much to smooth out the movement
	[SerializeField] private bool m_AirControl = false;							// Whether or not a player can steer while jumping;
	[SerializeField] private LayerMask m_WhatIsGround;							// A mask determining what is ground to the character
	[SerializeField] private Transform m_GroundCheck;							// A position marking where to check if the player is grounded.
	[SerializeField] private Transform m_CeilingCheck;							// A position marking where to check for ceilings
	[SerializeField] private Collider2D m_CrouchDisableCollider;				// A collider that will be disabled when crouching
	[SerializeField] private float playerSpeed = 10f;

	const float k_GroundedRadius = .2f; // Radius of the overlap circle to determine if grounded
	private bool m_Grounded;            // Whether or not the player is grounded.
	const float k_CeilingRadius = .2f; // Radius of the overlap circle to determine if the player can stand up
	private Rigidbody2D m_Rigidbody2D;
	private bool m_FacingRight = true;  // For determining which way the player is currently facing.
	private Vector3 m_Velocity = Vector3.zero;

	private float boostTimer10s = 0;
	private bool jumpBoosting = false;
	private bool speedBoosting = false;

	public AudioSource jumpSound;
	public AudioSource walkSound;
	public AudioSource boostSound;
	private int waterCounter = 0;
    private int airCounter = 0;


	public buttonControllers buttonController;
	//private GameObject messageField;
 //   private GameObject messageBox;

	[Header("Events")]
	[Space]

	public UnityEvent OnLandEvent;

	[System.Serializable]
	public class BoolEvent : UnityEvent<bool> { }

	public BoolEvent OnCrouchEvent;
	private bool m_wasCrouching = false;

	private void Awake()
	{
		m_Rigidbody2D = GetComponent<Rigidbody2D>();

		if (OnLandEvent == null)
			OnLandEvent = new UnityEvent();

		if (OnCrouchEvent == null)
			OnCrouchEvent = new BoolEvent();
	}

	void Update(){
		if(jumpBoosting){
			boostTimer10s += Time.deltaTime; // increment timer each second
			if (boostTimer10s >= 10){
				jumpBoosting = false;
				m_JumpForce = 600f;
				boostTimer10s = 0;
			}
		}

		if(speedBoosting){
			boostTimer10s += Time.deltaTime; // increment timer each second
			if (boostTimer10s >= 10){
				speedBoosting = false;
				playerSpeed = 10f;
				boostTimer10s = 0;
			}
		}

		if (!buttonController)
        {
			buttonController = GameObject.Find("Object Buttons").GetComponent<buttonControllers>();
        }
	}

	// boost activate
	void OnTriggerEnter2D(Collider2D boost){

		//messageField = GameObject.Find("MessageText");
  //      messageBox = GameObject.Find("MessageBox");

		if(jumpBoosting || speedBoosting){
			// restart timer if still boosting
			boostTimer10s = 0;
		}
		// for jump boost powerup
		if(boost.tag == "Jump Boost"){
			jumpBoosting = true;
			m_JumpForce = 1000f;
			Destroy(boost.gameObject);
			boostSound.Play();
		}

		// for jump boost powerup
		if(boost.tag == "Speed Boost"){
			playerSpeed = 30f;
			speedBoosting = true;
			Destroy(boost.gameObject);
			boostSound.Play();
		}

		if (boost.gameObject.tag == "waterModule"){
			// remove modules and incrment counter, display text
        	Destroy (boost.gameObject);
        	waterCounter++;

			buttonController.ActivateMessage(10 - waterCounter + " Water Modules Left");

			//messageBox.SetActive(true);
   //         messageField.GetComponent<TextMeshProUGUI>().text = (10 - waterCounter) + " Water Modules Left";
    	}

    	if (boost.gameObject.tag == "airModule") {
			// remove modules and incrment counter, display text
        	Destroy (boost.gameObject);
        	airCounter++;

			buttonController.ActivateMessage((10 - airCounter) + " Air Modules Left");

			//messageBox.SetActive(true);
   //         messageField.GetComponent<TextMeshProUGUI>().text = (10 - airCounter) + " Air Modules Left";
    	}

		if (boost.gameObject.tag == "assembler"){
			// if player has collected all air but not all water
			if (waterCounter < 10 && airCounter == 10){

				buttonController.ActivateMessage("Missing Water Modules");
				//messageBox.SetActive(true);
				//        	messageField.GetComponent<TextMeshProUGUI>().text = "Missing Water Modules";
				// if player has collected all water but not all air
			} else if (waterCounter == 10 && airCounter < 10){
				buttonController.ActivateMessage("Missing Air Modules");
				//messageBox.SetActive(true);
				//        	messageField.GetComponent<TextMeshProUGUI>().text = "Missing Air Modules";
				// if player is missing some of both types
			} else if (waterCounter < 10 && airCounter < 10){
				buttonController.ActivateMessage("Missing Air and Water Modules");
				//messageBox.SetActive(true);
    //        	messageField.GetComponent<TextMeshProUGUI>().text = "Missing Water and Air Modules";
			// player has completed the game
			} else if (waterCounter == 10 && airCounter == 10){
				buttonController.ActivateMessage("Congratulations You Win!");
				//messageBox.SetActive(true);
				//        	messageField.GetComponent<TextMeshProUGUI>().text = "Congratulations You Win!";
			}
		}
	}

	private void FixedUpdate()
	{
		bool wasGrounded = m_Grounded;
		m_Grounded = false;

		// The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
		// This can be done using layers instead but Sample Assets will not overwrite your project settings.
		Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
		for (int i = 0; i < colliders.Length; i++)
		{
			if (colliders[i].gameObject != gameObject)
			{
				m_Grounded = true;
				if (!wasGrounded)
					OnLandEvent.Invoke();
			}
		}
	}


	public void Move(float move, bool crouch, bool jump)
	{
		// If crouching, check to see if the character can stand up
		if (!crouch)
		{
			// If the character has a ceiling preventing them from standing up, keep them crouching
			if (Physics2D.OverlapCircle(m_CeilingCheck.position, k_CeilingRadius, m_WhatIsGround))
			{
				crouch = true;
			}
		}

		//only control the player if grounded or airControl is turned on
		if (m_Grounded || m_AirControl)
		{

			// If crouching
			if (crouch)
			{
				if (!m_wasCrouching)
				{
					m_wasCrouching = true;
					OnCrouchEvent.Invoke(true);
				}

				// Reduce the speed by the crouchSpeed multiplier
				move *= m_CrouchSpeed;

				// Disable one of the colliders when crouching
				if (m_CrouchDisableCollider != null)
					m_CrouchDisableCollider.enabled = false;
			} else
			{
				// Enable the collider when not crouching
				if (m_CrouchDisableCollider != null)
					m_CrouchDisableCollider.enabled = true;

				if (m_wasCrouching)
				{
					m_wasCrouching = false;
					OnCrouchEvent.Invoke(false);
				}
			}

			//walkSound.Play();
			// Move the character by finding the target velocity
			Vector3 targetVelocity = new Vector2(move * playerSpeed, m_Rigidbody2D.velocity.y);
			// And then smoothing it out and applying it to the character
			m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);

			// If the input is moving the player right and the player is facing left...
			if (move > 0 && !m_FacingRight)
			{
				// ... flip the player.
				Flip();
			}
			// Otherwise if the input is moving the player left and the player is facing right...
			else if (move < 0 && m_FacingRight)
			{
				// ... flip the player.
				Flip();
			}
		}
		// If the player should jump...
		if (m_Grounded && jump)
		{
			jumpSound.Play();
			// Add a vertical force to the player.
			m_Grounded = false;
			m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce));
		}
	}


	private void Flip()
	{
		// Switch the way the player is labelled as facing.
		m_FacingRight = !m_FacingRight;

		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
