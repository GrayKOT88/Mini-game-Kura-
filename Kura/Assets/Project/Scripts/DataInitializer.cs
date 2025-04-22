using UnityEngine;

public class DataInitializer : MonoBehaviour
{
    [SerializeField] private PlayerDataSO _playerData;

    private void Awake()
    {        
        Progress.PlayerData = _playerData; // ������������� ������ �� ScriptableObject                
        Progress.LoadData();
    }
}