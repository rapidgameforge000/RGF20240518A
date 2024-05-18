using System.Numerics;

namespace Assets.Code
{
    internal class Enemy
    {
        enum TYPE
        {
            FALL,
            UP,
            ADULATION,
            MAX,
        };
        const float ADD_X_VEL = 0.2f;
        const double START_HP = 5;
        const float SIZE = 40;
        const int CREATE_BULLET_TIME = 45;

        ItemManager _item_manager;
        Player _player;
        BulletManager _bullet_manager;
        private UnityEngine.GameObject _object;
        private double _hp;
        bool _isAlive;
        int _frame_cont;
        TYPE _type;
        float _speed;
        UnityEngine.Vector2 _vel;

        internal void initialize(ItemManager item_manager,Player player,BulletManager bullet_manager)
        {
            _item_manager = item_manager;
            _player = player;
            _bullet_manager = bullet_manager;
            //_type = TYPE.ADULATION;
            _type = (TYPE)UnityEngine.Random.Range((int)TYPE.FALL, (int)TYPE.MAX);
            UnityEngine.GameObject prefab = UnityEngine.Resources.Load<UnityEngine.GameObject>("Enemy");
            UnityEngine.GameObject instance = UnityEngine.Object.Instantiate(prefab, SampleScene.Canvas.transform);
            _object = instance;
            switch (_type)
            {
                case TYPE.FALL:
                    initFallType();
                    break;
                case TYPE.UP:
                    initUpType();
                    break;
                case TYPE.ADULATION:
                    initAdulationType();
                    break;
            }
            _hp = START_HP;
            _isAlive = true;
            _frame_cont =0;
        }

        private void initFallType()
        {
            UnityEngine.Vector2 player_pos = _player.GetPlayerPosition();
            float min_x = player_pos.x;
            float max_x = 960 - SIZE;
            float pos_x = UnityEngine.Random.Range(min_x,max_x) ;
            float pos_y = 540 + SIZE;
            UnityEngine.Vector2 pos = new UnityEngine.Vector2(pos_x, pos_y);
            _speed = (float)(2 + UnityEngine.Random.Range(5, 10));
            _object.transform.localPosition = pos;
        }

        private void initUpType()
        {
            UnityEngine.Vector2 player_pos = _player.GetPlayerPosition();
            float min_x = player_pos.x;
            float max_x = 960 - SIZE;
            float pos_x = UnityEngine.Random.Range(min_x, max_x);
            float pos_y = -(540 + SIZE);
            _speed = (float)(2 + UnityEngine.Random.Range(5, 10));
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
            _speed = (float)(5 + UnityEngine.Random.Range(5, 10)) / 3;
            _object.transform.localPosition = pos;
        }

        internal void process()
        {
            if (isCreateBullet()){
                createBullet();
            }
            switch (_type)
            {
                case TYPE.FALL:
                    processFallType();
                    break;
                case TYPE.UP:
                    processUpType();
                    break;
                case TYPE.ADULATION:
                    processAdulationType();
                    break;
            }
            _frame_cont++;
        }

        private void processFallType()
        {
            UnityEngine.Vector2 pos = _object.transform.localPosition;
            _vel.x += -ADD_X_VEL;
            _vel.y = -_speed;
            pos += _vel;
            _object.transform.localPosition = pos;
            if (_object.transform.localPosition.x <= -(960 + SIZE))
            {
                _isAlive = false;
            }
        }

        private void processUpType()
        {
            UnityEngine.Vector2 pos = _object.transform.localPosition;
            _vel.x += -ADD_X_VEL;
            _vel.y = _speed;
            pos += _vel;
            _object.transform.localPosition = pos;
            if (_object.transform.localPosition.x <= -(960 + SIZE))
            {
                _isAlive = false;
            }
        }

        private void processAdulationType()
        {
            UnityEngine.Vector2 player_pos = _player.GetPlayerPosition();
            UnityEngine.Vector2 pos = _object.transform.localPosition;
            UnityEngine.Vector2 vec = (player_pos - pos).normalized;
            _vel = new UnityEngine.Vector2(vec.x * _speed, vec.y * _speed);
            pos += _vel;
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
                _item_manager.doCreate(_object.transform.localPosition);
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

        private bool isCreateBullet()
        {
            bool create = false;
            if (_frame_cont % CREATE_BULLET_TIME == 0)
            {
                create = true;
            }
            return create;
        }

        private void createBullet()
        {
            UnityEngine.Vector2 player_pos = _player.GetPlayerPosition();
            UnityEngine.Vector2 pos = _object.transform.localPosition;
            UnityEngine.Vector2 vec = (player_pos - pos).normalized; // ベクトルを角度に変換します
            float angle = UnityEngine.Mathf.Atan2(vec.x, vec.y) * UnityEngine.Mathf.Rad2Deg;
            _bullet_manager.createBullet(_object.transform.position , angle, 1, 4, BULLET_TYPE.NORMAL, BULLET_FACTION.ENEMY);
        }
    }
}