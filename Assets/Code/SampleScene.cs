namespace Assets.Code
{
    internal class SampleScene : UnityEngine.MonoBehaviour
    {
        EnemyManager _enemy_manager;
        private void Awake()
        {
            UnityEngine.QualitySettings.vSyncCount = 0;
            UnityEngine.Application.targetFrameRate = 30;
            _enemy_manager = new EnemyManager();
            _enemy_manager.initialize();
        }

        private void Update()
        {
            doProcess();
        }

        private void doProcess()
        {
            _enemy_manager.process();
        }
    }
}