﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mono.Net;
using System.IO;
using System.Threading;
using Newtonsoft.Json;
using System.Web;
namespace Snowflake.Core.Server
{
    public class APIServer
    {
        HttpListener serverListener;
        Thread serverThread;
        public APIServer()
        {
            serverListener = new HttpListener();
            serverListener.Prefixes.Add("http://localhost:9000/");
        }
        public void StartServer()
        {
            this.serverThread = new Thread(
                () =>
                {
                    serverListener.Start();
                    while (true)
                    {
                        HttpListenerContext context = serverListener.GetContext();
                        this.Process(context);
                    }
                }
            );
                       
            this.serverThread.Start();          
        }
        private void Process(HttpListenerContext context)
        {
            string getRequest = context.Request.Url.AbsolutePath.Remove(0,1); //Remove first slash
            string getUri = context.Request.Url.AbsoluteUri;
            int index = getUri.IndexOf("?");
            var dictParams = new Dictionary<string, string>();
            if ( index > 0 ){
                string rawParams = getUri.Substring(index).Remove (0, 1);
                var nvcParams = HttpUtility.ParseQueryString(rawParams);
                dictParams =  nvcParams.AllKeys.ToDictionary(o => o, o => nvcParams[o]);
            }
            var request = new JSRequest(getRequest.Split('/')[0], dictParams);
            StreamWriter writer = new StreamWriter(context.Response.OutputStream);
            writer.WriteLine(ProcessRequest(request));
            writer.Flush();
            context.Response.OutputStream.Close();
        }

        private string ProcessRequest(JSRequest args)
        {
            string method = args.MethodName;
            switch (method)
            {
                case "Test":
                    return JsonConvert.SerializeObject(new Dictionary<string, string>()
                    {
                        {"response", "success"}
                    });
                case "GetAllPlatforms":
                    return JsonConvert.SerializeObject(FrontendCore.LoadedCore.LoadedPlatforms);
                case "GetPlatform":
                    if (args.MethodParameters.ContainsKey("platformid"))
                        return JsonConvert.SerializeObject(FrontendCore.LoadedCore.LoadedPlatforms[args.MethodParameters["platformid"]]);
                    else goto default;
                default:
                    return "invalid";

            }
        }
        public void StopServer()
        {
            this.serverThread.Abort();
            this.serverListener.Stop();
        }
    }

    public class JSRequest{

        public string MethodName { get; private set; }
        public IDictionary<string, string> MethodParameters { get; private set; }
        public JSRequest(string methodName, IDictionary<string, string> parameters)
        {
            this.MethodName = methodName;
            this.MethodParameters = parameters;
        }
    }
}
