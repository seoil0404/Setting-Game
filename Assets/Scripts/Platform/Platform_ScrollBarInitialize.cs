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
        effectSound.value = Data.EffectSoundScale;
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
