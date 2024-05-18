using System.Collections.Generic;

namespace Assets.Code
{
    internal class ItemManager : UnityEngine.MonoBehaviour
    {
        private UnityEngine.GameObject _object;
        private Player _player;
        private List<Item> items = new List<Item>();

        internal void initialize( Player player )
        {
            UnityEngine.GameObject prefab = UnityEngine.Resources.Load<UnityEngine.GameObject>("item_manager");
            UnityEngine.GameObject instance = UnityEngine.GameObject.Instantiate(prefab);
            _object = instance;
            _player = player;
        }

        internal void process() {
            doHit();
        }

        internal void create( UnityEngine.Vector2 pos ) {
            Item item = new Item();
            item.initialize( _object.transform, pos );
            items.Add(item);
        }

        private void doHit( ) {
            for (int i = 0; i < items.Count; i++) { 
                
            }  
        }
    }
}
