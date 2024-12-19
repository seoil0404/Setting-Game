using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

[CreateAssetMenu(fileName = "TetrisSetting", menuName = "Scriptable Objects/TetrisSetting")]
public class TetrisSetting : ScriptableObject
{
    [SerializeField] private float m_backgroundMusicScale;
    [SerializeField] private float m_effectSoundScale;
    [SerializeField] private float m_minoDropSpeed;

    [SerializeField] private bool m_isMinoRandom;
    [SerializeField] private bool m_isMinoGravity;
    [SerializeField] private bool m_isFloor;
    [SerializeField] private bool m_minoScore;


    public KeySetting keySetting;

    [System.Serializable]
    public struct KeySetting
    {
        public KeyCode leftMoveKey;
        public KeyCode rightMoveKey;
        public KeyCode downKey;
        public KeyCode spinKey;
    }

    public float BackGroundMusicScale
    {
        get
        {
            return m_backgroundMusicScale;
        }
        set
        {
            if (value < 0) m_backgroundMusicScale = 0;
            else if (value > 10) m_backgroundMusicScale = 10;
            else m_backgroundMusicScale = value;
        }
    }
    public float EffectSoundScale
    {
        get
        {
            return m_effectSoundScale;
        }
        set
        {
            if (value < 0) m_effectSoundScale = 0;
            else if (value > 10) m_effectSoundScale = 10;
            else m_effectSoundScale = value;
        }
    }
    public bool IsMinoRandom
    {
        get
        {
            return m_isMinoRandom;
        }

        set
        {
            m_isMinoRandom = value;
        }
    }
    public bool IsMinoGravity
    {
        get
        {
            return m_isMinoGravity;
        }
        set
        {
            m_isMinoGravity = value;
        }
    }
    public bool IsFloor
    {
        get
        {
            return m_isFloor;
        }
        set
        {
            m_isFloor = value;
        }
    }
    public bool MinoScore
    {
        get
        {
            return m_minoScore;
        }
        set
        {
            m_minoScore = value;
        }
    }
    public float MinoDropSpeed
    {
        get
        {
            return m_minoDropSpeed;   
        }
        set
        {
            if (value < 0) m_minoDropSpeed = 0;
            else if (value > 10) m_minoDropSpeed = 10;
            else m_minoDropSpeed = value;
        }
    }
}
