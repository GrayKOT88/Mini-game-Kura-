using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    // ���������
    [SerializeField] private AnimalSettings _animalSettings;
    [SerializeField] private PlayerDataSO _playerData;
    // ����
    [SerializeField] private FoxPool _foxPool;
    [SerializeField] private ChickPool _chickPool;
    [SerializeField] private ExplosionRedPool _explosionRedPool;
    // �������
    [SerializeField] private Transform _player;
    [SerializeField] private List<Transform> _spawnPoints;
    // UI � �������
    [SerializeField] private ScoreManager _scoreManager;
    [SerializeField] private AchievementManager _achievementManager;
    [SerializeField] private ScoreSaver _scoreSaver;
    [SerializeField] private Counter _counter;
    [SerializeField] private HealthBarScript _healthBar;
    [SerializeField] private GameObject _gameOverImage;
    [SerializeField] private GameObject _pauseButton;

    public override void InstallBindings()
    {
        //  ScriptableObject
        Container.BindInstance(_animalSettings);
        Container.BindInstance(_playerData);
        //  ����
        Container.BindInstance(_foxPool);
        Container.BindInstance(_chickPool);
        Container.BindInstance(_explosionRedPool);
        // �������
        Container.BindInstance(_player).WithId("Player");        
        Container.BindInstance(_spawnPoints).WithId("SpawnPoints");
        // ������� UI � ������
        Container.BindInstance(_scoreManager);
        Container.BindInstance(_achievementManager);
        Container.BindInstance(_scoreSaver);
        Container.BindInstance(_counter);
        Container.BindInstance(_healthBar);        
        // ������� Player-������������
        Container.BindInterfacesAndSelfTo<PlayerHealth>().FromComponentInHierarchy().AsSingle()
            .WithArguments(_animalSettings, _healthBar, _gameOverImage, _pauseButton);
        Container.BindInterfacesAndSelfTo<PlayerMovement>().FromComponentInHierarchy().AsSingle();
        Container.BindInterfacesAndSelfTo<PlayerAudio>().FromComponentInHierarchy().AsSingle();
        // ������� SpawnManager
        Container.BindInterfacesAndSelfTo<SpawnManager>().FromComponentInHierarchy().AsSingle();        
    }
}