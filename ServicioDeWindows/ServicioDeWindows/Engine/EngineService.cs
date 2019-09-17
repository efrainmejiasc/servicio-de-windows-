using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ServicioDeWindows.Engine
{
    public class EngineService
    {
        private string directorio = ConfigurationManager.AppSettings["Directorio"];
        private string pathArchivo = ConfigurationManager.AppSettings["PathArchivo"];
        private string IpEndPoint = ConfigurationManager.AppSettings["IpEndPoint"];
        private int Port = Convert.ToInt16(ConfigurationManager.AppSettings["Port"]);
        private Socket socket;
        private IPEndPoint IpSocket;
        private Socket ear;
        private byte[] infoArray;
        private int infoLenght;
        private string info;


        public void CrearCarpetaArchivo()
        {
            if (!Directory.Exists(directorio))
                Directory.CreateDirectory(directorio);

            if (!File.Exists(pathArchivo))
                File.Create(pathArchivo);
        }

        public void EstablecerConexionSocket(string pathArchivo, bool flag)
        {
            while (flag)
            {
                info = string.Empty;
                this.socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                this.IpSocket = new IPEndPoint(IPAddress.Parse(IpEndPoint), Port);
                socket.Bind(IpSocket);
                socket.Listen(10);
                this.ear = socket.Accept();
                this.infoArray = new byte[255];
                this.infoLenght = ear.Receive(infoArray, 0, infoArray.Length, 0);
                Array.Resize(ref infoArray, infoLenght);
                this.info = Encoding.Default.GetString(infoArray);
                if (info != string.Empty)
                    GuardarValores(pathArchivo, info);

                socket.Close();
            }
        }

        public void GuardarValores(string pathArchivo, string info)
        {
            if (pathArchivo != null && pathArchivo != "")
            {
                string vIngresado = string.Empty;
                string vLinea = string.Empty;
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(pathArchivo, true))
                {
                    file.WriteLine(info);
                    info = string.Empty;
                }
            }
        }

    }
}
