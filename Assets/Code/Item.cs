namespace Assets.Code
{
    internal class Item
    {
        internal enum TYPE
        {
            POWER_UP,
            SPEED_UP,
            DIFFUSION,
            MAX,
        };

        const int SPEED = 2;

        private UnityEngine.GameObject _object;
        private TYPE _type;
        bool _alive;

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

                case TYPE.DIFFUSION:
                    name = "item_diffusion";
                    _type = TYPE.DIFFUSION;
                    break;
            }

            UnityEngine.GameObject prefab = UnityEngine.Resources.Load<UnityEngine.GameObject>( name );
            UnityEngine.GameObject instance = UnityEngine.GameObject.Instantiate( prefab, SampleScene.Canvas.transform );
            _object = instance;
            

            _object.transform.localPosition = pos;
            _alive = true;
        }

        internal void process() {
            UnityEngine.Vector2 pos = _object.transform.localPosition;
            pos += new UnityEngine.Vector2(SPEED, 0);
            _object.transform.localPosition = pos;
        }

        internal TYPE getType() {
            return _type;
        }

        internal UnityEngine.Vector2 getPosition() { 
            return _object.transform.localPosition;
        }

        internal void death() {
            _alive = false;
        }

        internal void deleteObject() {
            UnityEngine.GameObject.Destroy(_object);
        }

        internal bool isAlive() {
            return _alive;
        }
    }
}
