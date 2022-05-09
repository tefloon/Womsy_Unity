using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class worm_ruch : MonoBehaviour
{
	public float chodzenie_predkosc = 2f;
	public float sila_skoku = 5f;
	public LayerMask gruntWarstwy;
	public float maxOdlegloscOdGruntu = 0.2f;

	private Rigidbody2D rb;
	private bool czyStoi;

	// Start is called before the first frame update
	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update()
	{
		CheckInput();
	}

	bool CzyStoi()
	{
		Vector2 pozycja = transform.position;
		Vector2 kierunek = Vector2.down;

		RaycastHit2D hit = Physics2D.Raycast(pozycja, kierunek, maxOdlegloscOdGruntu, gruntWarstwy);
		if (hit.collider != null)
		{
			return true;
		}

		return false;
	}

	void CheckInput()
	{
		// Ruch prawa-lewa
		float inputX = Input.GetAxisRaw("Horizontal");
		Vector3 ruch = new Vector3(chodzenie_predkosc * inputX * Time.deltaTime, 0, 0);
		transform.Translate(ruch);

		// Skoki
		if (Input.GetKeyDown(KeyCode.Space) && CzyStoi())
		{
			rb.AddForce(sila_skoku * Vector2.up, ForceMode2D.Impulse);
		}
	}
}
