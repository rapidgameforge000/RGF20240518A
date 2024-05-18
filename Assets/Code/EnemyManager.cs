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

        }

        internal bool doHit(UnityEngine.Vector2 pos, int damage)
        {
            bool hit = false; ;
            for (int i = 0; i < _enemys.Count; i++)
            {
            }
            return hit;
        }
    }
}