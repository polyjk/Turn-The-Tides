using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDetector : MonoBehaviour {
    public GameObject left;
    public GameObject right;

    public Color bluecolor;
    public Color redcolor;
    //if claim = 0 neutral, if claim = 1, player 1
    public int playerClaim;

    // Start is called before the first frame update
    void Start() {
        playerClaim = 0;
    }


    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player1")) {
            transform.GetComponent<Renderer>().material.color = bluecolor;
            playerClaim = 1;
        } else {
            transform.GetComponent<Renderer>().material.color = redcolor;
            playerClaim = 2;
        }
        other.gameObject.SetActive(false);
        flipLeft(playerClaim);
        flipRight(playerClaim);
    }

    void flipLeft(int basePlayer, GameObject previous = null) { 
        if (this.playerClaim != basePlayer && this.playerClaim != 0 || this.playerClaim == basePlayer && previous == null) {
            this.left.GetComponent<BallDetector>().flipLeft(basePlayer, gameObject);
        }
        if (this.left.GetComponent<BallDetector>().playerClaim == basePlayer && previous != null && this.playerClaim != 0) {
            ActuallyFlip(basePlayer);
        }
    }

    void flipRight(int basePlayer, GameObject previous = null) { 
        if (this.playerClaim != basePlayer && this.playerClaim != 0 || this.playerClaim == basePlayer && previous == null) {
            this.right.GetComponent<BallDetector>().flipRight(basePlayer, gameObject);
        }
        if (this.right.GetComponent<BallDetector>().playerClaim == basePlayer && previous != null && this.playerClaim != 0) {
            ActuallyFlip(basePlayer);
        }
    }

    void ActuallyFlip(int playerNewClaim) { 
        if(playerNewClaim == 1) {
            transform.GetComponent<Renderer>().material.color = bluecolor;
            playerClaim = 1;
            
        }
        else if(playerNewClaim == 2) {
            transform.GetComponent<Renderer>().material.color = redcolor;
            playerClaim = 2;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
