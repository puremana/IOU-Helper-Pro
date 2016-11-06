using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOU_Helper
{
    class Spawn
    {
        private double _time;
        private uint _hp;
        private ulong _xp;
        private ulong _gold;

        public Spawn(double time, uint hp, ulong xp, ulong gold)
        {
            _time = time;
            _hp = hp;
            _xp = xp;
            _gold = gold;
        }

        public double getTime()
        {
            return _time;
        }

        public uint getHp()
        {
            return _hp;
        }
    }
}
