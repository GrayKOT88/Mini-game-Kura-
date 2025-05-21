using UnityEngine;
using Zenject;

public class DataInitializer : MonoBehaviour
{
    [Inject] private PlayerDataSO _playerData;

    private void Awake()
    {        
        Progress.PlayerData = _playerData; // ������������� ������ �� ScriptableObject                
        Progress.LoadData();
    }
}