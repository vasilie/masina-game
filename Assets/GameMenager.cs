using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenager : MonoBehaviour {

	public GameObject fuelGauge;
	private string spriteNames = "img/masina-fuel-gauge";
	private SpriteRenderer fuelSpriteRenderer;
	private int spriteVersion = 0;
	private Sprite[] fuelSprites;

	public float fuel = 100.0f;
	public bool masinaRuning = false;

	// Use this for initialization
	void Start () {
		fuelSpriteRenderer = fuelGauge.GetComponent<SpriteRenderer>();
		fuelSprites = Resources.LoadAll<Sprite>(spriteNames);
		Debug.Log (fuelSprites.Length);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("space")  && fuel > 0f) {
			masinaRuning = true;
		}
		if (masinaRuning == true) {
			fuel-= 0.05f;
			if (fuel < 1.0f) {
				masinaRuning = false;
			}
			//Debug.Log (fuel);
			//Debug.Log (spriteVersion);
			if (fuel >= 13 * (100 / 13)) {
				spriteVersion = 0;
				Debug.Log ("menjaj");
			} else if (fuel > 12 * (100 / 13)) {
				Debug.Log ("menjaj");
				spriteVersion = 1;
			} else if (fuel > 11 * (100 / 13)) {
				Debug.Log ("menjaj");
				spriteVersion = 2;
			} else if (fuel > 10 * (100 / 13)) {
				Debug.Log ("menjaj");
				spriteVersion = 3;
			} else if (fuel > 9 * (100 / 13)) {
				Debug.Log ("menjaj");
				spriteVersion = 4;
			} else if (fuel > 8 * (100 / 13)) {
				spriteVersion = 5;
			} else if (fuel > 7 * (100 / 13)) {
				spriteVersion = 6;
			} else if (fuel > 6 * (100 / 13)) {
				spriteVersion = 7;
			} else if (fuel > 5 * (100 / 13)) {
				spriteVersion = 8;
			} else if (fuel > 4 * (100 / 13)) {
				spriteVersion = 9;
			} else if (fuel > 3 * (100 / 13)) {
				spriteVersion = 10;
			} else if (fuel > 2 * (100 / 13)) {
				spriteVersion = 11;
			} else if (fuel > 100 / 13) {
				spriteVersion = 12;
			}
			if (fuel > 1) {
				fuelSpriteRenderer.sprite = fuelSprites[spriteVersion];
			}
		}

	}
}
