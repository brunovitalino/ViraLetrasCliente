using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace CamadaControl
{
    public class CChat
    {
        //VARIÁVEIS
        private string _usuario, _ipServidor;
        private TcpClient _tcpServidor;
        private StreamWriter _escritor;
        private StreamReader _leitor;
        private bool _conectado = false;

        public string Usuario
        {
            get { return _usuario; }
            set { _usuario = value; }
        }

        public string IpServidor
        {
            get { return _ipServidor; }
            set { _ipServidor = value; }
        }

        public TcpClient TcpServidor
        {
            get { return _tcpServidor; }
            set { _tcpServidor = value; }
        }

        public StreamWriter Escritor
        {
            get { return _escritor; }
            set { _escritor = value; }
        }

        public StreamReader Leitor
        {
            get { return _leitor; }
            set { _leitor = value; }
        }

        public bool Conectado
        {
            get { return _conectado; }
            set { _conectado = value; }
        }


        //MÉTODOS
        public Exception iniciarConexao(string usuario, string ipServidor)
        {
            try
            {
                if (usuario.Trim().Equals(""))
                {
                    Usuario = "Anonymous";
                }
                else
                {
                    Usuario = usuario;
                }
                IpServidor = ipServidor;
                TcpServidor = new TcpClient();

                TcpServidor.Connect(IPAddress.Parse(IpServidor), 2502); //Socket de conexão ao servidor
                Conectado = true;
                Escritor = new StreamWriter(TcpServidor.GetStream());

                Escritor.WriteLine(Usuario);
                Escritor.Flush();
                return null;
            }
            catch (Exception ex)
            {
                return ex;
            }
        }

        public void EnviarMensagem(string mensagem)
        {
            Escritor.WriteLine(mensagem);
            Escritor.Flush();
        }

        /*public string LerResposta()
        {
            Leitor = new StreamReader(TcpServidor.GetStream());
            return Leitor.ReadLine();
        }*/

        public void FecharConexao()
        {
            Conectado = false;
            Escritor.Close();
            //Leitor.Close();
            TcpServidor.Close();
        }
    }
}
