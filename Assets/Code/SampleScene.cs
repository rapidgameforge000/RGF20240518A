using UnityEngine;

namespace Assets.Code
{
    internal class SampleScene : UnityEngine.MonoBehaviour
    {
        public static UnityEngine.GameObject Canvas { get; private set; }

        [UnityEngine.SerializeField] UnityEngine.GameObject _canvas;

        Game _game;
        EnemyManager _enemy_manager;
        BulletManager _bullet_mgr;
        ItemManager _item_mgr;
        Player _player;
        UI _ui;
        private void Awake()
        {
            UnityEngine.QualitySettings.vSyncCount = 0;
            UnityEngine.Application.targetFrameRate = 30;
            Canvas = _canvas;
            _game = new Game();
            _enemy_manager = new EnemyManager();
            _player = new Player();
            _bullet_mgr = new BulletManager();
            _item_mgr = new ItemManager();
            _player = new Player();
            _ui = new UI();
            _game.initialize(_player);
            _player.initialize(_bullet_mgr);
            _enemy_manager.initialize(_item_mgr, _player, _bullet_mgr);
            _bullet_mgr.initialize(_enemy_manager, _player);
            _item_mgr.initialize( _player );
            _ui.initialize(_player);
        }

        private void Update()
        {
            doProcess();
        }

        private void doProcess()
        {
            _game.process();
            _enemy_manager.process();
            _bullet_mgr.process();
            _item_mgr.process();
            _player.process();
            _ui.process();
        }
    }
}