using UnityEngine;
using System.Collections;

public class BackgroundController : MonoBehaviour
{
		public float backgroundSpeed = 3;
		public Transform startPosition;

		// Use this for initialization
		void Start ()
		{

		}
	
		void Update ()
		{

		}

		void OnTriggerEnter2D (Collider2D other)
		{
				if (other.tag.Contains ("Destroyer"))
						transform.position = startPosition.position;

		}

}
