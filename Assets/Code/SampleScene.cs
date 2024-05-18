namespace Assets.Code
{
    internal class SampleScene : UnityEngine.MonoBehaviour
    {
        Enemy _enemy;
        Player _player;
        private void Awake()
        {
            UnityEngine.QualitySettings.vSyncCount = 0;
            UnityEngine.Application.targetFrameRate = 30;
            _enemy= new Enemy();
            _enemy.initialize();
            _player = new Player();
            _player.initialize();
        }

        private void Update()
        {
            doProcess();
        }

        private void doProcess()
        {
            _enemy.process();
            _player.process();
        }
    }
}