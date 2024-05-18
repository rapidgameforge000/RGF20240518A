using System.Collections.Generic;

namespace Assets.Code
{
    public class ItemManager : UnityEngine.MonoBehaviour
    {
        private UnityEngine.GameObject _object;
        List<Item> items = new List<Item>();

        public void initialize()
        {
            UnityEngine.GameObject prefab = UnityEngine.Resources.Load<UnityEngine.GameObject>("item_manager");
            UnityEngine.GameObject instance = UnityEngine.GameObject.Instantiate(prefab);
            _object = instance;
        }

        public void process() {
            doHit();
        }

        public void create( UnityEngine.Vector2 pos ) {
            Item item = new Item();
            item.initialize( _object.transform, pos );
            items.Add(item);
        }

        private void doHit( ) { 
            
        }
    }
}
