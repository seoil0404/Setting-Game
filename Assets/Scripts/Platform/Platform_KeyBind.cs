using TMPro;
using UnityEngine;

public class Platform_KeyBind : MonoBehaviour
{
    private KeyBind keyBind = KeyBind.None;

    [SerializeField] private Platform_SettingData settingData;

    [SerializeField] private TextMeshProUGUI leftKeyText;
    [SerializeField] private TextMeshProUGUI rightKeyText;
    [SerializeField] private TextMeshProUGUI jumpKeyText;

    public enum KeyBind
    {
        LeftKey, RightKey, JumpKey, None
    }

    public void LeftMove()
    {
        keyBind = KeyBind.LeftKey;
    }

    public void RightMove()
    {
        keyBind = KeyBind.RightKey;
    }

    public void Jump()
    {
        keyBind = KeyBind.JumpKey;
    }

    private void Update()
    {
        if(keyBind != KeyBind.None && Input.anyKeyDown)
        {

            KeyCode currentKey = KeyCode.None;

            foreach (KeyCode keyCode in System.Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKeyDown(keyCode))
                {
                    currentKey = keyCode;
                    break;
                }
            }

            switch (keyBind)
            {
                case KeyBind.LeftKey:
                    settingData.keySetting.leftMoveKey = currentKey;
                    leftKeyText.text = currentKey.ToString();
                    break;
                case KeyBind.RightKey:
                    settingData.keySetting.rightMoveKey = currentKey;
                    rightKeyText.text = currentKey.ToString();
                    break;
                case KeyBind.JumpKey:
                    settingData.keySetting.jumpKey = currentKey;
                    jumpKeyText.text = currentKey.ToString();
                    break;
            }

            keyBind = KeyBind.None;
        }
    }
}
