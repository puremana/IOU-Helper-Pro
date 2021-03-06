﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOU_Helper
{
    class Spawn
    {
        private double _time;
        private ulong _hp;
        private ulong _xp;
        private ulong _gold;
        private uint _mobLevel;

        public Spawn(double time, ulong hp, ulong xp, ulong gold, uint mobLevel)
        {
            _time = time;
            _hp = hp;
            _xp = xp;
            _gold = gold;
            _mobLevel = mobLevel;
        }

        public double getTime()
        {
            return _time;
        }

        public ulong getHp()
        {
            return _hp;
        }

        public uint getMobLevel()
        {
            return _mobLevel;
        }
    }
}
