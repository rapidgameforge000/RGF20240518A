using System.Collections.Generic;
namespace Assets.Code
{
    internal class EnemyManager
    {
        List<Enemy> _enemys = new List<Enemy>();
        ItemManager _item_manager;
        BulletManager _bullet_manager;
        Player _player;
        int _frame_count;

        internal void initialize(ItemManager item_manager,Player player,BulletManager bullet_manager)
        {
            _item_manager = item_manager;
            _player = player;
            _bullet_manager = bullet_manager;
            _frame_count = 0;
        }

        internal void process()
        {
            doCreate();
            doProcess();
            doCleanUp();
            _frame_count++;
        }

        private void doCreate()
        {
            if (_frame_count % 60 == 0)
            {
                Enemy enemy = new Enemy();
                enemy.initialize(_item_manager, _player, _bullet_manager);
                _enemys.Add(enemy);
            }
        }

        private void doProcess()
        {
            for (int i = 0; i < _enemys.Count; i++)
            {
                _enemys[i].process();
            }
        }

        private void doCleanUp()
        {
            for(int i = 0; i < _enemys.Count; i++)
            {
                if (!_enemys[i].isAlive())
                {
                    _enemys[i].deleteObject();
                    _enemys[i] = null;
                }
            }
            _enemys.RemoveAll(a => a == null);
        }

        internal bool doHit(UnityEngine.Vector2 pos, double damage)
        {
            bool hit = false; ;
            for (int i = 0; i < _enemys.Count; i++)
            {
                  if (_enemys[i].isHit(pos))
                {
                    _enemys[i].hit(damage);
                    hit = true;
                    break;
                }
            }
            return hit;
        }
    }
}