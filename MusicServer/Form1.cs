using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;
using System.IO;

namespace MusicServer
{
    public partial class Form1 : Form
    {
        List<Tuple<string, string, Genre>> myMusicLibrary = new List<Tuple<string,string, Genre>>();
        private List<User> userBase = new List<User>();
        static public List<MusicPlayer> players;
        static string socketStatus;
        static string playlistStatus;

        private BackgroundWorker bw = new BackgroundWorker();


        public Form1()
        {
            InitializeComponent();
            loadUserBase();
            loadMusicLibrary();
            players = new List<MusicPlayer>()
            {
            {new MusicPlayer("192.168.43.225:6680/mopidy/rpc",userBase,myMusicLibrary) },
            {new MusicPlayer("192.168.0.11:6680",userBase,myMusicLibrary) }
            };

            bw.WorkerReportsProgress = true;
            bw.WorkerSupportsCancellation = true;
            bw.DoWork += new DoWorkEventHandler(bw_DoWork);
            bw.ProgressChanged += new ProgressChangedEventHandler(bw_ProgressChanged);
            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);

        }

        public void loadUserBase()
        {
            //todo: load userbase from a file, probably made by just serializing it whatever
            //also make more of it
            userBase.Add(new User("98:0D:2E:EE:97:00", new List<MusicListenedTo>()
            {
                { new MusicListenedTo(Genre.Pop,100,"One OK Rock") },
            }
            , 1));

            userBase.Add(new User("C4:3A:BE:C2:5C:50", new List<MusicListenedTo>()
            {
                {new MusicListenedTo(Genre.Rock,100,"whatever") },
            }
            , 1));

        }

        public void  loadMusicLibrary()
        {
            //probably load this from a file or some such
            myMusicLibrary = new List<Tuple<string,string, Genre>>()
           {
                {new Tuple<string,string,Genre>("Ace of Spades","Motorhead", Genre.Rock) },
                {new Tuple<string,string,Genre>("The Man Who Sold The World","Nirvana", Genre.Rock) },
                {new Tuple<string,string,Genre>("November rain","Guns n Roses", Genre.Rock) },
                {new Tuple<string,string,Genre>("At Doom's Gate (DOOM E1M1)","Daniel Tidwell", Genre.Rock) },
                {new Tuple<string,string,Genre>("Crying Lightning","Arctic Monkeys",Genre.Rock) },
                {new Tuple<string,string,Genre>("TNT","AC/DC",Genre.Rock) },
                {new Tuple<string,string,Genre>("Get Lucky","Daft Punk",Genre.Pop) },
                {new Tuple<string,string,Genre>("Kaleidoscope","Coldplay",Genre.Pop) },
                {new Tuple<string,string,Genre>("How to Fly","Sticky Fingers",Genre.Pop) },
                {new Tuple<string,string,Genre>("Smooth Criminal","Michael Jackson",Genre.Pop) },
                {new Tuple<string,string,Genre>("Thriller","Michael Jackson",Genre.Pop) }

            };
        }

        public static void loadUnloadUser(string ipAddress, string content)
        {
            //deal with the string you get
            MusicPlayer player = new MusicPlayer();
            foreach (MusicPlayer playerSearch in players)
            {
                if (playerSearch.PlayerIP.Contains(ipAddress.Remove(ipAddress.Length - 6)))
                    player = playerSearch;
            }
            string[] macs=content.Split(',');
            foreach (string mac in macs)
            {
                player.loadUnloadUser(mac);
            }

            playlistStatus = player.playMusicForCurrentUsers();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            playMusic();
        }


        private void buttonStart_Click(object sender, EventArgs e)
        {
            if (bw.IsBusy != true)
            {
                bw.RunWorkerAsync();
            }
        }

        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            string data = null;
            // Data buffer for incoming data.
            byte[] bytes = new Byte[1024];

            // Establish the local endpoint for the socket.
            // Dns.GetHostName returns the name of the 
            // host running the application.
            IPHostEntry ipHostInfo = Dns.GetHostEntry("");
            IPAddress ipAddress = ipHostInfo.AddressList[8];
            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 11000);

            Socket listener = new Socket(AddressFamily.InterNetwork,
            SocketType.Stream, ProtocolType.Tcp);

            listener.Bind(localEndPoint);
            listener.Listen(10);

            // Bind the socket to the local endpoint and 
            // listen for incoming connections.
            BackgroundWorker worker = sender as BackgroundWorker;

            while (true)
            {
                if ((worker.CancellationPending == true))
                {
                    e.Cancel = true;
                    break;
                }
                else
                {
                    try
                    {

                        // Start listening for connections.
                        while (true)
                        {
                            socketStatus = ("Waiting for a connection...");
                            // Program is suspended while waiting for an incoming connection.
                            Socket handler = listener.Accept();
                            data = null;
                            socketStatus = ("Connection estabilished...");

                            // An incoming connection needs to be processed.
                            while (true)
                            {
                                try
                                {
                                    bytes = new byte[1024];
                                    int bytesRec = handler.Receive(bytes);
                                    data += Encoding.ASCII.GetString(bytes, 0, bytesRec);
                                    if (data.IndexOf("<EOF>") > -1)
                                    {
                                        break;
                                    }
                                }
                                catch (Exception eee)
                                {
                                    Console.WriteLine(eee.ToString());
                                }

                            }



                            // Show the data on the console.
                            data = data.Remove(data.Length - 5);

                            socketStatus = ("Text received : " + data);
                            Form1.loadUnloadUser(handler.RemoteEndPoint.ToString(),data);

                            handler.Shutdown(SocketShutdown.Both);
                            handler.Close();
                        }

                    }
                    catch (Exception ee)
                    {
                        Console.WriteLine(ee.ToString());
                    }
                }
            }
        }

        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if ((e.Cancelled == true))
            {
                this.tbProgress.Text = "Canceled!";
            }

            else if (!(e.Error == null))
            {
                this.tbProgress.Text = ("Error: " + e.Error.Message);
            }

            else
            {
                this.tbProgress.Text = "Done!";
            }
        }

        private void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.tbProgress.Text = (e.ProgressPercentage.ToString() + "%");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            tbProgress.Text = socketStatus;
            playlistTextBox.Text = playlistStatus;
        }

        private void addNickelback_Click(object sender, EventArgs e)
        {
            addToPlaylist(artistBox.Text, titleBox.Text);
        }

        static public void addToPlaylist(string artist, string title)
        {

            var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://" + players[0].PlayerIP);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            string response;

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = @"{
                ""jsonrpc"": ""2.0"",
                ""id"": 1,
                ""method"": ""core.library.search"",
                ""params"": {
                    ""artist"": [
                        """ + artist + @"""
                    ],
                    ""track_name"": [
                        """ + title + @"""
                     ] }
                }";

                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();
            }
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                response = streamReader.ReadToEnd();
                if (response.Contains("spotify:track:"))
                {
                    response = response.Substring(response.IndexOf("spotify:track:"), "spotify:track:3jAoLij05OiNndX2XlSRdS".Length);
                }
                else
                {
                    MessageBox.Show("Song not found");
                    Console.WriteLine("not found");
                }
            }
            httpResponse.Dispose();

            httpWebRequest = (HttpWebRequest)WebRequest.Create("http://" + players[0].PlayerIP);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = @"{
                ""jsonrpc"": ""2.0"",
                ""id"": 1,
                ""method"": ""core.tracklist.add"",
                ""params"": {
                    ""uri"": """ + response + @"""
                    }
                }";

                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();
            }

            httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                response = streamReader.ReadToEnd();
            }

            httpResponse.Dispose();
            httpWebRequest.Abort();
        }


        private void pauseButton_Click(object sender, EventArgs e)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://" + players[0].PlayerIP);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = @"{
                ""jsonrpc"": ""2.0"",
                ""id"": 1,
                ""method"": ""core.playback.pause""
                }";

                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var response = streamReader.ReadToEnd();
            }
            httpResponse.Dispose();
            httpWebRequest.Abort();
        }

        static public void playMusic()
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://" + players[0].PlayerIP);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = @"{
                ""jsonrpc"": ""2.0"",
                ""id"": 1,
                ""method"": ""core.playback.play""
                }";

                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var response = streamReader.ReadToEnd();
            }
            httpResponse.Dispose();
            httpWebRequest.Abort();
        }

        static public void clearPlaylist()
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://" + players[0].PlayerIP);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = @"{
                ""jsonrpc"": ""2.0"",
                ""id"": 1,
                ""method"": ""core.tracklist.clear""
                }";

                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var response = streamReader.ReadToEnd();
            }
            httpResponse.Dispose();
            httpWebRequest.Abort();
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            clearPlaylist();
        }
    }
}
