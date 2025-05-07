using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog3
{
	public class JournalEntry
	{
		public int ID { get; set; }
		public string N_Shtang { get; set; }
		public string N_Vann { get; set; }
		public string N_Zaves { get; set; }
		public string N_Zakaz { get; set; }
		public string Uslovie { get; set; }
		public string S_A { get; set; }
		public string S_B { get; set; }
		public string S_A_Sum { get; set; }
		public string S_B_Sum { get; set; }
		public string I_A_Sn { get; set; }
		public string I_B_Sn { get; set; }
		public string I_A_Cu { get; set; }
		public string I_B_Cu { get; set; }
		public bool Zanos_v_BD { get; set; }
		public bool Zagruz_v_Line { get; set; }
		public bool Exit_s_Line { get; set; }
		public DateTime Date { get; set; }
		public string FIO { get; set; }
		public string Comment { get; set; }
	}
}
