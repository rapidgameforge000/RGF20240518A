namespace Assets.Code
{
    internal class SampleScene : UnityEngine.MonoBehaviour
    {
        public static UnityEngine.GameObject Canvas { get; private set; }

        [UnityEngine.SerializeField] UnityEngine.GameObject _canvas;

        EnemyManager _enemy_manager;
        BulletManager _bullet_mgr;
        ItemManager _item_mgr;
        Player _player;
        private void Awake()
        {
            UnityEngine.QualitySettings.vSyncCount = 0;
            UnityEngine.Application.targetFrameRate = 30;
            Canvas = _canvas;
            _enemy_manager = new EnemyManager();
            _player = new Player();
            _bullet_mgr = new BulletManager();
            _item_mgr = new ItemManager();
            _player = new Player();
            _player.initialize(_bullet_mgr);
            _enemy_manager.initialize(_item_mgr, _player, _bullet_mgr);
            _bullet_mgr.initialize(_enemy_manager, _player);
            _item_mgr.initialize( _player );
            _player.initialize(_bullet_mgr);
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