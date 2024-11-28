using UnityEngine;
using UnityEngine.UIElements;

public class CharacterInfo : MonoBehaviour
{
    [SerializeField] private float floatValue = 10f;

    private FloatField floatField;

    private void OnEnable()
    {
        // Get the root visual element
        var root = GetComponent<UIDocument>().rootVisualElement;

        // Locate the FloatField
        floatField = root.Q<FloatField>("Velocity");

        // Set initial value and register for user input changes
        if (floatField != null)
        {
            floatField.value = floatValue;
            floatField.RegisterValueChangedCallback(evt =>
            {
                floatValue = evt.newValue;
            });
        }
        else
        {
            Debug.LogError("FloatField with the name 'floatValueField' not found!");
        }
    }

    public void SetFloatValue(float newValue)
    {
        // Update internal variable
        floatValue = newValue;

        // Update FloatField value in the UI
        if (floatField != null)
        {
            floatField.value = floatValue;
        }
        else
        {
            Debug.LogWarning("FloatField is null! Ensure it is initialized correctly.");
        }
    }
}
