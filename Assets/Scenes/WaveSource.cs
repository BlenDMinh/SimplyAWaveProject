using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UI;

public class WaveSource : MonoBehaviour {
    public string Name;
    public float amplitude = 0.3f, frequency = 5f, velocity = 5f, phi = 0f;

    private Vector3 mOffset;
    private float mZCoord;
    private Text Selection;

    private void Start() {
        Name = name;
        PositionConstraint positionConstraint = GetComponent<PositionConstraint>();
        ConstraintSource newSource = new ConstraintSource();
        newSource.sourceTransform = GetComponent<Transform>().parent;
        newSource.weight = 1;
        positionConstraint.AddSource(newSource);
        Selection =  GameObject.Find("Selection").GetComponent<Text>();
    }

    private bool mouseIsHold = false, accept = false;
    void OnMouseDown() {
        mouseIsHold = true;
        if(Selection.text == "None" || Selection.text != Name) {
            accept = false;
            return;
        }
        accept = true;
        if(!accept)
            return;
        mZCoord = Camera.main.WorldToScreenPoint(
        gameObject.transform.position).z;
        mOffset = gameObject.transform.position - GetMouseAsWorldPoint();
    }

    private void OnMouseUp() {
        mouseIsHold = false;
    }
    private Vector3 GetMouseAsWorldPoint() {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = mZCoord;
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    void OnMouseDrag() {
        if (Selection.text != Name || !accept)
            return;
        transform.position = GetMouseAsWorldPoint() + mOffset;
    }
}
