using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/**
 * The PlayerController.
 * <p>
 * This controller class is responsible for providing the
 * properties to the Player game object. The script allows
 * for user input to have an affect on the game object.
 * </p>
 */
public class PlayerController : MonoBehaviour {

	/**
	 * Attribute to allow the speed of the player object to be
	 * adjusted. As a public attribute, the value can be assigned
	 * in the game object inspector within Unity.
	 */ 
	public float speed;

	/**
	 * A reference to the UI Text Object that will display the count.
	 */
	public Text countText;

	/**
	 * A reference to the UI Text Object that will display text when we win.
	 */
	public Text winText;

	/**
	 * A reference to the RigidBody component of the
	 * Player game object.
	 */
	private Rigidbody rb;

	/**
	 * An integer attribute that holds the number of objects
	 * that we have collected.
	 */
	private int count;

	/**
	 * Called once when the object is created.
	 * This function can be used to initialise a game object.
	 */ 
	void Start () {
		count = 0;
		setGameText();
		winText.text = "";
		rb = GetComponent<Rigidbody> (); // Find attached component called Rigidbody.
	}
	
	/**
	 * Called once per frame. 
	 */
	void Update () {
		// Nothing to do.
	}

	/**
	 * This method is called just before any physical calculations are performed
	 * on the game object. Modifying the game object properties in this method will
	 * affect how it will be drawn for the frame. 
	 * <p>
	 * In this instance, we are modifying the properties of the rigid body component
	 * of the game object to move it around the plane.
	 * </p>
	 * CMD + ' will open the API documentation
	 */
	void FixedUpdate() {
		// The Input.GetAxis will receive values taken from the keyboard direction presses.
		// The values obtained will be used to apply a physics force to the RigidBody Component
		// to move the Player game object around.
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		// We want to move it left, right, top, bottom. The y vector is set to 0 because we don't want
		// to move it into the air.
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		rb.AddForce (movement * speed);
	}
		
	/**
	 * This function is called when the game object that the script is binded to enters inside 
	 * another game object. It is only called if the game object that it enters is set to be a 
	 * trigger collider.
	 * <p>
	 * A collder is a component of a game object.
	 * </p>
	 */
	void OnTriggerEnter(Collider other) {
		//Destroy(other.gameObject); // Destroys the game object and all its children.
		if(other.gameObject.CompareTag("Pickup")) {
			// SetActive is equivelant of ticking the checkbox in the inspector for a game object.
			other.gameObject.SetActive(false);
			count++;
			setGameText ();
		}
	}

	/**
	 * This function is called when the game object that the script is binded to collides
	 * with another game object. It is only called if the game object that it collides with
	 * is not set to be a trigger collider.
	 * <p>
	 * A thing to note here is that if you destroy the wrong game object, there can be a possibility
	 * that you will destroy the plane (Ground) game object causing everything to fall into nothing.
	 */ 
	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.CompareTag ("Pickup")) {
			Destroy (collision.gameObject);
		}
	}

	/**
	 * This method is responsible for displaying the game text.
	 */ 
	void setGameText() {
		countText.text = "Count: " + count.ToString();
		if (count >= 10) {
			winText.text = "You Win!";
		}
	}
}