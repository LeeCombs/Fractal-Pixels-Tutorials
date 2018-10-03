using UnityEngine;
using UnityEngine.UI;

public class RadialFill : MonoBehaviour {

    // Public UI References
    public Image fillImage;
    public Text displayText;

    // Trackers for min/max values
    protected float maxValue = 2f, minValue = 0f;

    // Create a property to handle the slider's value
    private float currentValue = 0f;
    public float CurrentValue {
        get {
            return currentValue;
        }
        set {
            // Ensure the passed value falls within min/max range
            currentValue = Mathf.Clamp(value, minValue, maxValue);

            // Calculate the current fill percentage and display it
            float fillPercentage = currentValue / maxValue;
            fillImage.fillAmount = fillPercentage;
            displayText.text = (fillPercentage * 100).ToString("0.00") + "%";
        }
    }

    void Start() {
        CurrentValue = 0f;
    }

    // Update is called once per frame
    void Update () {
        CurrentValue += 0.0086f;
    }
}
