using UnityEngine;
using UnityEngine.Events;

public class RadialProgress : RadialFill {

    // Event to invoke when the progress bar fills up
    private UnityEvent onProgressComplete;

    // Create a property to handle the slider's value
    public new float CurrentValue {
        get {
            return base.CurrentValue;
        }
        set {
            // If the value exceeds the max fill, invoke the completion function
            if (value > maxValue)
                onProgressComplete.Invoke();

            // Remove any overfill (i.e. 105% fill -> 5% fill)
            base.CurrentValue = value % maxValue;
        }
    }

    // Use this for initialization
    void Start () {
        // Initialize onProgressComplete and set a basic callback
        if (onProgressComplete == null)
            onProgressComplete = new UnityEvent();
        onProgressComplete.AddListener(OnProgressComplete);
    }
	
    // Update is called once per frame
    void Update () {
        CurrentValue += 0.0273f;
    }

    // The method to call when the progress bar fills up
    void OnProgressComplete() {
        Debug.Log("Progress Complete");
    }
}
