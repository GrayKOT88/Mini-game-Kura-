using TMPro;
using UnityEngine;
using Zenject;

public class MenuInstaller : MonoInstaller
{
    [Header("���������")]
    [SerializeField] private AnimalSettings _animalSettings;
    [SerializeField] private PlayerDataSO _playerData;
    [Header("UI")]
    [SerializeField] private TextMeshProUGUI _chickCountText;
    [SerializeField] private TextMeshProUGUI _foxCountText;
    [SerializeField] private TextMeshProUGUI _recordCountText;
    [SerializeField] private GameObject _goldMedal;
    [SerializeField] private GameObject _silverMedal;
    [SerializeField] private GameObject _bronzeMedal;

    public override void InstallBindings()
    {
        // ����������� ScriptableObject
        Container.BindInstance(_animalSettings);
        Container.BindInstance(_playerData);

        // ����������� UI-���������
        Container.BindInstance(_chickCountText).WithId("ChickCountText");
        Container.BindInstance(_foxCountText).WithId("FoxCountText");
        Container.BindInstance(_recordCountText).WithId("RecordCountText");
        Container.BindInstance(_goldMedal).WithId("GoldMedal");
        Container.BindInstance(_silverMedal).WithId("SilverMedal");
        Container.BindInstance(_bronzeMedal).WithId("BronzeMedal");

        // ����������� ������� ����
        Container.BindInterfacesAndSelfTo<UIMenu>().FromComponentInHierarchy().AsSingle();
        Container.BindInterfacesAndSelfTo<DataInitializer>().FromComponentInHierarchy().AsSingle();
    }
}