namespace Assets.Code
{
    public class BulletManager : UnityEngine.MonoBehaviour
    {
        private UnityEngine.GameObject _prefab = null;
        private System.Collections.Generic.List<Bullet> _bullets = null;
        void Start()
        {
            _prefab = UnityEngine.Resources.Load<UnityEngine.GameObject>("Bullet");
        }

        void Update()
        {
            for (int i = 0; i < _bullets.Count; i++)
            {
                _bullets[i].Update();
            }
        }

        public void CreateBullet(UnityEngine.Vector3 position, UnityEngine.Quaternion rotation, float speed)
        {
            _bullets.Add(new Bullet(UnityEngine.GameObject.Instantiate<UnityEngine.GameObject>(_prefab, position, rotation), speed));
        }
    }
}