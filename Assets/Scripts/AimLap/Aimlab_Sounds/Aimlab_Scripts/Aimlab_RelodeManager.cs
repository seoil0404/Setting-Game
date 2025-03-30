using System.Collections;
using UnityEngine;

public class Aimlab_ReloadManager : MonoBehaviour
{
    public int maxAmmo = 10;
    public float reloadTime = 2.0f;
    public AudioSource audioSource;
    public AudioClip reloadSound;

    private int currentAmmo;
    private bool isReloading = false;
    public GameObject settingsPanel;
    public delegate void AmmoUpdated(int currentAmmo, int maxAmmo);
    public event AmmoUpdated OnAmmoUpdated;

    void Start()
    {
        currentAmmo = maxAmmo;
        UpdateAmmoUI();
    }

    public void Shoot()
    {
        if (isReloading) return;

        if (currentAmmo > 0)
        {
            currentAmmo--;
            UpdateAmmoUI();
        }
        else if (!isReloading)
        {
            StartCoroutine(Reload());
        }
    }

    private IEnumerator Reload()
    {
        if (isReloading) yield break;

        isReloading = true;

        if (audioSource != null && reloadSound != null)
        {
            audioSource.PlayOneShot(reloadSound);
        }

        float elapsedTime = 0f;

        while (elapsedTime < reloadTime)
        {
            if (!settingsPanelActive())
            {
                elapsedTime += Time.unscaledDeltaTime; 
            }
            yield return null;
        }

        currentAmmo = maxAmmo;
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

    private bool settingsPanelActive()
    {
   
        return settingsPanel != null && settingsPanel.activeSelf;
    }


    public void EnsureReloadContinues()
    {
        if (isReloading)
        {
            StopAllCoroutines();
            StartCoroutine(Reload()); 
        }
    }


}
