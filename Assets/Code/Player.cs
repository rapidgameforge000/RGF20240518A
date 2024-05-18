namespace Assets.Code
{
    internal class Player
    {
        UnityEngine.GameObject _object;
        private float _speed = 10;

        internal void initialize()
        {
            UnityEngine.GameObject prefab = UnityEngine.Resources.Load<UnityEngine.GameObject>("player");
            UnityEngine.GameObject instance = UnityEngine.Object.Instantiate(prefab, SampleScene.Canvas.transform);
            _object = instance;
        }

        internal void process()
        {
            if (UnityEngine.Input.GetKey(UnityEngine.KeyCode.W)) {
                _object.transform.position += new UnityEngine.Vector3(0, _speed, 0);
            }
            if (UnityEngine.Input.GetKey(UnityEngine.KeyCode.S))
            {
                _object.transform.position -= new UnityEngine.Vector3(0, _speed, 0);
            }
            if (UnityEngine.Input.GetKey(UnityEngine.KeyCode.A))
            {
                _object.transform.position -= new UnityEngine.Vector3(_speed, 0, 0);
            }
            if (UnityEngine.Input.GetKey(UnityEngine.KeyCode.D))
            {
                _object.transform.position += new UnityEngine.Vector3(_speed, 0, 0);
            }
        }

        internal UnityEngine.Vector3 GetPlayerPosition()
        {
            return _object.transform.position;
        }
    }
}