using InterfaceServicio.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Web;

namespace InterfaceServicio.Engine
{
    public class EngineInterface : IEngineInterface
    {
        private string IpEndPoint = ConfigurationManager.AppSettings["IpEndPoint"];
        private int Port = Convert.ToInt16(ConfigurationManager.AppSettings["Port"]);

        public Guid IdentificadorReg()
        {
            Guid g = CrearGuid();
            while (g == Guid.Empty)
            {
                g = CrearGuid();
            }
            return g;
        }

        private Guid CrearGuid()
        {
            return Guid.NewGuid();
        }

        private int Ide()
        {
            Random r = new Random(DateTime.Now.Millisecond);
            return r.Next();
        }

        public TestService ConstruirTestService(string descripcion, double cantidad)
        {
            bool st = false;
            if (cantidad % 2 == 0)
                st = true;

            TestService model = new TestService()
            {
                Id = Ide(),
                Descripcion = descripcion.ToUpper(),
                Cantidad = cantidad,
                Fecha = DateTime.UtcNow,
                Identidad = IdentificadorReg(),
                Estatus = st
            };
            return model;
        }


        public bool SendInformacionSocket(string info)
        {
            bool resultado = false;
            try
            {
                Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPEndPoint IpSocket = new IPEndPoint(IPAddress.Parse(IpEndPoint), Port);
                socket.Connect(IpSocket);
                byte[] infoEnviar = Encoding.Default.GetBytes(info);
                socket.Send(infoEnviar, 0, infoEnviar.Length, 0);
                socket.Close();
                resultado = true;
            }
            catch (Exception ex)
            {
                string s = ex.ToString();
            }
            return resultado;
        }
    }
}