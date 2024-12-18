using System.Collections;
using DG.Tweening;
using UnityEngine;

public class Platform_UI : MonoBehaviour
{
    [SerializeField] private GameObject settingUserInterface;
    [SerializeField] private Platform_Player player;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Setting();
        }
    }

    public void Setting()
    {
        if (settingUserInterface.activeSelf)
        {
            player.IsAcceptMove = true;
            settingUserInterface.SetActive(false);
        }
        else
        {
            player.IsAcceptMove = false;
            settingUserInterface.SetActive(true);
            DOTween.Kill(settingUserInterface.transform);
            settingUserInterface.transform.localScale = Vector3.zero;
            settingUserInterface.transform.DOScale(Vector3.one, 0.5f).SetEase(Ease.OutQuint);
        }
    }
}
