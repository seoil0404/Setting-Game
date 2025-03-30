using UnityEngine;
using UnityEngine.UI;

public class Aimlab_SensitivityController : MonoBehaviour
{
    public Slider sensitivitySlider; 
    public Aimlab_MouseSensitivity mouseSensitivity; 
    
    void Start()
    {
        sensitivitySlider.onValueChanged.AddListener(UpdateSensitivity);
    }

    void UpdateSensitivity(float value)
    {
        mouseSensitivity.sensitivity = value; 
    }
}
