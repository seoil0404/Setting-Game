using UnityEngine;

public class Platform_UI : MonoBehaviour
{
    [SerializeField] private GameObject settingUserInterface;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(settingUserInterface.activeSelf)
            {
                settingUserInterface.SetActive(false);
            }
            else settingUserInterface.SetActive(true);
        }
    }
}
