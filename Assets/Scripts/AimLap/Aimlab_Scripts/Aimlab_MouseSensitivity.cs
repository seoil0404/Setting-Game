using UnityEngine;

public class Aimlab_MouseSensitivity : MonoBehaviour
{
    public float sensitivity = 1.0f; // 기본 감도

    void Update()
    {
        Vector3 mouseDelta = new Vector3(
            Input.GetAxis("Mouse X") * sensitivity,
            Input.GetAxis("Mouse Y") * sensitivity,
            0f
        );
    }
}
