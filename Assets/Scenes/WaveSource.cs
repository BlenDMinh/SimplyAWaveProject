using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class WaveSource : MonoBehaviour {
    public float amplitude = 0.3f, frequency = 5f, velocity = 5f, phi = 0f;

    private Vector3 mOffset;
    private float mZCoord;

    private void Start() {
        PositionConstraint positionConstraint = GetComponent<PositionConstraint>();
        ConstraintSource newSource = new ConstraintSource();
        newSource.sourceTransform = GetComponent<Transform>().parent;
        positionConstraint.SetSource(1, newSource);
    }

    void OnMouseDown() {
        mZCoord = Camera.main.WorldToScreenPoint(
        gameObject.transform.position).z;
        mOffset = gameObject.transform.position - GetMouseAsWorldPoint();
    }

    private Vector3 GetMouseAsWorldPoint() {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = mZCoord;
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    void OnMouseDrag() {
        transform.position = GetMouseAsWorldPoint() + mOffset;
    }
}
