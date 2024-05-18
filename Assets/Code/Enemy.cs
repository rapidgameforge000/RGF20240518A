namespace Assets.Code
{
    internal class Enemy
    {
        enum ENEMY_TYPE
        {
            FALL,
            ADULATION,
        };
        UnityEngine.GameObject _object;
        internal void initialize()
        {
            UnityEngine.GameObject prefab = UnityEngine.Resources.Load<UnityEngine.GameObject>("Enemy");
            UnityEngine.GameObject instance = UnityEngine.Object.Instantiate(prefab);
            _object = instance;
            float pos_x = UnityEngine.Random.Range(-960, 960);
            float pos_y = UnityEngine.Random.Range(-540, 540);
            UnityEngine.Vector2 pos= new UnityEngine.Vector2(pos_x, pos_y);
            _object.transform.localPosition = pos;
        }
        
        internal void process()
        {

        }
    }
}