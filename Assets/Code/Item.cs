namespace Assets.Code
{
    internal class Item
    {
        internal enum TYPE
        {
            POWER_UP,
            SPEED_UP,
            MAX,
        };

        private const int SIZE = 40;

        private UnityEngine.GameObject _object;
        private TYPE _type;

        internal void initialize( UnityEngine.Transform transform, UnityEngine.Vector2 pos )
        {
            string name = "item_power_up";
            switch ((TYPE)UnityEngine.Random.Range((int)TYPE.POWER_UP, (int)TYPE.MAX)) {
                case TYPE.POWER_UP:
                    name = "item_power_up";
                    _type = TYPE.POWER_UP;
                    break;
                case TYPE.SPEED_UP:
                    name = "item_speed_up";
                    _type = TYPE.SPEED_UP;
                    break;
            }

            UnityEngine.GameObject prefab = UnityEngine.Resources.Load<UnityEngine.GameObject>( name );
            UnityEngine.GameObject instance = UnityEngine.GameObject.Instantiate( prefab, SampleScene.Canvas.transform );
            _object = instance;

            _object.transform.localPosition = pos;
        }

        internal TYPE getType() {
            return _type;
        }
    }
}
