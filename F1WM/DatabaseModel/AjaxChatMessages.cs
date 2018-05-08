using System;
using System.Collections.Generic;

namespace F1WM.DatabaseModel
{
	public class AjaxChatMessages
	{
		public int Id { get; set; }
		public int UserId { get; set; }
		public string UserName { get; set; }
		public int UserRole { get; set; }
		public int Channel { get; set; }
		public DateTime DateTime { get; set; }
		public byte[] Ip { get; set; }
		public string Text { get; set; }
	}
}
