namespace Assets.Code
{
    public class Item
    {
        private UnityEngine.GameObject _object;
        private const int SIZE = 50;
        enum TYPE
        {
            POWER_UP,
            SPEED_UP,
            MAX,
        };
        public void initialize( UnityEngine.Transform transform, UnityEngine.Vector2 pos )
        {
            string name = "item_power_up";
            switch ((TYPE)UnityEngine.Random.Range((int)TYPE.POWER_UP, (int)TYPE.MAX)) {
                case TYPE.POWER_UP:
                    name = "item_power_up";
                    break;
                case TYPE.SPEED_UP:
                    name = "item_speed_up";
                    break;
            }
            UnityEngine.GameObject prefab = UnityEngine.Resources.Load<UnityEngine.GameObject>( name );
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
