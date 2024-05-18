namespace Assets.Code
{
    internal class SampleScene : UnityEngine.MonoBehaviour
    {
        EnemyManager _enemy_manager;
        BulletManager _bullet_mgr;
        ItemManager _item_mgr;
        Player _player;
        private void Awake()
        {
            UnityEngine.QualitySettings.vSyncCount = 0;
            UnityEngine.Application.targetFrameRate = 30;
            _enemy_manager = new EnemyManager();
            _enemy_manager.initialize();
            _player = new Player();
            _player.initialize();
            _bullet_mgr = new BulletManager();
            _bullet_mgr.initialize(_enemy_manager);
            _item_mgr = new ItemManager();
            _item_mgr.initialize( _player );
        }

        private void Update()
        {
            doProcess();
        }

        private void doProcess()
        {
            _enemy_manager.process();
            _bullet_mgr.process();
            _item_mgr.process();
            _player.process();
        }
    }
}