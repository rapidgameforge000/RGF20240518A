namespace Assets.Code
{
    internal class Bullet
    {
        private UnityEngine.GameObject _gobj;
        private float _speed;
        private int _damage;
        private BULLET_FACTION _faction;
        
        internal Bullet(UnityEngine.GameObject gobj, float speed, int damage, BULLET_FACTION faction)
        {
            _gobj = gobj;
            _speed = speed;
            _damage = damage;
            _faction = faction;
        }

        internal void process()
        {
            _gobj.transform.position += _gobj.transform.rotation * UnityEngine.Vector3.up * _speed;
        }

        internal void destroy()
        {
            UnityEngine.GameObject.Destroy(_gobj);
        }

        internal int getDamage()
        {
            return _damage;
        }

        internal BULLET_FACTION getFaction()
        {
            return _faction;
        }

        internal UnityEngine.Vector3 getPosition()
        {
            return _gobj.transform.position;
        }
        internal UnityEngine.Vector2 getPosition2d()
        {
            return _gobj.transform.localPosition;
        }
    }
}