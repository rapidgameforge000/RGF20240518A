namespace Assets.Code
{
    public class BulletManager
    {
        private UnityEngine.GameObject _prefab = null;
        private System.Collections.Generic.List<Bullet> _bullets = new System.Collections.Generic.List<Bullet>();
        internal void initialize()
        {
            _prefab = UnityEngine.Resources.Load<UnityEngine.GameObject>("Bullet");
        }

        internal void process()
        {
            for (int i = 0; i < _bullets.Count; i++)
            {
                _bullets[i].process();
            }
        }

        internal void createBullet(UnityEngine.Vector3 position, UnityEngine.Quaternion rotation, float speed)
        {
            _bullets.Add(new Bullet(UnityEngine.GameObject.Instantiate<UnityEngine.GameObject>(_prefab, position, rotation), speed));
        }
    }
}