using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    [SerializeField] private AudioClip damageSound;
    private AudioSource _audioSource;    

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();        
    }

    public void PlayDamageSound()
    {
        _audioSource.PlayOneShot(damageSound, 1f);
    }
}