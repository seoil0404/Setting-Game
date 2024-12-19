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
        else
        {
            StartCoroutine(Reload());
        }
    }

    private IEnumerator Reload()
    {
        isReloading = true;

       
        if (audioSource != null && reloadSound != null)
        {
            audioSource.PlayOneShot(reloadSound);
        }

        yield return new WaitForSeconds(reloadTime);

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
}
