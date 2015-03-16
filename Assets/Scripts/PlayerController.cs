using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour
{	
	// Public variable declarations
    public Rigidbody rb;
	public GameObject displayCount;
	public GameObject displayWin;
	public float speed;

    // Private variable declarations
	private int count;
	private Text countText;
	private Text winText;

	void Start()
	{
		rb = GetComponent<Rigidbody> ();
		count = 0;
		countText = displayCount.GetComponent<Text> ();
		winText = displayWin.GetComponent<Text> ();
		winText.text = "";
		SetCountText ();
	}

	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rb.AddForce (movement * speed * Time.deltaTime);
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "PickUp")
		{
			other.gameObject.SetActive(false);
			count += 1;
			SetCountText();
		}
	}

	void SetCountText()
	{
		countText.text = "Count: " + count.ToString ();
		if(count >= 12)
		{
			winText.text = "YOU WIN!";
		}
	}

}