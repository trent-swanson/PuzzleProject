using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour {

	public float moveSpeed = 1f;

	[Space]
	public Tile occupiedTile;

	public bool isWalking = false;

	Tile previousTile;

	public bool MoveForward() {
		if (transform.position == occupiedTile.tilePosition) {
			isWalking = false;
			if (occupiedTile.frontTile != null) {
				if (occupiedTile.frontTile.walkable) {
					if (occupiedTile.frontTile.occupyingObject != null) {
						if (occupiedTile.frontTile.occupyingObject.tag == "Block") {
							if (occupiedTile.frontTile.occupyingObject.GetComponent<Block>().BlockMoveForward() == true) {
								occupiedTile.SetOccupyingObject(null);
								previousTile = occupiedTile;
								Tile temp_Tile = occupiedTile.frontTile;
								occupiedTile = temp_Tile;
								occupiedTile.SetOccupyingObject(this.gameObject);
								StartCoroutine(MoveToPosition(this.transform, occupiedTile.tilePosition, moveSpeed));
								return true;
							}
						}
					} else {
						occupiedTile.SetOccupyingObject(null);
						previousTile = occupiedTile;
						Tile tempTile = occupiedTile.frontTile;
						occupiedTile = tempTile;
						occupiedTile.SetOccupyingObject(this.gameObject);
						StartCoroutine(MoveToPosition(this.transform, occupiedTile.tilePosition, moveSpeed));
						return true;
					}
				}
			}
		} else {
			isWalking = true;
		}
		return false;
	}

	public bool MoveBack() {
		if (transform.position == occupiedTile.tilePosition) {
			isWalking = false;
			if (occupiedTile.backTile != null) {
				if (occupiedTile.backTile.walkable) {
					if (occupiedTile.backTile.occupyingObject != null) {
						if (occupiedTile.backTile.occupyingObject.tag == "Block") {
							if (occupiedTile.backTile.occupyingObject.GetComponent<Block>().BlockMoveBack() == true) {
								occupiedTile.SetOccupyingObject(null);
								previousTile = occupiedTile;
								Tile temp_Tile = occupiedTile.backTile;
								occupiedTile = temp_Tile;
								occupiedTile.SetOccupyingObject(this.gameObject);
								StartCoroutine(MoveToPosition(this.transform, occupiedTile.tilePosition, moveSpeed));
								return true;
							}
						}
					} else {
						occupiedTile.SetOccupyingObject(null);
						previousTile = occupiedTile;
						Tile tempTile = occupiedTile.backTile;
						occupiedTile = tempTile;
						occupiedTile.SetOccupyingObject(this.gameObject);
						StartCoroutine(MoveToPosition(this.transform, occupiedTile.tilePosition, moveSpeed));
						return true;
					}
				}
			}
		} else {
			isWalking = true;
		}
		return false;
	}

	public bool MoveLeft() {
		if (transform.position == occupiedTile.tilePosition) {
			isWalking = false;
			if (occupiedTile.leftTile != null) {
				if (occupiedTile.leftTile.walkable) {
					if (occupiedTile.leftTile.occupyingObject != null) {
						if (occupiedTile.leftTile.occupyingObject.tag == "Block") {
							if (occupiedTile.leftTile.occupyingObject.GetComponent<Block>().BlockMoveLeft() == true) {
								occupiedTile.SetOccupyingObject(null);
								previousTile = occupiedTile;
								Tile temp_Tile = occupiedTile.leftTile;
								occupiedTile = temp_Tile;
								occupiedTile.SetOccupyingObject(this.gameObject);
								StartCoroutine(MoveToPosition(this.transform, occupiedTile.tilePosition, moveSpeed));
								return true;
							}
						}
					} else {
						occupiedTile.SetOccupyingObject(null);
						previousTile = occupiedTile;
						Tile tempTile = occupiedTile.leftTile;
						occupiedTile = tempTile;
						occupiedTile.SetOccupyingObject(this.gameObject);
						StartCoroutine(MoveToPosition(this.transform, occupiedTile.tilePosition, moveSpeed));
						return true;
					}
				}
			}
		} else {
			isWalking = true;
		}
		return false;
	}

	public bool MoveRight() {
		if (transform.position == occupiedTile.tilePosition) {
			isWalking = false;
			if (occupiedTile.rightTile != null) {
				if (occupiedTile.rightTile.walkable) {
					if (occupiedTile.rightTile.occupyingObject != null) {
						if (occupiedTile.rightTile.occupyingObject.tag == "Block") {
							if (occupiedTile.rightTile.occupyingObject.GetComponent<Block>().BlockMoveRight() == true) {
								occupiedTile.SetOccupyingObject(null);
								previousTile = occupiedTile;
								Tile temp_Tile = occupiedTile.rightTile;
								occupiedTile = temp_Tile;
								occupiedTile.SetOccupyingObject(this.gameObject);
								StartCoroutine(MoveToPosition(this.transform, occupiedTile.tilePosition, moveSpeed));
								return true;
							}
						}
					} else {
						occupiedTile.SetOccupyingObject(null);
						previousTile = occupiedTile;
						Tile tempTile = occupiedTile.rightTile;
						occupiedTile = tempTile;
						occupiedTile.SetOccupyingObject(this.gameObject);
						StartCoroutine(MoveToPosition(this.transform, occupiedTile.tilePosition, moveSpeed));
						return true;
					}
				}
			}
		} else {
			isWalking = true;
		}
		return false;
	}

	public void AttackPlayer(GameObject player) {
		occupiedTile.SetOccupyingObject(null);
		previousTile = occupiedTile;
		StartCoroutine(MoveToPosition(this.transform, player.transform.position, moveSpeed, player));
	}

	public IEnumerator MoveToPosition(Transform transform, Vector3 position, float timeToMove) {
      	Vector3 currentPos = transform.position;
      	float t = 0f;
    	while (t < 1) {
        	t += Time.deltaTime / timeToMove;
            transform.position = Vector3.Lerp(currentPos, position, t);
			if (t >= 1) {
				occupiedTile.UpdateCrackedTile();
				previousTile.UpdateCrackedTile();
				GameManager.ChangeTurn();
			}
            yield return null;
		}
    }

	public IEnumerator MoveToPosition(Transform transform, Vector3 position, float timeToMove, GameObject player) {
      	Vector3 currentPos = transform.position;
      	float t = 0f;
    	while (t < 1) {
        	t += Time.deltaTime / timeToMove;
            transform.position = Vector3.Lerp(currentPos, position, t);
			if (t >= 1) {
				occupiedTile.UpdateCrackedTile();
				previousTile.UpdateCrackedTile();
				player.GetComponent<Player>().Die();
			}
            yield return null;
		}
    }
}
