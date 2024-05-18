namespace Assets.Code
{
    public class Bullet
    {
        private UnityEngine.GameObject _gobj;
        private float _speed;

        public Bullet(UnityEngine.GameObject gobj, float speed)
        {
            _gobj = gobj;
            _speed = speed;
        }


        public void Update()
        {
            _gobj.transform.position += _gobj.transform.rotation * UnityEngine.Vector3.up * _speed;
        }
    }
}