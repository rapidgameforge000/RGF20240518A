namespace Assets.Code
{
    public class Item : UnityEngine.MonoBehaviour
    {
        private UnityEngine.GameObject _object;
        private const int SIZE = 50;
        public void initialize()
        {
            UnityEngine.GameObject prefab = UnityEngine.Resources.Load<UnityEngine.GameObject>( "item" );
            UnityEngine.GameObject instance = UnityEngine.GameObject.Instantiate(prefab);
            _object = instance;
        }

        public int getSize()
        {
            return SIZE;
        }
    }
}
