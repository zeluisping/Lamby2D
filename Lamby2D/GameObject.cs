using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lamby2D
{
    /// <summary>
    /// Base class for all <see cref="Lamby2D.Game"/> handled objects.
    /// </summary>
    public class GameObject
    {
        /// <summary>
        /// Creates an instance of the base class for all <see cref="Lamby2D.Game handled objects."/>
        /// </summary>
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
