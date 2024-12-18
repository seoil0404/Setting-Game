using UnityEngine;

public class TargetAudioManager : MonoBehaviour
{
    public AudioSource audioSource; 
    public AudioClip hitSound;  
    public AudioClip missSound;     

    public void PlayHitSound()
    {
        if (audioSource != null && hitSound != null)
        {
            audioSource.PlayOneShot(hitSound);
        }
    }

    public void PlayMissSound()
    {
        if (audioSource != null && missSound != null)
        {
            audioSource.PlayOneShot(missSound);
        }
    }
}
