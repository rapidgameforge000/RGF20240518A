namespace Assets.Code
{
    internal class SampleScene : UnityEngine.MonoBehaviour
    {
        Enemy _enemy;
        BulletManager _bullet_mgr;
        private void Awake()
        {
            UnityEngine.QualitySettings.vSyncCount = 0;
            UnityEngine.Application.targetFrameRate = 30;
            _enemy= new Enemy();
            _enemy.initialize();
            _bullet_mgr = new BulletManager();
            _bullet_mgr.initialize();
        }

        private void Update()
        {
            doProcess();
        }

        private void doProcess()
        {
            _enemy.process();
            _bullet_mgr.process();
        }
    }
}