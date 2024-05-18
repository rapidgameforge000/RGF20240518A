namespace Assets.Code
{
    internal class Player
    {
        UnityEngine.GameObject _object;

        internal void initialize()
        {
            UnityEngine.GameObject prefab = UnityEngine.Resources.Load<UnityEngine.GameObject>("player");
            UnityEngine.GameObject instance = UnityEngine.Object.Instantiate(prefab);
            _object = instance;
        }

        internal void process()
        {

        }
    }
}