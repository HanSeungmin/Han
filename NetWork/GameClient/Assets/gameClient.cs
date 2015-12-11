using UnityEngine;
using System.Collections;

// 네트워크 소캣 네임스페이스
using System;
using System.Net;
using System.Net.Sockets;
using System.IO;


public class gameClient : MonoBehaviour {

    private TcpClient m_client = null;
    private NetworkStream m_stream = null;  
    private StreamReader m_reader = null;
    private StreamWriter m_writer = null;

	// Use this for initialization
	void Start () {
        m_client = new TcpClient("127.0.0.1", 3400);
        m_stream = m_client.GetStream();
        m_reader = new StreamReader(m_stream);
        m_writer = new StreamWriter(m_stream);
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            m_writer.WriteLine("hello"); //작성
            m_writer.Flush();  //발송
        }
	
	}

    void   OnDisable()
    {
        if (m_client != null)
        {
            m_client.Close();
        }
    }
}
