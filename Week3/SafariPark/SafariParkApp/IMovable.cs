using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafariParkApp
{
    public interface IMovable : ISingleMovable, IMultiMovable
    {
        
        
    }

    public interface IMultiMovable
    {
        string Move(int times);
    }

    public interface ISingleMovable
    {
        string Move();
    }
}
