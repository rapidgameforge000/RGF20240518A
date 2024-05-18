using System.Collections.Generic;

namespace Assets.Code
{
    internal class ItemManager
    {
        private UnityEngine.GameObject _object;
        private Player _player;
        private List<Item> _items = new List<Item>();

        private int PLAYER_RADIUS = 40;
        private int ITEM_RADIUS = 20;

        internal void initialize( Player player )
        {
            UnityEngine.GameObject prefab = UnityEngine.Resources.Load<UnityEngine.GameObject>("item_manager");
            UnityEngine.GameObject instance = UnityEngine.GameObject.Instantiate(prefab, SampleScene.Canvas.transform);
            _object = instance;
            _player = player;

            for (int i = 0; i < 10; i++)
            {
                create(new UnityEngine.Vector2(UnityEngine.Random.Range(-300, 300), UnityEngine.Random.Range(-300, 300)));
            }
        }

        internal void process() {
            //doHit();
            doCleanUp();
        }

        internal void create( UnityEngine.Vector2 pos ) {
            Item item = new Item();
            item.initialize( _object.transform, pos );
            _items.Add(item);
        }

        //private void doHit( ) {
        //    for (int i = 0; i < _items.Count; i++) {
        //        UnityEngine.Vector2 distance = _items[i].getPosition() - _player.GetPlayerPosition();
        //        int hit_distance = PLAYER_RADIUS + ITEM_RADIUS;
        //        int sqr_distance = ( int )distance.sqrMagnitude;
        //        int sqr_hit_distance = hit_distance * hit_distance;
        //        if (sqr_distance < sqr_hit_distance)
        //        {
        //            _items[i].death();
        //        }
        //    }       
        //}

        private void doCleanUp() {
            for (int i = 0; i < _items.Count; i++) {
                if (!_items[i].isAlive())
                {
                    _items[i].deleteObject();
                    _items[i] = null;
                } 
            }

            _items.RemoveAll(a => a == null); 
        }
    }
}
