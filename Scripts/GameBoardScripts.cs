using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameBoardScripts : MonoBehaviour
{
    public GameObject[] tiles = null;
    public GameObject[] billboards = null;

    private void OnTriggerEnter(Collider other) {
     
    }


    public int getTotalTilesClaimed() {

        int count = 0;
        foreach (GameObject tile in tiles) {

            if (GetComponentInChildren<BallDetector>(tile).playerClaim != 0) {
                count++;
            }
        }
        return count;
    }

    public int getP1TileTotal() {

        int count = 0;
        foreach (GameObject tile in tiles) {

            if (GetComponentInChildren<BallDetector>(tile).playerClaim == 1) {
                count++;
            }
        }
        return count;
    }

    public int getP2TileTotal() {

        int count = 0;
        foreach (GameObject tile in tiles) {

            if (GetComponentInChildren<BallDetector>(tile).playerClaim == 2) {
                count++;
            }
        }
        return count;
    }

    // Update is called once per frame
    void Update()
    {
        int claimCt = 0, pOneCt = 0, pTwoCt = 0;
        foreach (GameObject billboard in billboards) {
            claimCt = getTotalTilesClaimed();
            pOneCt = getP1TileTotal();
            pTwoCt = getP2TileTotal();
            billboard.GetComponent<TextMeshPro>().SetText("Claimed: {0}\n P1: {1}\n P2: {2}", claimCt, pOneCt, pTwoCt);
        }
    }
}
