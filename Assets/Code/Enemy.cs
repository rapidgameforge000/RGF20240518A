namespace Assets.Code
{
    internal class Enemy
    {

        const double START_HP = 5;

        ItemManager _item_manager;
        private UnityEngine.GameObject _object;
        private double _hp;
        bool _isAlive;
        int _type;

        internal void initialize(ItemManager item_manager)
        {
            _item_manager= item_manager;

            UnityEngine.GameObject prefab = UnityEngine.Resources.Load<UnityEngine.GameObject>("Enemy");
            UnityEngine.GameObject instance = UnityEngine.Object.Instantiate(prefab, SampleScene.Canvas.transform);
            _object = instance;
            float pos_x = UnityEngine.Random.Range(-960, 960);
            float pos_y = UnityEngine.Random.Range(-540, 540);
            UnityEngine.Vector2 pos= new UnityEngine.Vector2(pos_x, pos_y);
            _object.transform.localPosition = pos;
            _hp = START_HP;
            _isAlive = true;
        }
        
        internal void process()
        {

        }

        internal bool isHit(UnityEngine.Vector2 pos)
        {
            return false;
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