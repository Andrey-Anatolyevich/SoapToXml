using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace SampleService.WcfExtensioin
{
	///<summary> Кастомное поведение для WCF Client </summary>
	public class MyBehavior : IEndpointBehavior
	{
		public void AddBindingParameters(ServiceEndpoint endpoint
			, BindingParameterCollection bindingParameters)
		{ }

		///<summary> Метод для привязки своего инспектора сообщений </summary>
		public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
		{
			// Экземпляр инспектора Запросов
			SignRequestInspector inspector = new SignRequestInspector();
			// Добавили нашего инспектора в список инспекторов запросов
			clientRuntime.MessageInspectors.Add(inspector);
		}

		public void ApplyDispatchBehavior(ServiceEndpoint endpoint
			, EndpointDispatcher endpointDispatcher)
		{ }

		public void Validate(ServiceEndpoint endpoint) { }
	}
}
