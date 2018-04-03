using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour {

	public float moveSpeed = 1f;

	[Space]
	public Tile occupiedTile;

	public bool isWalking = false;

	Tile previousTile;
	GameObject tempOccupyingObject;

	void ChangeOccupiedTile(Tile new_Tile) {
		occupiedTile.SetOccupyingObject(null);
		previousTile = occupiedTile;
		Tile temp_Tile = new_Tile;
		occupiedTile = temp_Tile;
		occupiedTile.SetOccupyingObject(this.gameObject);
	}

	bool MoveBlock(Tile new_Tile) {
		if (new_Tile == occupiedTile.frontTile) {
			return new_Tile.occupyingObject.GetComponent<Block>().BlockMove(new_Tile.frontTile);
		} else if (new_Tile == occupiedTile.backTile) {
			return new_Tile.occupyingObject.GetComponent<Block>().BlockMove(new_Tile.backTile);
		} else if (new_Tile == occupiedTile.leftTile) {
			return new_Tile.occupyingObject.GetComponent<Block>().BlockMove(new_Tile.leftTile);
		} else if (new_Tile == occupiedTile.rightTile) {
			return new_Tile.occupyingObject.GetComponent<Block>().BlockMove(new_Tile.rightTile);
		}
		return false;
	}

	public bool Move(Tile newTile) {
		if (transform.position == occupiedTile.tilePosition) {
			isWalking = false;
			if (newTile != null && newTile.walkable) {
				if (newTile.occupyingObject != null && newTile.occupyingObject.tag == "Block") {
					if (MoveBlock(newTile) == true) {
						ChangeOccupiedTile(newTile);
						StartCoroutine(MoveToPosition(this.transform, occupiedTile.tilePosition, moveSpeed));
						return true;
					}
				} else if (newTile.occupyingObject != null && newTile.occupyingObject.tag == "Enemy") {
					tempOccupyingObject = newTile.occupyingObject;
					ChangeOccupiedTile(newTile);
					StartCoroutine(MoveToPosition(this.transform, occupiedTile.tilePosition, moveSpeed, tempOccupyingObject, false));
					return true;
				} else {
					ChangeOccupiedTile(newTile);
					StartCoroutine(MoveToPosition(this.transform, occupiedTile.tilePosition, moveSpeed));
					return true;
				}
			}
		} else {
			isWalking = true;
		}
		return false;
	}

	public bool BlockMove(Tile newTile) {
		if (transform.position == occupiedTile.tilePosition) {
			isWalking = false;
			if (newTile != null && newTile.walkable && newTile.occupyingObject == null) {
				ChangeOccupiedTile(newTile);
					StartCoroutine(MoveToPosition(this.transform, occupiedTile.tilePosition, moveSpeed));
					return true;
			}
			else {
				return false;
			}
		} else {
			isWalking = true;
		}
		return false;
	}

	public void AttackPlayer(GameObject player) {
		occupiedTile.SetOccupyingObject(null);
		previousTile = occupiedTile;
		StartCoroutine(MoveToPosition(this.transform, player.transform.position, moveSpeed, player, true));
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

	public IEnumerator MoveToPosition(Transform transform, Vector3 position, float timeToMove, GameObject agentToDie, bool isPlayer) {
      	Vector3 currentPos = transform.position;
      	float t = 0f;
    	while (t < 1) {
        	t += Time.deltaTime / timeToMove;
            transform.position = Vector3.Lerp(currentPos, position, t);
			if (t >= 1) {
				occupiedTile.UpdateCrackedTile();
				previousTile.UpdateCrackedTile();
				if (isPlayer)
					agentToDie.GetComponent<Player>().Die();
				else
					agentToDie.GetComponent<Enemy>().Die();
				yield return new WaitForSeconds(0.01f);
				GameManager.ChangeTurn();
			}
            yield return null;
		}
    }
}
