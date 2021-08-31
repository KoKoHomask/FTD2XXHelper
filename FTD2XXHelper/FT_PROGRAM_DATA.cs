using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace FTD2XXHelper
{
	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	public class FT_PROGRAM_DATA
    {
		public uint Signature1;

		// Token: 0x040000D5 RID: 213
		public uint Signature2;

		// Token: 0x040000D6 RID: 214
		public uint Version;

		// Token: 0x040000D7 RID: 215
		public ushort VendorID;

		// Token: 0x040000D8 RID: 216
		public ushort ProductID;

		// Token: 0x040000D9 RID: 217
		public IntPtr Manufacturer;

		// Token: 0x040000DA RID: 218
		public IntPtr ManufacturerID;

		// Token: 0x040000DB RID: 219
		public IntPtr Description;

		// Token: 0x040000DC RID: 220
		public IntPtr SerialNumber;

		// Token: 0x040000DD RID: 221
		public ushort MaxPower;

		// Token: 0x040000DE RID: 222
		public ushort PnP;

		// Token: 0x040000DF RID: 223
		public ushort SelfPowered;

		// Token: 0x040000E0 RID: 224
		public ushort RemoteWakeup;

		// Token: 0x040000E1 RID: 225
		public byte Rev4;

		// Token: 0x040000E2 RID: 226
		public byte IsoIn;

		// Token: 0x040000E3 RID: 227
		public byte IsoOut;

		// Token: 0x040000E4 RID: 228
		public byte PullDownEnable;

		// Token: 0x040000E5 RID: 229
		public byte SerNumEnable;

		// Token: 0x040000E6 RID: 230
		public byte USBVersionEnable;

		// Token: 0x040000E7 RID: 231
		public ushort USBVersion;

		// Token: 0x040000E8 RID: 232
		public byte Rev5;

		// Token: 0x040000E9 RID: 233
		public byte IsoInA;

		// Token: 0x040000EA RID: 234
		public byte IsoInB;

		// Token: 0x040000EB RID: 235
		public byte IsoOutA;

		// Token: 0x040000EC RID: 236
		public byte IsoOutB;

		// Token: 0x040000ED RID: 237
		public byte PullDownEnable5;

		// Token: 0x040000EE RID: 238
		public byte SerNumEnable5;

		// Token: 0x040000EF RID: 239
		public byte USBVersionEnable5;

		// Token: 0x040000F0 RID: 240
		public ushort USBVersion5;

		// Token: 0x040000F1 RID: 241
		public byte AIsHighCurrent;

		// Token: 0x040000F2 RID: 242
		public byte BIsHighCurrent;

		// Token: 0x040000F3 RID: 243
		public byte IFAIsFifo;

		// Token: 0x040000F4 RID: 244
		public byte IFAIsFifoTar;

		// Token: 0x040000F5 RID: 245
		public byte IFAIsFastSer;

		// Token: 0x040000F6 RID: 246
		public byte AIsVCP;

		// Token: 0x040000F7 RID: 247
		public byte IFBIsFifo;

		// Token: 0x040000F8 RID: 248
		public byte IFBIsFifoTar;

		// Token: 0x040000F9 RID: 249
		public byte IFBIsFastSer;

		// Token: 0x040000FA RID: 250
		public byte BIsVCP;

		// Token: 0x040000FB RID: 251
		public byte UseExtOsc;

		// Token: 0x040000FC RID: 252
		public byte HighDriveIOs;

		// Token: 0x040000FD RID: 253
		public byte EndpointSize;

		// Token: 0x040000FE RID: 254
		public byte PullDownEnableR;

		// Token: 0x040000FF RID: 255
		public byte SerNumEnableR;

		// Token: 0x04000100 RID: 256
		public byte InvertTXD;

		// Token: 0x04000101 RID: 257
		public byte InvertRXD;

		// Token: 0x04000102 RID: 258
		public byte InvertRTS;

		// Token: 0x04000103 RID: 259
		public byte InvertCTS;

		// Token: 0x04000104 RID: 260
		public byte InvertDTR;

		// Token: 0x04000105 RID: 261
		public byte InvertDSR;

		// Token: 0x04000106 RID: 262
		public byte InvertDCD;

		// Token: 0x04000107 RID: 263
		public byte InvertRI;

		// Token: 0x04000108 RID: 264
		public byte Cbus0;

		// Token: 0x04000109 RID: 265
		public byte Cbus1;

		// Token: 0x0400010A RID: 266
		public byte Cbus2;

		// Token: 0x0400010B RID: 267
		public byte Cbus3;

		// Token: 0x0400010C RID: 268
		public byte Cbus4;

		// Token: 0x0400010D RID: 269
		public byte RIsD2XX;

		// Token: 0x0400010E RID: 270
		public byte PullDownEnable7;

		// Token: 0x0400010F RID: 271
		public byte SerNumEnable7;

		// Token: 0x04000110 RID: 272
		public byte ALSlowSlew;

		// Token: 0x04000111 RID: 273
		public byte ALSchmittInput;

		// Token: 0x04000112 RID: 274
		public byte ALDriveCurrent;

		// Token: 0x04000113 RID: 275
		public byte AHSlowSlew;

		// Token: 0x04000114 RID: 276
		public byte AHSchmittInput;

		// Token: 0x04000115 RID: 277
		public byte AHDriveCurrent;

		// Token: 0x04000116 RID: 278
		public byte BLSlowSlew;

		// Token: 0x04000117 RID: 279
		public byte BLSchmittInput;

		// Token: 0x04000118 RID: 280
		public byte BLDriveCurrent;

		// Token: 0x04000119 RID: 281
		public byte BHSlowSlew;

		// Token: 0x0400011A RID: 282
		public byte BHSchmittInput;

		// Token: 0x0400011B RID: 283
		public byte BHDriveCurrent;

		// Token: 0x0400011C RID: 284
		public byte IFAIsFifo7;

		// Token: 0x0400011D RID: 285
		public byte IFAIsFifoTar7;

		// Token: 0x0400011E RID: 286
		public byte IFAIsFastSer7;

		// Token: 0x0400011F RID: 287
		public byte AIsVCP7;

		// Token: 0x04000120 RID: 288
		public byte IFBIsFifo7;

		// Token: 0x04000121 RID: 289
		public byte IFBIsFifoTar7;

		// Token: 0x04000122 RID: 290
		public byte IFBIsFastSer7;

		// Token: 0x04000123 RID: 291
		public byte BIsVCP7;

		// Token: 0x04000124 RID: 292
		public byte PowerSaveEnable;

		// Token: 0x04000125 RID: 293
		public byte PullDownEnable8;

		// Token: 0x04000126 RID: 294
		public byte SerNumEnable8;

		// Token: 0x04000127 RID: 295
		public byte ASlowSlew;

		// Token: 0x04000128 RID: 296
		public byte ASchmittInput;

		// Token: 0x04000129 RID: 297
		public byte ADriveCurrent;

		// Token: 0x0400012A RID: 298
		public byte BSlowSlew;

		// Token: 0x0400012B RID: 299
		public byte BSchmittInput;

		// Token: 0x0400012C RID: 300
		public byte BDriveCurrent;

		// Token: 0x0400012D RID: 301
		public byte CSlowSlew;

		// Token: 0x0400012E RID: 302
		public byte CSchmittInput;

		// Token: 0x0400012F RID: 303
		public byte CDriveCurrent;

		// Token: 0x04000130 RID: 304
		public byte DSlowSlew;

		// Token: 0x04000131 RID: 305
		public byte DSchmittInput;

		// Token: 0x04000132 RID: 306
		public byte DDriveCurrent;

		// Token: 0x04000133 RID: 307
		public byte ARIIsTXDEN;

		// Token: 0x04000134 RID: 308
		public byte BRIIsTXDEN;

		// Token: 0x04000135 RID: 309
		public byte CRIIsTXDEN;

		// Token: 0x04000136 RID: 310
		public byte DRIIsTXDEN;

		// Token: 0x04000137 RID: 311
		public byte AIsVCP8;

		// Token: 0x04000138 RID: 312
		public byte BIsVCP8;

		// Token: 0x04000139 RID: 313
		public byte CIsVCP8;

		// Token: 0x0400013A RID: 314
		public byte DIsVCP8;

		// Token: 0x0400013B RID: 315
		public byte PullDownEnableH;

		// Token: 0x0400013C RID: 316
		public byte SerNumEnableH;

		// Token: 0x0400013D RID: 317
		public byte ACSlowSlewH;

		// Token: 0x0400013E RID: 318
		public byte ACSchmittInputH;

		// Token: 0x0400013F RID: 319
		public byte ACDriveCurrentH;

		// Token: 0x04000140 RID: 320
		public byte ADSlowSlewH;

		// Token: 0x04000141 RID: 321
		public byte ADSchmittInputH;

		// Token: 0x04000142 RID: 322
		public byte ADDriveCurrentH;

		// Token: 0x04000143 RID: 323
		public byte Cbus0H;

		// Token: 0x04000144 RID: 324
		public byte Cbus1H;

		// Token: 0x04000145 RID: 325
		public byte Cbus2H;

		// Token: 0x04000146 RID: 326
		public byte Cbus3H;

		// Token: 0x04000147 RID: 327
		public byte Cbus4H;

		// Token: 0x04000148 RID: 328
		public byte Cbus5H;

		// Token: 0x04000149 RID: 329
		public byte Cbus6H;

		// Token: 0x0400014A RID: 330
		public byte Cbus7H;

		// Token: 0x0400014B RID: 331
		public byte Cbus8H;

		// Token: 0x0400014C RID: 332
		public byte Cbus9H;

		// Token: 0x0400014D RID: 333
		public byte IsFifoH;

		// Token: 0x0400014E RID: 334
		public byte IsFifoTarH;

		// Token: 0x0400014F RID: 335
		public byte IsFastSerH;

		// Token: 0x04000150 RID: 336
		public byte IsFT1248H;

		// Token: 0x04000151 RID: 337
		public byte FT1248CpolH;

		// Token: 0x04000152 RID: 338
		public byte FT1248LsbH;

		// Token: 0x04000153 RID: 339
		public byte FT1248FlowControlH;

		// Token: 0x04000154 RID: 340
		public byte IsVCPH;

		// Token: 0x04000155 RID: 341
		public byte PowerSaveEnableH;
	}
}
