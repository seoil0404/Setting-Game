using System.Collections;
using UnityEngine;

public class Aimlab_ReloadManager : MonoBehaviour
{
    public int maxAmmo = 10;           // �ִ� �Ѿ� ��
    public float reloadTime = 2.0f;   // ���� �ð�
    public AudioSource audioSource;  // ����� �ҽ�
    public AudioClip reloadSound;    // ���� �Ҹ�

    private int currentAmmo;          // ���� �Ѿ� ��
    private bool isReloading = false; // ���� �� ����

    public delegate void AmmoUpdated(int currentAmmo, int maxAmmo);
    public event AmmoUpdated OnAmmoUpdated;

    void Start()
    {
        currentAmmo = maxAmmo; // �ʱ� �Ѿ� ����
        UpdateAmmoUI();
    }

    public void Shoot()
    {
        if (isReloading) return; // ���� ���� ���� �߻� �Ұ�

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

        // ���� �Ҹ� ���
        if (audioSource != null && reloadSound != null)
        {
            audioSource.PlayOneShot(reloadSound);
        }

        yield return new WaitForSeconds(reloadTime);

        currentAmmo = maxAmmo; // �Ѿ� ����
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
