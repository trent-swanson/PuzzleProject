using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour {

	public float moveSpeed = 1f;

	[Space]
	public Tile occupiedTile;

	bool isWalking = false;

	public void MoveForward() {
		if (transform.position == occupiedTile.tilePosition) {
			isWalking = false;
			if (occupiedTile.frontTile != null) {
				if (occupiedTile.frontTile.walkable) {
					occupiedTile.occupyingObject = null;
					Tile tempTile = occupiedTile.frontTile;
					occupiedTile = tempTile;
					occupiedTile.occupyingObject = this.gameObject;
					StartCoroutine(MoveToPosition(this.transform, occupiedTile.tilePosition, moveSpeed));
				}
			}
		} else {
			isWalking = true;
		}
	}

	public void MoveBack() {
		if (transform.position == occupiedTile.tilePosition) {
			isWalking = false;
			if (occupiedTile.backTile != null) {
				if (occupiedTile.backTile.walkable) {
					occupiedTile.occupyingObject = null;
					Tile tempTile = occupiedTile.backTile;
					occupiedTile = tempTile;
					occupiedTile.occupyingObject = this.gameObject;
					StartCoroutine(MoveToPosition(this.transform, occupiedTile.tilePosition, moveSpeed));
				}
			}
		} else {
			isWalking = true;
		}
	}

	public void MoveLeft() {
		if (transform.position == occupiedTile.tilePosition) {
			isWalking = false;
			if (occupiedTile.leftTile != null) {
				if (occupiedTile.leftTile.walkable) {
					occupiedTile.occupyingObject = null;
					Tile tempTile = occupiedTile.leftTile;
					occupiedTile = tempTile;
					occupiedTile.occupyingObject = this.gameObject;
					StartCoroutine(MoveToPosition(this.transform, occupiedTile.tilePosition, moveSpeed));
				}
			}
		} else {
			isWalking = true;
		}
	}

	public void MoveRight() {
		if (transform.position == occupiedTile.tilePosition) {
			isWalking = false;
			if (occupiedTile.rightTile != null) {
				if (occupiedTile.rightTile.walkable) {
					occupiedTile.occupyingObject = null;
					Tile tempTile = occupiedTile.rightTile;
					occupiedTile = tempTile;
					occupiedTile.occupyingObject = this.gameObject;
					StartCoroutine(MoveToPosition(this.transform, occupiedTile.tilePosition, moveSpeed));
				}
			}
		} else {
			isWalking = true;
		}
	}

	public IEnumerator MoveToPosition(Transform transform, Vector3 position, float timeToMove) {
      	Vector3 currentPos = transform.position;
      	float t = 0f;
    	while (t < 1) {
        	t += Time.deltaTime / timeToMove;
            transform.position = Vector3.Lerp(currentPos, position, t);
            yield return null;
		}
    }
}
