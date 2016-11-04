using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOU_Helper
{
    class Spawn
    {
        private DateTime _time;
        private int _hp;
        private int _xp;
        private int _gold;

        public Spawn(DateTime time, int hp, int xp, int gold)
        {
            _time = time;
            _hp = hp;
            _xp = xp;
            _gold = gold;
        }
    }
}
