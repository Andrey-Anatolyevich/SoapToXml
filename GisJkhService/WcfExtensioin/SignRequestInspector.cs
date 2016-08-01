using System.IO;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.Xml;

namespace SampleService.WcfExtensioin
{
	///<summary> Инспектор для подписывания XML сообщений </summary>
	public class SignRequestInspector : IClientMessageInspector
	{
		public void AfterReceiveReply(ref Message reply, object correlationState) { }

		///<summary> Обработчик перед отправкой запросов </summary>
		public object BeforeSendRequest(ref Message request, IClientChannel channel)
		{
			XmlDocument doc = new XmlDocument();
			MemoryStream ms = new MemoryStream();
			XmlWriter writer = XmlWriter.Create(ms);
			request.WriteMessage(writer);
			writer.Flush();
			ms.Position = 0;
			doc.Load(ms);
			// На данный момент XML хранится в doc

			// Подписали XML
			SignXml(doc);

			// Вернули XML в сообщение для отправки.
			ms.SetLength(0);
			writer = XmlWriter.Create(ms);
			doc.WriteTo(writer);
			writer.Flush();
			ms.Position = 0;
			XmlReader reader = XmlReader.Create(ms);
			request = Message.CreateMessage(reader, int.MaxValue, request.Version);

			return null;
		}

		///<summary> Подписать XML </summary>
		void SignXml(XmlDocument doc)
		{
			//TODO: Необходимо как-то подписать документ.
			// doc = SignDoc(doc);
		}
	}
}
