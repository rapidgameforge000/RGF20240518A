namespace Assets.Code
{
    internal class SampleScene : UnityEngine.MonoBehaviour
    {
        Enemy _enemy;
        private void Awake()
        {
            UnityEngine.QualitySettings.vSyncCount = 0;
            UnityEngine.Application.targetFrameRate = 30;
            _enemy= new Enemy();
            _enemy.initialize();
        }

        private void Update()
        {
            doProcess();
        }

        private void doProcess()
        {
            _enemy.process();
        }
    }
}