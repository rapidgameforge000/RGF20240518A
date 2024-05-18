namespace Assets.Code
{
    internal class Player
    {
        UnityEngine.GameObject _object;
        private float _speed = 10;
        BulletManager _bullet_mng;

        internal void initialize(BulletManager bulletManager)
        {
            UnityEngine.GameObject prefab = UnityEngine.Resources.Load<UnityEngine.GameObject>("player");
            UnityEngine.GameObject instance = UnityEngine.Object.Instantiate(prefab);
            _object = instance;
            _bullet_mng = bulletManager;
        }

        internal void process()
        {
            if (UnityEngine.Input.GetKey(UnityEngine.KeyCode.W)) {
                _object.transform.position += new UnityEngine.Vector3(0, _speed, 0);
            }
            if (UnityEngine.Input.GetKey(UnityEngine.KeyCode.S))
            {
                _object.transform.position -= new UnityEngine.Vector3(0, _speed, 0);
            }
            if (UnityEngine.Input.GetKey(UnityEngine.KeyCode.A))
            {
                _object.transform.position -= new UnityEngine.Vector3(_speed, 0, 0);
            }
            if (UnityEngine.Input.GetKey(UnityEngine.KeyCode.D))
            {
                _object.transform.position += new UnityEngine.Vector3(_speed, 0, 0);
            }
            if (UnityEngine.Input.GetKeyDown(UnityEngine.KeyCode.Space))
            {
                _bullet_mng.createBullet(_object.transform.position);
            }
        }

        internal UnityEngine.Vector3 GetPlayerPosition()
        {
            return _object.transform.position;
        }


    }
}