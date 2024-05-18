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
        const float SIZE = 40;

        ItemManager _item_manager;
        private UnityEngine.GameObject _object;
        private double _hp;
        bool _isAlive;
        TYPE _type;
        float _speed;

        internal void initialize(ItemManager item_manager)
        {
            _item_manager = item_manager;
            _type = TYPE.ADULATION;
            //_type = (TYPE)UnityEngine.Random.Range((int)TYPE.FALL, (int)TYPE.MAX);
            UnityEngine.GameObject prefab = UnityEngine.Resources.Load<UnityEngine.GameObject>("Enemy");
            UnityEngine.GameObject instance = UnityEngine.Object.Instantiate(prefab, SampleScene.Canvas.transform);
            _object = instance;
            switch (_type)
            {
                case TYPE.FALL:
                    initFallType();
                    break;
                case TYPE.ADULATION:
                    initAdulationType();
                    break;
            }
            _hp = START_HP;
            _isAlive = true;
        }

        private void initFallType()
        {
            float pos_x = UnityEngine.Random.Range(-(960 - SIZE), 960 - SIZE);
            float pos_y = 540 + SIZE;
            _speed = (float)(2 + UnityEngine.Random.Range(5, 10)) / 2;
            UnityEngine.Vector2 pos = new UnityEngine.Vector2(pos_x, pos_y);
            _object.transform.localPosition = pos;
        }

        private void initAdulationType()
        {
            int type = UnityEngine.Random.Range(0, 4);
            float pos_x = 0;
            float pos_y = 0;
            switch (type)
            {
                case 0:
                    pos_x = UnityEngine.Random.Range(-(960 + SIZE), 960 + SIZE);
                    pos_y = 540 + SIZE;
                    break;
                case 1:
                    pos_x = UnityEngine.Random.Range(-(960 + SIZE), 960 + SIZE);
                    pos_y = -(540 + SIZE);
                    break;
                case 2:
                    pos_x = 960 + SIZE;
                    pos_y = UnityEngine.Random.Range(-(540 + SIZE), 540 + SIZE);
                    break;
                case 3:
                    pos_x = -(960 + SIZE);
                    pos_y = UnityEngine.Random.Range(-(540 + SIZE), 540 + SIZE);
                    break;
            }
            UnityEngine.Vector2 pos = new UnityEngine.Vector2(pos_x, pos_y);
            _object.transform.localPosition = pos;
        }

        internal void process()
        {
            switch (_type)
            {
                case TYPE.FALL:
                    processFallType();
                    break;
                case TYPE.ADULATION:
                    break;
            }
        }

        private void processFallType()
        {
            UnityEngine.Vector2 pos = _object.transform.localPosition;
            pos += new UnityEngine.Vector2(0.0f, -_speed);
            _object.transform.localPosition = pos;
        }

        internal bool isHit(UnityEngine.Vector2 pos)
        {
            bool hit = false;
            UnityEngine.Vector2 my_pos = _object.transform.localPosition;
            UnityEngine.Vector2 distance = pos - my_pos;
            float hit_range = SIZE + 10;
            float sqr_distance = distance.sqrMagnitude;
            float sqr_hit_distance = hit_range * hit_range;
            if (sqr_distance < sqr_hit_distance)
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
                _isAlive = false;
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