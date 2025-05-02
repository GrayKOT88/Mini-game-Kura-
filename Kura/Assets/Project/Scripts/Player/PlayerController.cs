using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerMovement _playerMovement;
    private PlayerHealth _playerHealth;
    private PlayerAudio _playerAudio;

    private void Awake()
    {
        _playerMovement = GetComponent<PlayerMovement>();
        _playerHealth = GetComponent<PlayerHealth>();
        _playerAudio = GetComponent<PlayerAudio>();
        
        _playerHealth.OnGameOver += () => _playerMovement.SetGameOver(true);
        _playerHealth.OnDamageTaken += () => _playerAudio.PlayDamageSound();
    }
}