using System;
using System.Collections.Generic;
using System.Text;

namespace FTD2XXHelper
{
	public class FT_DEVICE_INFO_NODE
	{
		public uint Flags;

		// Token: 0x040000CE RID: 206
		public FT_DEVICE Type;

		// Token: 0x040000CF RID: 207
		public uint ID;

		// Token: 0x040000D0 RID: 208
		public uint LocId;

		// Token: 0x040000D1 RID: 209
		public string SerialNumber;

		// Token: 0x040000D2 RID: 210
		public string Description;

		// Token: 0x040000D3 RID: 211
		public IntPtr ftHandle;
	}
}
