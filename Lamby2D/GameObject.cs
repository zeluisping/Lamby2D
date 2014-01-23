using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lamby2D
{
    public class GameObject
    {
        // Constructors
        public GameObject()
        {
            Game.Current.RegisterGameObject(this);
        }
        ~GameObject()
        {
            Game.Current.UnRegisterGameObject(this);
        }
    }
}
