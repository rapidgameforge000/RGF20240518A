namespace Assets.Code
{
    internal class Bullet
    {
        const int SIZE = 20;

        private UnityEngine.GameObject _gobj;
        private float _speed;
        private int _damage;
        private BULLET_FACTION _faction;
        private bool _dead;
        private EnemyManager _enemy_mgr;
        private Player _player;
        
        internal Bullet(UnityEngine.GameObject gobj, float speed, int damage, BULLET_FACTION faction, EnemyManager enemy_mgr, Player player)
        {
            _gobj = gobj;
            _speed = speed;
            _damage = damage;
            _faction = faction;
            _enemy_mgr = enemy_mgr;
            _player = player;
            _dead = false;
            gobj.GetComponent<UnityEngine.UI.Image>().color = faction == BULLET_FACTION.PLAYER ? UnityEngine.Color.white : UnityEngine.Color.blue;
        }

        internal void process()
        {
            if (_dead) return;
            _gobj.transform.position += _gobj.transform.rotation * UnityEngine.Vector3.up * _speed;
            if (_faction == BULLET_FACTION.PLAYER)
            {
                //エネミーに当たる
                if (_enemy_mgr.doHit(getPosition(), _damage))
                {
                    _dead = true;
                }
            }
            else if (_faction == BULLET_FACTION.ENEMY)
            {
                //プレイヤーに当たる
                if (_player.isHit(getPosition(), SIZE))
                {
                    _player.damage(_damage);
                    _dead = true;
                }
            }
            if (_dead)
            {
                UnityEngine.GameObject.Destroy(_gobj);
            }
        }

        internal bool isDead()
        {
            return _dead;
        }
        internal UnityEngine.Vector2 getPosition()
        {
            return _gobj.transform.localPosition;
        }
    }
}