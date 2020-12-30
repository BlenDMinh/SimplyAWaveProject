using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSourceConfig : MonoBehaviour {
    Text Selection;
    void Start() {
        Selection = GameObject.Find("Selection").GetComponent<Text>();
    }

    private InputField name, a, f, v, phi;
    private WaveSource source;

    private bool isUpdated = false;
    private string lastSelection;
    void Update() {
        if (Selection.text == "None") {
            GetComponent<CanvasGroup>().alpha = 0;
            isUpdated = false;
            return;
        }
        if (lastSelection != Selection.text)
            isUpdated = false;
        lastSelection = Selection.text;
        if (isUpdated)
            return;
        GetComponent<CanvasGroup>().alpha = 1;
        a = GameObject.Find("AmplitudeInput").GetComponent<InputField>();
        f = GameObject.Find("FrequencyInput").GetComponent<InputField>();
        v = GameObject.Find("VelocityInput").GetComponent<InputField>();
        phi = GameObject.Find("PhiInput").GetComponent<InputField>();
        source = GameObject.Find(Selection.text).GetComponent<WaveSource>();

        a.text = source.amplitude.ToString();
        f.text = source.frequency.ToString();
        v.text = source.velocity.ToString();
        phi.text = source.phi.ToString();
        isUpdated = true;
    }

    public void UpdateSource() {
        if (Selection.text == "None")
            return;
        source = GameObject.Find(Selection.text).GetComponent<WaveSource>();
        source.amplitude = float.Parse(a.text);
        source.frequency = float.Parse(f.text);
        source.velocity = float.Parse(v.text);
        source.phi = float.Parse(phi.text);
    }
}
