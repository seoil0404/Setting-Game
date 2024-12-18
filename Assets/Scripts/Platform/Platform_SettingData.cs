using Unity.VisualScripting;
using UnityEngine;



[CreateAssetMenu(fileName = "Platform_SettingData", menuName = "Scriptable Objects/Platform_SettingData")]
public class Platform_SettingData : ScriptableObject
{
    [SerializeField] private float backgroundMusicScale;
    [SerializeField] private float effectSoundScale;
    [SerializeField] private float playerMoveSpeed;
    [SerializeField] private bool isGravity;
    [SerializeField] private bool isCameraFollow;
    [SerializeField] private bool isGoalRun;
    [SerializeField] private bool isSinkholeGenerate;
    [SerializeField] private bool isPlayerCanAttack;
    [SerializeField] private float playerJumpPower;
    [SerializeField] private bool isPlayerStable;
    public KeySetting keySetting;

    [System.Serializable]
    public struct KeySetting
    {
        public KeyCode leftMoveKey;
        public KeyCode rightMoveKey;
        public KeyCode jumpKey;
    }

    public bool IsPlayerStable
    {
        get
        {
            return isPlayerStable;
        }
        set
        {
            isPlayerStable = value;
        }
    }

    public float BackGroundMusicScale
    {
        get
        {
            return this.backgroundMusicScale;
        }
        set
        {
            if(value < 0) this.backgroundMusicScale = 0;
            else if(value > 10) this.backgroundMusicScale = 10;
            else this.backgroundMusicScale = value;
        }
    }
    public float EffectSoundScale
    {
        get
        {
            return this.effectSoundScale;
        }
        set
        {
            if (value < 0) this.effectSoundScale = 0;
            else if (value > 10) this.effectSoundScale = 10;
            else this.effectSoundScale = value;
        }
    }
    public float PlayerMoveSpeed
    {
        get
        { 
            return this.playerMoveSpeed;
        }
        set
        {
            if (value < 0) this.playerMoveSpeed = 0;
            else if (value > 10) this.playerMoveSpeed = 10;
            else this.playerMoveSpeed = value;
        }
    }
    public bool IsGravity
    {
        get
        {
            return this.isGravity;
        }
        set
        {
            isGravity = value;
        }
    }
    public bool IsCameraFollow
    {
        get
        {
            return this.isCameraFollow;
        }
        set
        { 
            this.isCameraFollow = value; 
        }
    }
    public bool IsGoalRun
    {
        get
        {
            return this.isGoalRun;
        }
        set
        {
            this.isGoalRun = !value;
        }
    }
    public bool IsSinkholeGenerate
    {
        get
        {
            return this.isSinkholeGenerate;
        }
        set
        {
            this.isSinkholeGenerate = !value;
        }
    }
    public bool IsPlayerCanAttack
    {
        get
        {
            return this.isPlayerCanAttack;
        }
        set
        {
            this.isPlayerCanAttack = !value;
        }
    }
    public float PlayerJumpPower
    {
        get
        {
            return this.playerJumpPower;
        }
        set
        {
            if (value < 0) this.playerJumpPower = 0;
            else if (value > 10) this.playerJumpPower = 10;
            else this.playerJumpPower = value;
        }
    }
}
