using TMPro;
using UnityEngine;

public class TetrisKeyBind : MonoBehaviour
{
    private KeyBind keyBind = KeyBind.None;

    [SerializeField] private TetrisSetting Data;

    [SerializeField] private TextMeshProUGUI leftKeyText;
    [SerializeField] private TextMeshProUGUI rightKeyText;
    [SerializeField] private TextMeshProUGUI downKeyText;
    [SerializeField] private TextMeshProUGUI spinKeyText;

    public enum KeyBind
    {
        LeftKey, RightKey, DownKey,SpinKey ,None
    }
    public void LeftMove()
    {
        keyBind = KeyBind.LeftKey;
    }

    public void RightMove()
    {
        keyBind = KeyBind.RightKey;
    }
    public void DownMove()
    {
        keyBind = KeyBind.DownKey;
    }
    public void SpinMove()
    {
        keyBind = KeyBind.SpinKey;
    }

    private void Update()
    {
        if (keyBind != KeyBind.None && Input.anyKeyDown)
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
                    Data.keySetting.leftMoveKey = currentKey;
                    leftKeyText.text = currentKey.ToString();
                    break;
                case KeyBind.RightKey:
                    Data.keySetting.rightMoveKey = currentKey;
                    rightKeyText.text = currentKey.ToString();
                    break;
                case KeyBind.DownKey:
                    Data.keySetting.downKey = currentKey;
                    downKeyText.text = currentKey.ToString();
                    break;
                case KeyBind.SpinKey:
                    Data.keySetting.spinKey = currentKey;
                    spinKeyText.text = currentKey.ToString();
                    break;
            }

            keyBind = KeyBind.None;
        }
    }
}
