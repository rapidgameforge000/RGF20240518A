using System.Drawing;

namespace Assets.Code
{
    internal class Player
    {
        const int SIZE = 80;

        UnityEngine.GameObject _object;
        BulletManager _bullet_mng;

        private float _speed = 10;
        private float _bullet_speed = 20f;
        private float _bullet_angle = 90;

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
            if (UnityEngine.Input.GetKey(UnityEngine.KeyCode.UpArrow) && _object.transform.localPosition.y < 480)
            {
                _object.transform.position += new UnityEngine.Vector3(0, _speed, 0);
            }
            if (UnityEngine.Input.GetKey(UnityEngine.KeyCode.DownArrow) && _object.transform.localPosition.y > -480)
            {
                _object.transform.position -= new UnityEngine.Vector3(0, _speed, 0);
            }
            if (UnityEngine.Input.GetKey(UnityEngine.KeyCode.LeftArrow) && _object.transform.localPosition.x > -900)
            {
                _object.transform.position -= new UnityEngine.Vector3(_speed, 0, 0);
            }
            if (UnityEngine.Input.GetKey(UnityEngine.KeyCode.RightArrow) && _object.transform.localPosition.x < 900)
            {
                _object.transform.position += new UnityEngine.Vector3(_speed, 0, 0);
            }
            if (UnityEngine.Input.GetKeyDown(UnityEngine.KeyCode.Space))
            {
                _bullet_mng.createBullet(
                    position: _object.transform.position,
                    angle: _bullet_angle,                      //’e‚Ì”­ŽËŠp“x
                    damage: 1,                      //’e‚Ìƒ_ƒ[ƒW—Ê
                    speed: _bullet_speed,                     //’e‚Ì‘¬“x
                    type: BULLET_TYPE.NORMAL,       //’e‚ÌŽí—Þ:’Êí’e or ŠgŽU’e
                    faction: BULLET_FACTION.PLAYER  //w‰c:Player or Enemy
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
            //“G‚Ì’e‚ª“–‚½‚Á‚½Û‚Ìˆ— or “G‚É“–‚½‚Á‚½Û‚Ìˆ—
            _object.SetActive(false);
        }

        internal void touchedItem(Item item)
        {
            switch(item.getType())
            {
                case Item.TYPE.POWER_UP:
                    _bullet_speed = 40f;
                    break;
                case Item.TYPE.SPEED_UP:
                    _speed += 5;
                    break;
            }
        }
    }
}