﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour {

	public bool cracked = false;
	bool walkedOn = false;
	bool broken = false;
	public bool walkable;
	public Vector3 tilePosition;
	public GameObject occupyingObject;

	public Tile leftTile, rightTile, frontTile, backTile;

	void Start() {
		walkable = true;
		tilePosition = new Vector3 (transform.position.x, 1f, transform.position.z);

		//cracked tile
		if (cracked) {
			Color mat = GetComponent<Renderer>().materials[1].color;
			mat.a = 0.55f;
			GetComponent<Renderer>().materials[1].color = mat;
		}

		RaycastHit hit;

		Vector3 fwd = new Vector3 (0,0,1);
		if (Physics.Raycast(transform.position, fwd, out hit, 3f)) {
			if (hit.transform.tag == "Tile") {
				frontTile = hit.transform.GetComponent<Tile>();
			}
		}

		Vector3 back = new Vector3 (0,0,-1);
		if (Physics.Raycast(transform.position, back, out hit, 3f)) {
			if (hit.transform.tag == "Tile") {
				backTile = hit.transform.GetComponent<Tile>();
			}
		}

		Vector3 left = new Vector3 (-1,0,0);
		if (Physics.Raycast(transform.position, left, out hit, 3f)) {
			if (hit.transform.tag == "Tile") {
				leftTile = hit.transform.GetComponent<Tile>();
			}
		}

		Vector3 right = new Vector3 (1,0,0);
		if (Physics.Raycast(transform.position, right, out hit, 3f)) {
			if (hit.transform.tag == "Tile") {
				rightTile = hit.transform.GetComponent<Tile>();
			}
		}

		Vector3 up = new Vector3 (0,1,0);
		if (Physics.Raycast(transform.position, up, out hit, 2f)) {
			if (hit.transform.tag == "Obstacle") {
				occupyingObject = hit.transform.gameObject;
				walkable = false;
			}
			if (hit.transform.tag == "Objective") {
				occupyingObject = hit.transform.gameObject;
			}
			if (hit.transform.tag == "Block") {
				occupyingObject = hit.transform.gameObject;
				occupyingObject.GetComponent<Block>().occupiedTile = this;
			}
			if (hit.transform.tag == "Player") {
				occupyingObject = hit.transform.gameObject;
				occupyingObject.GetComponent<Player>().occupiedTile = this;
			}
			if (hit.transform.tag == "Enemy") {
				occupyingObject = hit.transform.gameObject;
				occupyingObject.GetComponent<Enemy>().occupiedTile = this;
			}
		}
	}

	void Update() {
		//Debugging
		Vector3 fwd = new Vector3 (0,0,3);
		Vector3 back = new Vector3 (0,0,-3);
		Vector3 left = new Vector3 (-3,0,0);
		Vector3 right = new Vector3 (3,0,0);
		Vector3 up = new Vector3 (0,2,0);
		Debug.DrawRay(transform.position, fwd, Color.red);
		Debug.DrawRay(transform.position, back, Color.green);
		Debug.DrawRay(transform.position, left, Color.blue);
		Debug.DrawRay(transform.position, right, Color.black);
		Debug.DrawRay(transform.position, up, Color.cyan);
	}

	public void UpdateCrackedTile() {
		if (cracked && walkedOn) {
			if (!broken) {
				Color mat = GetComponent<Renderer>().materials[1].color;
				mat.a = 1f;
				GetComponent<Renderer>().materials[1].color = mat;
				walkedOn = true;
			} else {
				Destroy(this.gameObject);
			}
		}
	}

	public void SetOccupyingObject(GameObject _gameObject) {
		occupyingObject = _gameObject;
		if (_gameObject != null) {
			if (_gameObject.tag == "Player" && cracked) {
				walkedOn = true;
			}
		} else {
			if (walkedOn == true) {
				broken = true;
			}
		}
	}

	public GameObject GetOccupyingObject() {
		return occupyingObject;
	}
}
