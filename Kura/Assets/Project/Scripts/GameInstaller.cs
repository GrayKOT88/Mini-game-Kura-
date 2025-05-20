using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    // Настройки
    [SerializeField] private AnimalSettings _animalSettings;
    [SerializeField] private PlayerDataSO _playerData;
    // Пулы
    [SerializeField] private FoxPool _foxPool;
    [SerializeField] private ChickPool _chickPool;
    [SerializeField] private ExplosionRedPool _explosionRedPool;
    // Объекты
    [SerializeField] private Transform _player;
    [SerializeField] private List<Transform> _spawnPoints;
    // UI и системы
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
        //  пулы
        Container.BindInstance(_foxPool);
        Container.BindInstance(_chickPool);
        Container.BindInstance(_explosionRedPool);
        // Объекты
        Container.BindInstance(_player).WithId("Player");        
        Container.BindInstance(_spawnPoints).WithId("SpawnPoints");
        // Биндинг UI и систем
        Container.BindInstance(_scoreManager);
        Container.BindInstance(_achievementManager);
        Container.BindInstance(_scoreSaver);
        Container.BindInstance(_counter);
        Container.BindInstance(_healthBar);        
        // Биндинг Player-зависимостей
        Container.BindInterfacesAndSelfTo<PlayerHealth>().FromComponentInHierarchy().AsSingle()
            .WithArguments(_animalSettings, _healthBar, _gameOverImage, _pauseButton);
        Container.BindInterfacesAndSelfTo<PlayerMovement>().FromComponentInHierarchy().AsSingle();
        Container.BindInterfacesAndSelfTo<PlayerAudio>().FromComponentInHierarchy().AsSingle();
        // Биндинг SpawnManager
        Container.BindInterfacesAndSelfTo<SpawnManager>().FromComponentInHierarchy().AsSingle();        
    }
}