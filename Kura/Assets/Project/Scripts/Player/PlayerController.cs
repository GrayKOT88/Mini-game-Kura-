using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private AudioClip _damageSound;
    private PlayerMovement _playerMovement;
    private IHealthSystem _playerHealth;
    private  IAudioPlayable _playerAudio;

    private void Awake()
    {
        _playerMovement = GetComponent<PlayerMovement>();
        _playerHealth = GetComponent<IHealthSystem>();
        _playerAudio = GetComponent<IAudioPlayable>();
        
        _playerHealth.OnGameOver += () => _playerMovement.SetGameOver(true);
        _playerHealth.OnDamageTaken += () => _playerAudio.PlaySound(_damageSound,1);
    }
}