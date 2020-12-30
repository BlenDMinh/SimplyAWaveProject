using UnityEngine;
using UnityEngine.UI;

public class SelectionManager : MonoBehaviour {

    private Text Selection;
    private void Start() {
        Selection = GameObject.Find("Selection").GetComponent<Text>();
    }
    private void Update() {
        if (!Input.GetMouseButtonDown(0))
            return;
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit)) {
            var selection = hit.transform.gameObject;
            if (!selection.GetComponent<WaveSource>())
                Selection.text = "None";
            else {
                Selection.text = selection.GetComponent<WaveSource>().name;

            }
        } else {
            Selection.text = "None";
        }
    }
}