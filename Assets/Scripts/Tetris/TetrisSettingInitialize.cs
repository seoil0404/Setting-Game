using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TetrisSettingInitialize : MonoBehaviour
{
    [SerializeField] private TetrisSetting Data;

    [SerializeField] private Slider m_backGroundMusic;
    [SerializeField] private Slider m_effectSound;
    [SerializeField] private Slider m_dropSpeed;


    [SerializeField] private Toggle m_minoRandom;
    [SerializeField] private Toggle m_minoScore;
    [SerializeField] private Toggle m_minoGravity;
    [SerializeField] private Toggle m_isFloor;


    [SerializeField] private TextMeshProUGUI m_leftKeyText;
    [SerializeField] private TextMeshProUGUI m_rightKeyText;
    [SerializeField] private TextMeshProUGUI m_downKeyText;
    [SerializeField] private TextMeshProUGUI m_spinKeyText;

    private void Awake()
    {
        m_backGroundMusic.value = Data.BackGroundMusicScale;
        m_effectSound.value = Data.EffectSoundScale;
        m_dropSpeed.value = Data.MinoDropSpeed;

        m_minoRandom.isOn = Data.IsMinoRandom;
        m_minoScore.isOn = Data.MinoScore;
        m_minoGravity.isOn = Data.IsMinoGravity;
        m_isFloor.isOn = Data.IsFloor;

        m_leftKeyText.text = Data.keySetting.leftMoveKey.ToString();
        m_rightKeyText.text = Data.keySetting.rightMoveKey.ToString();
        m_downKeyText.text = Data.keySetting.downKey.ToString();
        m_spinKeyText.text = Data.keySetting.spinKey.ToString();
    }
}
