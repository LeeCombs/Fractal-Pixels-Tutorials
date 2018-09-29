using UnityEngine;
using UnityEngine.UI;

public class RadialProgressBar : MonoBehaviour {

    // Public UI References
    public Image fillImage;
    public Text displayText;

    // Create a property to handle the slider's value
    private float currentValue = 0f;
    public float CurrentValue {
        get {
            return currentValue;
        }
        set {
            currentValue = Mathf.Min(value, 1);
            fillImage.fillAmount = currentValue;
            displayText.text = (currentValue * 100).ToString("0.00") + "%";
        }
    }

    void Start() {
        CurrentValue = 0f;
    }

    // Update is called once per frame
    void Update () {
        CurrentValue += 0.0043f;
    }
}
