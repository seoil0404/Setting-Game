using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Platform_GameManager : MonoBehaviour
{
    [SerializeField] private GameObject victory;
    [SerializeField] private GameObject defeat;
    [SerializeField] private Platform_Player player;
    [SerializeField] private Platform_SettingData settingData;
    [SerializeField] private AudioSource backGroundAudio;
    [SerializeField] private AudioSource defeatAudio;
    [SerializeField] private AudioSource victoryAudio;
    [SerializeField] private AudioSource jumpAudio;

    private void Awake()
    {
        victory.SetActive(false);
        defeat.SetActive(false);
    }

    public void ChangeBackGroundMusicScale()
    {
        backGroundAudio.volume = settingData.BackGroundMusicScale * 0.1f;
        defeatAudio.volume = settingData.BackGroundMusicScale * 0.1f;
        victoryAudio.volume = settingData.BackGroundMusicScale * 0.1f;
    }

    public void ChangeEffectSound()
    {
        jumpAudio.volume = settingData.EffectSoundScale * 0.1f;
    }

    public void Defeat()
    {
        backGroundAudio.Stop();
        defeatAudio.Play();
        
        defeat.SetActive(true);
        
        defeat.transform.localScale = Vector3.zero;
        defeat.transform.DOScale(Vector3.one, 1f).SetEase(Ease.OutQuint);

        Stop();

        Debug.Log("Defeat");
    }

    public void Victory()
    {
        backGroundAudio.Stop();
        victoryAudio.Play();

        victory.SetActive(true);
        
        victory.transform.localScale = Vector3.zero;
        victory.transform.DOScale(Vector3.one, 1f).SetEase(Ease.OutQuint);

        Stop();

        Debug.Log("Victory");
    }

    public void Restart()
    {
        SceneManager.LoadScene("PlatformScene");
    }

    public void NextLevel()
    {
        SceneManager.LoadScene("AimlabScene");
    }

    private void Stop()
    {
        player.OnDeath();
    }
}
