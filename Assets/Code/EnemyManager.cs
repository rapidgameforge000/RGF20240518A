using System.Collections.Generic;
namespace Assets.Code
{
    internal class EnemyManager
    {
        List<Enemy> _enenmys = new List<Enemy> ();
        internal void initialize()
        {
            for (int i = 0; i < 10; i++)
            {
                Enemy enemy = new Enemy();
                enemy.initialize();
                _enenmys.Add(enemy);
            } 
        }

        internal void process()
        {

        }
    }
}