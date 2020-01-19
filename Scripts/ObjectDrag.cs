using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDrag : MonoBehaviour
{
    private Vector3 mouseOffset;
    private float mouseZCoord;

    public Rigidbody rb;

    private Plane plane = new Plane(Vector3.up, Vector3.zero);

    [SerializeField] private float throwForce;

    void OnMouseDown() {

        mouseZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        mouseOffset = gameObject.transform.position - GetMouseWorldPos();
    }

    private Vector3 GetMouseWorldPos() {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = mouseZCoord;
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    void OnMouseDrag() {
        transform.position = GetMouseWorldPos() + mouseOffset;
    }

    void OnMouseUpAsButton() {

        rb.AddForce(Camera.main.transform.forward * throwForce);
    }
}
