using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RailMover : MonoBehaviour
{
    public Rail rail;

    public float speed = 17.0f;
    public bool isLooping;
    //public float direction;

    private int currentSeg;
    private float transition;
    private bool isCompleted;

    private void Update() {
        if (!rail)
            return;
        if (!isCompleted) {

           // direction = Input.GetAxis("Horizontal");
           if (Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow))
               Play();
           else if (Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow))
               Play(false);
        }

    }

    private void Play(bool direction = true) {

        float m = (rail.nodes[currentSeg + 1].position - rail.nodes[currentSeg].position).magnitude;
        float s = (Time.deltaTime * 1 / m) * speed;

        transition += (direction) ? s : -s;

        if (transition > 1) {
            transition = 0;
            currentSeg++;
            if (currentSeg == rail.nodes.Length - 1) {
                if (isLooping) {
                    currentSeg = 0;
                }
            }
        }
        else if(transition < 0) {
            transition = 1;
            currentSeg--;
            if (currentSeg == -1) {
                if (isLooping)
                    currentSeg = rail.nodes.Length - 2; 
            }
        }

        transform.position = rail.LinearPosition(currentSeg, transition);
        //transform.rotation = rail.Orientation(currentSeg, transition);
    }
}
