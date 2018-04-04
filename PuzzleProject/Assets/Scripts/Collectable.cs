﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour {

    void OnTriggerEnter(Collider other) {
		if (other.tag == "Player") {
            other.GetComponent<Player>().UpdateCollectables();
            Destroy(this.gameObject);
		}
	}
	
}
