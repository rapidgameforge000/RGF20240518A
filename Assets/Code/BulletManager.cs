namespace Assets.Code
{
    public class BulletManager
    {
        private UnityEngine.GameObject _prefab = null;
        private System.Collections.Generic.List<Bullet> _bullets = new System.Collections.Generic.List<Bullet>();
        private EnemyManager _enemy_mgr = null;

        internal void initialize(EnemyManager enemy_mgr)
        {
            _enemy_mgr = enemy_mgr;
            _prefab = UnityEngine.Resources.Load<UnityEngine.GameObject>("Bullet");
        }

        internal void process()
        {
            for (int i = 0; i < _bullets.Count; i++)
            {
                _bullets[i].process();
                if (_enemy_mgr.doHit(_bullets[i].getPosition2d(), _bullets[i].getDamage()))
                {
                    _bullets[i].destroy();
                    _bullets.Remove(_bullets[i]);
                    i--;
                }
            }
        }

        internal void createBullet(UnityEngine.Vector3 position)
        {
            float speed = 10;
            int damage = 1;
            _bullets.Add(new Bullet(UnityEngine.GameObject.Instantiate<UnityEngine.GameObject>(_prefab, position, UnityEngine.Quaternion.AngleAxis(-90, UnityEngine.Vector3.forward), SampleScene.Canvas.transform), speed, damage));
        }
    }
}