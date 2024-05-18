using System.Drawing;

namespace Assets.Code
{
    internal class Player
    {
        const int SIZE = 80;

        UnityEngine.GameObject _object;
        private float _speed = 10;
        BulletManager _bullet_mng;

        internal void initialize(BulletManager bulletManager)
        {
            UnityEngine.GameObject prefab = UnityEngine.Resources.Load<UnityEngine.GameObject>("player");
            UnityEngine.GameObject instance = UnityEngine.Object.Instantiate(prefab, UnityEngine.Vector3.zero, UnityEngine.Quaternion.AngleAxis(90, UnityEngine.Vector3.back), SampleScene.Canvas.transform);
            _object = instance;
            _bullet_mng = bulletManager;
        }

        internal void process()
        {
            playerMove();
        }

        private void playerMove()
        {
            if (UnityEngine.Input.GetKey(UnityEngine.KeyCode.UpArrow))
            {
                _object.transform.position += new UnityEngine.Vector3(0, _speed, 0);
            }
            if (UnityEngine.Input.GetKey(UnityEngine.KeyCode.DownArrow))
            {
                _object.transform.position -= new UnityEngine.Vector3(0, _speed, 0);
            }
            if (UnityEngine.Input.GetKey(UnityEngine.KeyCode.LeftArrow))
            {
                _object.transform.position -= new UnityEngine.Vector3(_speed, 0, 0);
            }
            if (UnityEngine.Input.GetKey(UnityEngine.KeyCode.RightArrow))
            {
                _object.transform.position += new UnityEngine.Vector3(_speed, 0, 0);
            }
            if (UnityEngine.Input.GetKeyDown(UnityEngine.KeyCode.Space))
            {
                _bullet_mng.createBullet(
                    position: _object.transform.position,
                    angle: 90,                      //íeÇÃî≠éÀäpìx
                    damage: 1,                      //íeÇÃÉ_ÉÅÅ[ÉWó 
                    speed: 20f,                     //íeÇÃë¨ìx
                    type: BULLET_TYPE.NORMAL,       //íeÇÃéÌóﬁ:í èÌíe or ägéUíe
                    faction: BULLET_FACTION.PLAYER  //êwâc:Player or Enemy
                    );
            }
        }

        internal UnityEngine.Vector2 GetPlayerPosition()
        {
            return _object.transform.localPosition;
        }

        internal bool isHit(UnityEngine.Vector2 pos, float radius)
        {
            bool hit = false;
            UnityEngine.Vector2 my_pos = _object.transform.localPosition;
            UnityEngine.Vector2 distance = pos - my_pos;
            float hit_range = SIZE + radius;
            float sqr_distance = distance.sqrMagnitude;
            float sqr_hit_distance = hit_range * hit_range;
            if (sqr_distance < sqr_hit_distance)
            {
                hit = true;
            }
            return hit;
        }

        internal void damage(int damage)
        {
            //ìGÇÃíeÇ™ìñÇΩÇ¡ÇΩç€ÇÃèàóù
        }
    }
}