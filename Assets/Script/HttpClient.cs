﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

#if WSA || UNITY_EDITOR || UNITY_WSA

#else
public class HttpClient
{
    private HttpWebRequest request;
    private Dictionary<string, string> header;

    public HttpClient()
    {
        header = new Dictionary<string, string>();
    }

    public HttpClient(string url)
    {
        request = HttpWebRequest.CreateHttp(url);
        header = new Dictionary<string, string>();
    }

    public void AddHeader(string key, string value)
    {
        header[key] = value;
    }

    public void ClearHeader()
    {
        header.Clear();
    }

    public async Task<HttpResponse> PostAsync<T>(string url, Content<T> content)
    {
        request = HttpWebRequest.CreateHttp(url);
        foreach (var item in header)
        {
            request.Headers.Add(item.Key, item.Value);
        }
        //request.ContentType =
        //Console.WriteLine(request.Host);
        //request. = url;
        request.Method = "POST";
        byte[] temp = content.ReadAsByteArray();
        await request.GetRequestStream().WriteAsync(temp, 0, temp.Length);
        var req = await request.GetResponseAsync();
        return new HttpResponse(req);
    }

    /*public async Task<HttpResponse> PostAsync<T>(string url, Content<T> content, string contentType, string cookie = "")
    {
        request = HttpWebRequest.CreateHttp(url);
        if (cookie != "")
        {
            request.Headers.Add("Cookie", cookie);
        }
        foreach (var item in header)
        {
            request.Headers.Add(item.Key, item.Value);
        }
        request.ContentType = contentType;
        //Console.WriteLine(request.Host);
        //request. = url;
        request.Method = "POST";
        byte[] temp = content.ReadAsByteArray();
        await request.GetRequestStream().WriteAsync(temp, 0, temp.Length);
        var req = await request.GetResponseAsync();
        return new HttpResponse(req);
    }*/
}

public class HttpResponse
{
    private HttpWebResponse webResponse;
    private HttpStatusCode statusCode;
    private StreamContent content;
    private string cookie;

    public HttpStatusCode StatusCode
    {
        get
        {
            return statusCode;
        }
    }

    public Content<Stream> Content
    {
        get
        {
            return content;
        }
    }

    public string Cookie
    {
        get
        {
            return cookie;
        }
    }

    public HttpResponse(WebResponse response)
    {
        webResponse = response as HttpWebResponse;
        statusCode = webResponse.StatusCode;
        content = new StreamContent(webResponse.GetResponseStream());
        int i = 0;
        foreach (var item in webResponse.Headers.AllKeys)
        {
            if (item.Contains("Cookie")) break;
            i++;
        }
        cookie = webResponse.Headers.GetValues(i).FirstOrDefault();
    }
}



public class StringContent : Content<string>
{
    public StringContent(string str) : base(str)
    {

    }

    public override byte[] ReadAsByteArray()
    {
        return Encoding.Default.GetBytes(Con.ToCharArray());
    }

    public override Task<byte[]> ReadAsByteArrayAsync()
    {
        return Task.Run(() =>
        {
            return Encoding.Default.GetBytes(Con.ToCharArray());
        });
    }

    public override Task<string> ReadAsStringAsync()
    {
        return Task.Run(() =>
        {
            return Con;
        });
    }
}

public class StreamContent : Content<Stream>
{
    public StreamContent(Stream stream) : base(stream)
    {
    }

    public override byte[] ReadAsByteArray()
    {
        //StreamReader streamReader = new StreamReader(Con);
        BinaryReader binaryReader = new BinaryReader(Con);
        return binaryReader.ReadBytes((int)Con.Length);
        //return Encoding.Default.GetBytes(streamReader.ReadToEnd());
    }

    public override Task<byte[]> ReadAsByteArrayAsync()
    {
        return Task.Run(() =>
        {
            //StreamReader streamReader = new StreamReader(Con);
            //return Encoding.Default.GetBytes(streamReader.ReadToEnd());
            BinaryReader binaryReader = new BinaryReader(Con);
            return binaryReader.ReadBytes((int)Con.Length);
        });
    }

    public async override Task<string> ReadAsStringAsync()
    {
        StreamReader streamReader = new StreamReader(Con);
        return await streamReader.ReadToEndAsync();
    }
}

public abstract class Content<T> : System.IDisposable
{
    private T con;

    public T Con
    {
        get
        {
            return con;
        }

        set
        {
            con = value;
        }
    }

    public Content()
    {

    }

    public Content(T con)
    {
        this.con = con;
    }

    public void Dispose()
    {

    }

    public abstract Task<string> ReadAsStringAsync();
    public abstract Task<byte[]> ReadAsByteArrayAsync();
    public abstract byte[] ReadAsByteArray();
}

public class MyHttpException : Exception
{
    public MyHttpException()
    {
    }

    public MyHttpException(string message) : base(message)
    {
    }
}
#endif