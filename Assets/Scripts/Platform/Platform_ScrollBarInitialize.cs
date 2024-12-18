using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Platform_ScrollBarInitialize : MonoBehaviour
{
    [SerializeField] private Platform_SettingData Data;
    [SerializeField] private Platform_Player Player;

    [Header("Settings")]
    
    [SerializeField] private Slider backGroundMusic;
    [SerializeField] private Slider effectSound;
    
    [SerializeField] private AudioSource backGroundAudio;
    [SerializeField] private AudioSource jumpSoundAudio;
    [SerializeField] private AudioSource defeatAudio;
    [SerializeField] private AudioSource victoryAudio;

    [SerializeField] private Slider speed;
    [SerializeField] private Slider jumpPower;

    [SerializeField] private Toggle cameraFollow;
    [SerializeField] private Toggle canAttack;
    [SerializeField] private Toggle gravity;
    [SerializeField] private Toggle goalRun;
    [SerializeField] private Toggle sinkHole;
    [SerializeField] private Toggle characterStable;

    [SerializeField] private TextMeshProUGUI leftKeyText;
    [SerializeField] private TextMeshProUGUI rightKeyText;
    [SerializeField] private TextMeshProUGUI jumpKeyText;

    private void Awake()
    {
        backGroundMusic.value = Data.BackGroundMusicScale;

        backGroundAudio.volume = backGroundMusic.value * 0.1f;
        defeatAudio.volume = backGroundMusic.value * 0.1f;
        victoryAudio.volume = backGroundMusic.value * 0.1f;

        effectSound.value = Data.EffectSoundScale;

        jumpSoundAudio.volume = effectSound.value * 0.1f;

        speed.value = Data.PlayerMoveSpeed;
        jumpPower.value = Data.PlayerJumpPower;
        cameraFollow.isOn = Data.IsCameraFollow;
        canAttack.isOn = !Data.IsPlayerCanAttack;
        gravity.isOn = Data.IsGravity;
        goalRun.isOn = !Data.IsGoalRun;
        sinkHole.isOn = !Data.IsSinkholeGenerate;
        characterStable.isOn = Player.IsStable;
        leftKeyText.text = Data.keySetting.leftMoveKey.ToString();
        rightKeyText.text = Data.keySetting.rightMoveKey.ToString();
        jumpKeyText.text = Data.keySetting.jumpKey.ToString();
    }
}
