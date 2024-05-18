using System.Drawing;

namespace Assets.Code
{
    internal class Player
    {
        const int SIZE = 60;

        UnityEngine.GameObject _object;
        BulletManager _bullet_mng;

        private int _hp = 10;
        private float _speed = 10;
        private float _bullet_speed = 20f;
        private float _bullet_angle = 90;
        private int _bullet_damage = 1;
        private BULLET_TYPE _bullet_type = BULLET_TYPE.NORMAL;
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
                    angle: _bullet_angle,                      //íeÇÃî≠éÀäpìx
                    damage: _bullet_damage,                      //íeÇÃÉ_ÉÅÅ[ÉWó 
                    speed: _bullet_speed,                     //íeÇÃë¨ìx
                    type: _bullet_type,       //íeÇÃéÌóﬁ:í èÌíe or ägéUíe
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
            _hp -= damage;
            if (_hp > 0)
            {
                return;
            }
            //ìGÇÃíeÇ™ìñÇΩÇ¡ÇΩç€ÇÃèàóù or ìGÇ…ìñÇΩÇ¡ÇΩç€ÇÃèàóù
            _object.SetActive(false);
        }

        internal bool isDead()
        {
            return _hp <= 0;
        }

        internal void touchedItem(Item item)
        {
            switch(item.getType())
            {
                case Item.TYPE.BULLET_SPEED_UP:
                    _bullet_speed += 20f;
                    break;
                case Item.TYPE.PLAYER_SPEED_UP:
                    _speed += 20;
                    break;
                case Item.TYPE.DIFFUSION:
                    _bullet_type = BULLET_TYPE.DIFFUSION;
                    break;
                case Item.TYPE.POWER_UP:
                    _bullet_damage += 3;
                    break;
            }
            if (_bullet_speed > 40)
            {
                _bullet_speed = 40;
            }
            if (_speed > 40)
            {
                _bullet_speed = 40;
            }
        }
    }
}