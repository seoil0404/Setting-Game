using DG.Tweening;
using UnityEngine;

public class Platform_GameManager : MonoBehaviour
{
    [SerializeField] private GameObject victory;
    [SerializeField] private GameObject defeat;
    [SerializeField] private Platform_Player player;
    [SerializeField] private Platform_SettingData settingData;

    private void Awake()
    {
        victory.SetActive(false);
        defeat.SetActive(false);
    }
    public void Defeat()
    {
        defeat.SetActive(true);
        defeat.transform.localScale = Vector3.zero;
        defeat.transform.DOScale(Vector3.one, 1f).SetEase(Ease.OutQuint);

        Stop();

        Debug.Log("Defeat");
    }

    public void Victory()
    {
        victory.SetActive(true);
        victory.transform.localScale = Vector3.zero;
        victory.transform.DOScale(Vector3.one, 1f).SetEase(Ease.OutQuint);

        Stop();

        Debug.Log("Victory");
    }

    private void Stop()
    {
        player.OnDeath();
        //settingData.IsCameraFollow = false;
    }
}
