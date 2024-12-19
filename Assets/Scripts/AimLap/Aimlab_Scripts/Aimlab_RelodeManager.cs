using System.Collections;
using UnityEngine;

public class Aimlab_ReloadManager : MonoBehaviour
{
    public int maxAmmo = 10;           // 최대 총알 수
    public float reloadTime = 2.0f;   // 장전 시간
    public AudioSource audioSource;  // 오디오 소스
    public AudioClip reloadSound;    // 장전 소리

    private int currentAmmo;          // 현재 총알 수
    private bool isReloading = false; // 장전 중 여부

    public delegate void AmmoUpdated(int currentAmmo, int maxAmmo);
    public event AmmoUpdated OnAmmoUpdated;

    void Start()
    {
        currentAmmo = maxAmmo; // 초기 총알 설정
        UpdateAmmoUI();
    }

    public void Shoot()
    {
        if (isReloading) return; // 장전 중일 때는 발사 불가

        if (currentAmmo > 0)
        {
            currentAmmo--;
            UpdateAmmoUI();
        }
        else
        {
            StartCoroutine(Reload());
        }
    }

    private IEnumerator Reload()
    {
        isReloading = true;

        // 장전 소리 재생
        if (audioSource != null && reloadSound != null)
        {
            audioSource.PlayOneShot(reloadSound);
        }

        yield return new WaitForSeconds(reloadTime);

        currentAmmo = maxAmmo; // 총알 리셋
        isReloading = false;

        UpdateAmmoUI();
    }

    public int GetCurrentAmmo()
    {
        return currentAmmo;
    }

    private void UpdateAmmoUI()
    {
        OnAmmoUpdated?.Invoke(currentAmmo, maxAmmo);
    }
}
