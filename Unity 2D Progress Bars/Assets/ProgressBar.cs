using UnityEngine;
using UnityEngine.Events;

public class ProgressBar : FillBar {

    // Event to invoke when the progress bar fills up
    private UnityEvent onProgressComplete;

    // Create a property to handle the slider's value
    public new float CurrentValue {
        get {
            return base.CurrentValue;
        }
        set {
            // If the value exceeds the max fill, invoke the completion function
            if (value > slider.maxValue)
                onProgressComplete.Invoke();

            // Remove any overfill (i.e. 105% fill -> 5% fill)
            base.CurrentValue = value % slider.maxValue;
        }
    }
    
    void Start () {
        // Initialize onProgressComplete and set a basic callback
        if (onProgressComplete == null)
            onProgressComplete = new UnityEvent();
        onProgressComplete.AddListener(OnProgressComplete);
    }
	
    void Update () {
        CurrentValue += 0.0153f;
    }

    // The method to call when the progress bar fills up
    void OnProgressComplete() {
        Debug.Log("Progress Complete");
    }
}
