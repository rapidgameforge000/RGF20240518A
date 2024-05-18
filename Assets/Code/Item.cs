namespace Assets.Code
{
    public class Item
    {
        private UnityEngine.GameObject _object;
        private const int SIZE = 50;
        public void initialize( UnityEngine.Transform transform, UnityEngine.Vector2 pos )
        {
            UnityEngine.GameObject prefab = UnityEngine.Resources.Load<UnityEngine.GameObject>( "item" );
            UnityEngine.GameObject instance = UnityEngine.GameObject.Instantiate( prefab, transform );
            _object = instance;
            _object.transform.localPosition = pos;
        }

        public int getSize()
        {
            return SIZE;
        }
    }
}
