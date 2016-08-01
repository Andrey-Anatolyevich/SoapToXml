using SampleService.GisZkhService;
using SampleService.WcfExtensioin;
using System;

namespace SampleService
{
	class Program
	{
		///<summary> Entrance </summary>
		public static void Main(String[] args)
		{
			// Создали клиента для сервиса.
			FASPortsTypeAsyncClient client = new FASPortsTypeAsyncClient();
			// Логин, пароль
			client.ClientCredentials.UserName.UserName = "LOGIN"; 
			client.ClientCredentials.UserName.Password = "Pass"; 

			// Строка для возможности извлечения XML из SOAP сообщений
			client.Endpoint.EndpointBehaviors.Add(new MyBehavior());
		}
	}
}
