using System.Collections.Generic;
namespace Assets.Code
{
    internal class EnemyManager
    {
        List<Enemy> _enemys = new List<Enemy>();
        ItemManager _item_manager;
        Player _player;
        internal void initialize(ItemManager item_manager,Player player)
        {
            _item_manager = item_manager;
            _player = player;
            for (int i = 0; i < 10; i++)
            {
                Enemy enemy = new Enemy();
                enemy.initialize(_item_manager,_player);
                _enemys.Add(enemy);
            }
        }

        internal void process()
        {
            doProcess();
            doCleanUp();
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