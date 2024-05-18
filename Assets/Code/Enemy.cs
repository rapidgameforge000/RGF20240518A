namespace Assets.Code
{
    internal class Enemy
    {
        enum TYPE
        {
            FALL,
            ADULATION,
            MAX,
        };
        const double START_HP = 5;

        ItemManager _item_manager;
        private UnityEngine.GameObject _object;
        private double _hp;
        bool _isAlive;
        TYPE _type;

        internal void initialize(ItemManager item_manager)
        {
            _item_manager= item_manager;
            _type = (TYPE)UnityEngine.Random.Range((int)TYPE.FALL, (int)TYPE.MAX);
            UnityEngine.GameObject prefab = UnityEngine.Resources.Load<UnityEngine.GameObject>("Enemy");
            UnityEngine.GameObject instance = UnityEngine.Object.Instantiate(prefab, SampleScene.Canvas.transform);
            _object = instance;
            switch (_type) {
                case TYPE.FALL:
                    initFallType();
                    break;
                case TYPE.ADULATION:
                    break;
            }
            _hp = START_HP;
            _isAlive = true;
        }

        private void initFallType()
        {
            float pos_x = UnityEngine.Random.Range(-960, 960);
            float pos_y = UnityEngine.Random.Range(-540, 540);
            UnityEngine.Vector2 pos = new UnityEngine.Vector2(pos_x, pos_y);
            _object.transform.localPosition = pos;
        }

        internal void process()
        {

        }

        internal bool isHit(UnityEngine.Vector2 pos)
        {
            bool hit = false;
            UnityEngine.Vector2 my_pos = _object.transform.localPosition;
            UnityEngine.Vector2 distance = pos - my_pos;
            int hit_range = 40 + 10;
            float sqr_distance = distance.sqrMagnitude;
            float sqr_hit_distance = hit_range * hit_range;
            if(sqr_distance< sqr_hit_distance)
            {
                hit = true;
            }
            return hit;
        }
        
        internal void hit(double damage)
        {
            _hp -= damage;
            if (_hp < 0)
            {
                _isAlive= false;
                _item_manager.create(_object.transform.localPosition);
            }
        }

        internal bool isAlive()
        {
            return _isAlive;
        }

        internal void deleteObject()
        {
            UnityEngine.Object.Destroy(_object);
        }

    }
}