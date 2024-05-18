using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Code
{
    internal class Game
    {
        Player _player;

        internal void initialize(Player player)
        {
            _player = player;
        }

        internal void process()
        {
            if (_player.isDead())
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene("TitleScene");
            }
        }
    }
}
