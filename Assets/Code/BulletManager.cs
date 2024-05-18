namespace Assets.Code
{
    public class BulletManager
    {
        private UnityEngine.GameObject _prefab = null;
        private System.Collections.Generic.List<Bullet> _bullets = new System.Collections.Generic.List<Bullet>();
        private EnemyManager _enemy_mgr = null;
        private Player _player = null;

        internal void initialize(EnemyManager enemy_mgr, Player player)
        {
            _enemy_mgr = enemy_mgr;
            _player = player;
            _prefab = UnityEngine.Resources.Load<UnityEngine.GameObject>("Bullet");
        }

        internal void process()
        {
            for (int i = 0; i < _bullets.Count; i++)
            {
                _bullets[i].process();
                bool isDestroy = false;
                if (_bullets[i].getFaction() == BULLET_FACTION.PLAYER)
                {
                    //エネミーに当たる
                    if (_enemy_mgr.doHit(_bullets[i].getPosition2d(), _bullets[i].getDamage()))
                    {
                        isDestroy = true;
                    }
                }
                else if (_bullets[i].getFaction() == BULLET_FACTION.ENEMY)
                {
                    //プレイヤーに当たる
                    if (_player.isHit(_bullets[i].getPosition2d(), _bullets[i].getRadius()))
                    {
                        _player.damage(_bullets[i].getDamage());
                        isDestroy = true;
                    }
                }

                if (isDestroy)
                {
                    _bullets[i].destroy();
                    _bullets.Remove(_bullets[i]);
                    i--;
                }
            }
        }

        internal void createBullet(UnityEngine.Vector3 position, float angle, int damage, float speed, BULLET_TYPE type, BULLET_FACTION faction)
        {
            switch (type)
            {
                case BULLET_TYPE.NORMAL:
                    _bullets.Add(new Bullet(UnityEngine.GameObject.Instantiate<UnityEngine.GameObject>(_prefab, position, UnityEngine.Quaternion.AngleAxis(angle, UnityEngine.Vector3.back), SampleScene.Canvas.transform), speed, damage, faction));
                    break;
                case BULLET_TYPE.DIFFUSION:
                    for (int i = 0; i < 5; i++)
                    {
                        _bullets.Add(new Bullet(UnityEngine.GameObject.Instantiate<UnityEngine.GameObject>(_prefab, position, UnityEngine.Quaternion.AngleAxis(angle - 20 + i * 10, UnityEngine.Vector3.back), SampleScene.Canvas.transform), speed, damage, faction));
                    }
                    break;
            }
        }
    }
}