using UnityEngine;

public class DataInitializer : MonoBehaviour
{
    [SerializeField] private PlayerDataSO _playerData;

    private void Awake()
    {        
        Progress.PlayerData = _playerData; // Устанавливаем ссылку на ScriptableObject                
        Progress.LoadData();
    }
}