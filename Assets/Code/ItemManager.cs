using System.Collections.Generic;

namespace Assets.Code
{
    internal class ItemManager
    {
        private UnityEngine.GameObject _object;
        private Player _player;
        private List<Item> _items = new List<Item>();

        private const int ITEM_RADIUS = 40;
        private const int PROBABILITY = 2;

        internal void initialize( Player player )
        {
            UnityEngine.GameObject prefab = UnityEngine.Resources.Load<UnityEngine.GameObject>("item_manager");
            UnityEngine.GameObject instance = UnityEngine.GameObject.Instantiate(prefab, SampleScene.Canvas.transform);
            _object = instance;
            _player = player;

            //for (int i = 0; i < 10; i++)
            //{
            //    doCreate(new UnityEngine.Vector2(UnityEngine.Random.Range(-300, 300), UnityEngine.Random.Range(-300, 300)));
            //}
        }

        internal void process() {
            for (int i = 0; i < _items.Count; i++)
            {
                _items[i].process();
            }
            doHit();
            doCleanUp();
        }

        internal void doCreate(UnityEngine.Vector2 pos)
        {
            if (UnityEngine.Random.Range(0, PROBABILITY) != 0) {
                return;
            }
            Item item = new Item();
            item.initialize(_object.transform, pos);
            _items.Add(item);
        }

        void doMove() {
            for (int i = 0; i < _items.Count; i++)
            {
                if (!_items[i].isAlive())
                {
                    _items[i].deleteObject();
                    _items[i] = null;
                }
            }
        }
        private void doCleanUp()
        {
            for (int i = 0; i < _items.Count; i++)
            {
                if (!_items[i].isAlive())
                {
                    _items[i].deleteObject();
                    _items[i] = null;
                }
            }

            _items.RemoveAll(a => a == null);
        }

        private void doHit()
        {
            for (int i = 0; i < _items.Count; i++)
            {
                if (_player.isHit(_items[i].getPosition(), ITEM_RADIUS)) {
                    _player.touchedItem(_items[ i ] );
                    _items[i].death();
                }
            }
        }
    }
}
