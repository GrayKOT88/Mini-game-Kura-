using UnityEngine;
using Zenject;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private AudioClip _damageSound;
    private PlayerMovement _playerMovement;
    private IHealthSystem _playerHealth;
    private  IAudioPlayable _playerAudio;

    [Inject] private void Construct(IHealthSystem healthSystem, IAudioPlayable audioSystem)
    {
        _playerHealth = healthSystem;
        _playerAudio = audioSystem;
    }

    private void Awake()
    {
        _playerMovement = GetComponent<PlayerMovement>();
        
        _playerHealth.OnGameOver += () => _playerMovement.SetGameOver(true);
        _playerHealth.OnDamageTaken += () => _playerAudio.PlaySound(_damageSound,1);
    }
}