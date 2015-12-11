using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// network namespace
using System.IO;
using System.Net;
using System.Net.Sockets;

    class Program
    {
        private static Socket s_Server; // 서버용 소켓

        private static List<Socket> listClients = new List<Socket>(); 
        // 클라이언트 소캣은 서버 소캣과 별개로. 클라이언트가 서버와 커뮤니케이션하기 위해 존재한 소캣이다.
        // 그러한 까닭에 클라이언트 소캣은 클라이언트의 갯수만큼 생성되게 된다.

        static void Main(string[] args)
        {
            s_Server = new Socket(
                AddressFamily.InterNetwork,
                SocketType.Stream,
                ProtocolType.Tcp
                );
            IPEndPoint ipep = new IPEndPoint(IPAddress.Any, 3400);
            // IPEndPoint는 스스로의 주소(서버의 주소, 즉 IPAddress)를 지정하는 클래스이며, 
            // IPAddress.Any는 서버자체에 존재하는 IP를 사용하겠다는 것.
            // 3400은 포트.
            // new IPEndPoint(IPAddress, Port)
            // 포트가 중복될 일이 없는 이유가. 서버 개발자가 어차피 어떤 포트가 사용되는지 알기 때문에
            // 아직 사용하지 않는 포트를 입력하게 된다.
            // ipep는 단순 객체일 뿐이다. 아직 실제 포트가 생성된건 아니다.

            s_Server.Bind(ipep);
            // 위에서 생성한 IP와 Port를 소켓에 연결해준다.

            s_Server.Listen(200);
            // Listen(접속 허용 접속자수);

            // 여기까지가 서버 소캣의 조건을 완료하는 것임.


            while(true)
            {
                Socket socket = s_Server.Accept();  // 접속을 기다리는 함수임.(Blocking함수)
                // 서버의 소캣인 s_Server는 접속을 기다리게 되며, 누군가 접속시 그 결과를 socket이라는 소캣에 넘겨 준다.
                listClients.Add(socket);
                // 클라이언트가 접속하면 위에서 생성한 socket을 리스트에 추가해 하나의 리스트로 관리 할 수 있도록 한다.
                // 클라이언트는 앞으로의 작업은 리스트에 들어이 있는 소캣으로 관리한다.
                // 클라이언트 소캣은 접속자 만큼 생성되어야 한다.(기초단계에서는...)
                // 클라이언트 소캣은 C#일 경우 List로, C++일 경우 Vector로 관리한다.
                
                Console.WriteLine("Accpeted {0}", listClients.Count);
                // 현재 생성된 리스트를 카운트하여, 접속한 인원을 알 수 있다.
                // 당연히 접속이 종료되면 리스트를 삭제해야 하지만.. 현재는 삭제되는 부분은 제외한다.

                NetworkStream networkStream = new NetworkStream(socket);
                // 네트워크 액세스를 위한 내부 데이터 스트림을 제공합니다. 자료출처 : MSDN(https://msdn.microsoft.com/ko-KR/library/windows/apps/system.net.sockets.networkstream(v=vs.80).aspx)
                // 뭔소린지는 모르겠지만 스트림이란 흐름을 이야기 한다는 것을 생각할때, 네트워크 데이터 흐름을 말하는 것 같다.
                // new NetworkStream(소캣) 생성자로 소캣을 인자로 넣는 이유는, 당연히 해당 네트워크 이용자와 데이터를 주고 받기 위함이 아닐까 싶다.
                // 근데 여기서 잠깐.. 우리는 socket변수를 사실 리스트에 넣었다는 것을 잊지 말자.. 예제인 까닭에 이렇게 설명한 것 같다.
                // 그렇다면 네트워크 스트림역시 소캣 리스트의 갯수만큼 생성해야 한다는 말이다.
                
                StreamReader reader = new StreamReader(networkStream);
                // 특정 인코딩의 바이트 스트림에서 문자를 읽는 TextReader를 구현합니다. 자료출처 : MSDN(https://msdn.microsoft.com/ko-kr/library/system.io.streamreader(v=vs.110).aspx#)
                // 데이터를 문자열로 받아들임.
                // 사용자 소캣인 socket의 데이터를 networkStream에 연결하였고, 해당 내용을 StreamReader인 reader로 전달하였다.

                string message = reader.ReadLine(); // (Blocking 함수)
                // StreamReader의 블러킹 함수인 ReadLine() 을 사용하여, reader이 메시지를 기다리도록 하였으며, 메시지가 들어올 경우 문자열 message에다 전달하도록 한다.
                
                Console.WriteLine("recved msg : " + message);
                // 그리고 읽어온 메시지를 출력하여 확인한다.

                // 이때 코드의 흐름을 잘 보면, socket에서 누군가의 접속을 기다린다. 그러다 한명이 접속할 경우 다음 코드로 이동하게 된다.
                // 블러킹 함수란 그런것이다. 접속이 되지 않으면, 다음 함수로 이동하지 않는다.
                // 그리고 접속한 사람이 어떠한 메시지를 보낼 때 까지 또 기다린다.
                // 결국 접속한 사람이 어떠한 메시지를 보내지 않는다면, 다음 접속을 기다릴 수 없게 된다.
                // 그래서 접속한 사람에 대한 메시지를 주고 받을 수 있도록 별도의 스레드를 만들어주어야 한다.
                // 결국 접속관리하는 지금의 스레드에서는 접속을 관리하는 스레드이며, 소통하는 스레드는 별도로 만들어주어야 한다.
            }
        }
    }
}
