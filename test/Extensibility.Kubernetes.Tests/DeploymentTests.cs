using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Extensibility.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;

namespace Extensibility.Kubernetes.Tests
{
    // These tests require a connection to a Kubernetes cluster to function. 
    // You can use something like Minikube or docker Kubernetes. You should have the desired
    // cluster set as your current context ... eg: `kubectl get pod` should work against
    // the cluster you intend to use.
    [TestClass]
    public class DeploymentTests
    {
        private static readonly JObject Deployment = new JObject()
        {
            ["metadata"] = new JObject()
            {
                ["name"] = "test-deployment",
            },
            ["spec"] = new JObject()
            {
                ["selector"] = new JObject()
                {
                    ["matchLabels"] = new JObject()
                    {
                        ["app"] = "test-deployment",
                    }
                },
                ["template"] = new JObject()
                {
                    ["metadata"] = new JObject()
                    {
                        ["labels"] = new JObject()
                        {
                            ["app"] = "test-deployment",
                        },
                    },
                    ["spec"] = new JObject()
                    {
                        ["containers"] = new JArray()
                        {
                            new JObject()
                            {
                                ["name"] = "magpie",
                                ["image"] = "radius.azurecr.io/magpie:latest",
                            },
                        },
                    },
                },
            },
        };

        [TestMethod]
        public async Task Save_Deployment()
        {
            await CrudHelper.Save(new()
            {
                Type = "apps/Deployment@v1",
                Import = new()
                {
                    Provider = "Kubernetes",
                    Config = new JObject()
                    {
                        ["namespace"] = "default",
                    },
                },
                Properties = Deployment,
            }, CancellationToken.None);
        }
    }
}