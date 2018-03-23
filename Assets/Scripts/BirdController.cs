using UnityEngine;
using System.Collections;

public class BirdController : MonoBehaviour
{
		public float jumpSpeed = 5;
		public float rotationAngle = 35;
		GameObject gameController;
		Vector3 rotation;

		// Use this for initialization
		void Start ()
		{
				gameController = GameObject.FindGameObjectWithTag ("GameController");
		}
	
		// Update is called once per frame
		void Update ()
		{
				rotation = transform.localEulerAngles;

				if (!GameController.isFinished) {
						if (Input.GetButtonDown ("Fire1")) {

								GetComponent<Rigidbody2D>().velocity = Vector2.up * jumpSpeed;

								rotation.z = rotationAngle;
								
						}
						if (GameController.isRunning) {
								rotation.z -= 1.5f;
						}

						transform.localEulerAngles = rotation;
				}
		}

		void OnTriggerEnter2D (Collider2D other)
		{
				if (other.tag.Contains ("Obsticles")) {
						gameController.SendMessage ("stopGame");
						this.GetComponent<Animator> ().SetBool ("isFlying", false);
				}

				
		}

		void OnCollisionEnter2D (Collision2D other)
		{
				if (other.gameObject.tag.Contains ("Obsticles")) {
						gameController.SendMessage ("stopGame");
						this.GetComponent<Animator> ().SetBool ("isFlying", false);
						GetComponent<Rigidbody2D>().isKinematic = true;
				}
		}
}
