using UnityEngine;
using System.Collections;

/**
 * The Rotator.
 * <p>
 * This class is responsible for rotating the Pickup
 * Game Object.
 * </p>
 */
public class Rotator : MonoBehaviour {

	/**
	 * Function that is called when the script is initialised.
	 */
	void Start () {
		// Nothing to do.
	}
	
	/**
	 * Function that is called for each frame.
	 */
	void Update () {
		transform.Rotate (new Vector3 (15, 30, 45) * Time.deltaTime);
	}
}
