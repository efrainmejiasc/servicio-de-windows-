using InterfaceServicio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceServicio.Engine
{
    public interface IEngineInterface
    {
        Guid IdentificadorReg();
        bool SendInformacionSocket(string info);
        TestService ConstruirTestService(string descripcion, double cantidad);
    }
}
