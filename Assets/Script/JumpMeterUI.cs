using UnityEngine;
using UnityEngine.UI;

public class JumpMeterUI : MonoBehaviour
{
    private Slider slider;

    private void Awake()
    {
        slider = GetComponent<Slider>();
    }

    public void SetValue(float value)
    {
        if (slider != null)
        {
            slider.value = value;
            Debug.Log("UI SetValue: " + value + " / Slider.maxValue: " + slider.maxValue);
        }
    }
}
