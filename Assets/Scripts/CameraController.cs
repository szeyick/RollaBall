using UnityEngine;
using System.Collections;

/**
 * The CameraController.
 * <p>
 * This script is responsible for changing the position
 * of the camera. In this script, we want the camera to follow
 * the Player game object as it moves without having to assign it
 * as a child object as the object rotates on all axis meaning that
 * the camera will follow how it rolls which is not the desired outcome.
 * </p>
 * <b>Warning: </b>None.
 */ 
public class CameraController : MonoBehaviour {

	/**
	 * A reference to the player game object (ball)
	 */
	public GameObject player;

	/**
	 * An offset value to set the cameras position.
	 */ 
	private Vector3 offset;

	/**
	 * Function that is called when the scene is created.
	 */ 
	void Start () {
		// The offset value should be the starting distance between the player object and the camera.
		// At each frame, we want to replicate this distance.
		offset = transform.position - player.transform.position;
	}

	/**
	 * Function that is called after all the items to be drawn in the frame
	 * are processed in the update() function.
	 * <p>
	 * We update the position of the camera in this function because by the time this
	 * is called, we know that the player object has definitely moved.
	 * </p>
	 */ 
	void LateUpdate () {
		// The player object has moved so we want to move the camera to the offset distance.
		transform.position = player.transform.position + offset;
	}
}
