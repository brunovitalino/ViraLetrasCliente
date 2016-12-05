using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamadaControl
{
    public class CJogar
    {
        //VARIÁVEIS

        private static readonly Random _rnd = new Random();
        

        public static Random Rnd
        {
            get { return CJogar._rnd; }
        }

        //MÉTODOS

        public String rolarDado()
        {
            return Rnd.Next(1, 6).ToString();
        }

    }
}
