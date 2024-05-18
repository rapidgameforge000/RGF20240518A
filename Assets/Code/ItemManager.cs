using System.Collections.Generic;

namespace Assets.Code.Item
{
    public class ItemManager : UnityEngine.MonoBehaviour
    {
        private UnityEngine.GameObject _object;
        List<Item> items = new List<Item>();

        public void initialize()
        {
            UnityEngine.GameObject prefab = UnityEngine.Resources.Load<UnityEngine.GameObject>("item");
            UnityEngine.GameObject instance = UnityEngine.GameObject.Instantiate(prefab);
            _object = instance;
        }
    }
}
