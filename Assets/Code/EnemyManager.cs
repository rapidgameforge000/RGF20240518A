using System.Collections.Generic;
namespace Assets.Code
{
    internal class EnemyManager
    {
        List<Enemy> _enemys = new List<Enemy>();
        internal void initialize()
        {
            for (int i = 0; i < 10; i++)
            {
                Enemy enemy = new Enemy();
                enemy.initialize();
                _enemys.Add(enemy);
            }
        }

        internal void process()
        {
            doCleanUp();
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