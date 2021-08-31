using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace FTD2XXHelper
{
	#region 相关枚举
	public class FT_EEPROM_DATA
	{
		// Token: 0x04000180 RID: 384
		public ushort VendorID = 1027;

		// Token: 0x04000181 RID: 385
		public ushort ProductID = 24577;

		// Token: 0x04000182 RID: 386
		public string Manufacturer = "FTDI";

		// Token: 0x04000183 RID: 387
		public string ManufacturerID = "FT";

		// Token: 0x04000184 RID: 388
		public string Description = "USB-Serial Converter";

		// Token: 0x04000185 RID: 389
		public string SerialNumber = "";

		// Token: 0x04000186 RID: 390
		public ushort MaxPower = 144;

		// Token: 0x04000187 RID: 391
		public bool SelfPowered;

		// Token: 0x04000188 RID: 392
		public bool RemoteWakeup;
	}
	public class FT2232H_EEPROM_STRUCTURE : FT_EEPROM_DATA
	{
		// Token: 0x040001AE RID: 430
		public bool PullDownEnable;

		// Token: 0x040001AF RID: 431
		public bool SerNumEnable = true;

		// Token: 0x040001B0 RID: 432
		public bool ALSlowSlew;

		// Token: 0x040001B1 RID: 433
		public bool ALSchmittInput;

		// Token: 0x040001B2 RID: 434
		public byte ALDriveCurrent = 4;

		// Token: 0x040001B3 RID: 435
		public bool AHSlowSlew;

		// Token: 0x040001B4 RID: 436
		public bool AHSchmittInput;

		// Token: 0x040001B5 RID: 437
		public byte AHDriveCurrent = 4;

		// Token: 0x040001B6 RID: 438
		public bool BLSlowSlew;

		// Token: 0x040001B7 RID: 439
		public bool BLSchmittInput;

		// Token: 0x040001B8 RID: 440
		public byte BLDriveCurrent = 4;

		// Token: 0x040001B9 RID: 441
		public bool BHSlowSlew;

		// Token: 0x040001BA RID: 442
		public bool BHSchmittInput;

		// Token: 0x040001BB RID: 443
		public byte BHDriveCurrent = 4;

		// Token: 0x040001BC RID: 444
		public bool IFAIsFifo;

		// Token: 0x040001BD RID: 445
		public bool IFAIsFifoTar;

		// Token: 0x040001BE RID: 446
		public bool IFAIsFastSer;

		// Token: 0x040001BF RID: 447
		public bool AIsVCP = true;

		// Token: 0x040001C0 RID: 448
		public bool IFBIsFifo;

		// Token: 0x040001C1 RID: 449
		public bool IFBIsFifoTar;

		// Token: 0x040001C2 RID: 450
		public bool IFBIsFastSer;

		// Token: 0x040001C3 RID: 451
		public bool BIsVCP = true;

		// Token: 0x040001C4 RID: 452
		public bool PowerSaveEnable;
	}
	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	public struct FT_EEPROM_HEADER
	{
		// Token: 0x04000156 RID: 342
		public uint deviceType;

		// Token: 0x04000157 RID: 343
		public ushort VendorId;

		// Token: 0x04000158 RID: 344
		public ushort ProductId;

		// Token: 0x04000159 RID: 345
		public byte SerNumEnable;

		// Token: 0x0400015A RID: 346
		public ushort MaxPower;

		// Token: 0x0400015B RID: 347
		public byte SelfPowered;

		// Token: 0x0400015C RID: 348
		public byte RemoteWakeup;

		// Token: 0x0400015D RID: 349
		public byte PullDownEnable;
	}
	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	public struct FT_XSERIES_DATA
	{
		// Token: 0x0400015E RID: 350
		public FT_EEPROM_HEADER common;

		// Token: 0x0400015F RID: 351
		public byte ACSlowSlew;

		// Token: 0x04000160 RID: 352
		public byte ACSchmittInput;

		// Token: 0x04000161 RID: 353
		public byte ACDriveCurrent;

		// Token: 0x04000162 RID: 354
		public byte ADSlowSlew;

		// Token: 0x04000163 RID: 355
		public byte ADSchmittInput;

		// Token: 0x04000164 RID: 356
		public byte ADDriveCurrent;

		// Token: 0x04000165 RID: 357
		public byte Cbus0;

		// Token: 0x04000166 RID: 358
		public byte Cbus1;

		// Token: 0x04000167 RID: 359
		public byte Cbus2;

		// Token: 0x04000168 RID: 360
		public byte Cbus3;

		// Token: 0x04000169 RID: 361
		public byte Cbus4;

		// Token: 0x0400016A RID: 362
		public byte Cbus5;

		// Token: 0x0400016B RID: 363
		public byte Cbus6;

		// Token: 0x0400016C RID: 364
		public byte InvertTXD;

		// Token: 0x0400016D RID: 365
		public byte InvertRXD;

		// Token: 0x0400016E RID: 366
		public byte InvertRTS;

		// Token: 0x0400016F RID: 367
		public byte InvertCTS;

		// Token: 0x04000170 RID: 368
		public byte InvertDTR;

		// Token: 0x04000171 RID: 369
		public byte InvertDSR;

		// Token: 0x04000172 RID: 370
		public byte InvertDCD;

		// Token: 0x04000173 RID: 371
		public byte InvertRI;

		// Token: 0x04000174 RID: 372
		public byte BCDEnable;

		// Token: 0x04000175 RID: 373
		public byte BCDForceCbusPWREN;

		// Token: 0x04000176 RID: 374
		public byte BCDDisableSleep;

		// Token: 0x04000177 RID: 375
		public ushort I2CSlaveAddress;

		// Token: 0x04000178 RID: 376
		public uint I2CDeviceId;

		// Token: 0x04000179 RID: 377
		public byte I2CDisableSchmitt;

		// Token: 0x0400017A RID: 378
		public byte FT1248Cpol;

		// Token: 0x0400017B RID: 379
		public byte FT1248Lsb;

		// Token: 0x0400017C RID: 380
		public byte FT1248FlowControl;

		// Token: 0x0400017D RID: 381
		public byte RS485EchoSuppress;

		// Token: 0x0400017E RID: 382
		public byte PowerSaveEnable;

		// Token: 0x0400017F RID: 383
		public byte DriverType;
	}
	public class FT_XSERIES_EEPROM_STRUCTURE : FT_EEPROM_DATA
	{
		// Token: 0x040001F6 RID: 502
		public bool PullDownEnable;

		// Token: 0x040001F7 RID: 503
		public bool SerNumEnable = true;

		// Token: 0x040001F8 RID: 504
		public bool USBVersionEnable = true;

		// Token: 0x040001F9 RID: 505
		public ushort USBVersion = 512;

		// Token: 0x040001FA RID: 506
		public byte ACSlowSlew;

		// Token: 0x040001FB RID: 507
		public byte ACSchmittInput;

		// Token: 0x040001FC RID: 508
		public byte ACDriveCurrent;

		// Token: 0x040001FD RID: 509
		public byte ADSlowSlew;

		// Token: 0x040001FE RID: 510
		public byte ADSchmittInput;

		// Token: 0x040001FF RID: 511
		public byte ADDriveCurrent;

		// Token: 0x04000200 RID: 512
		public byte Cbus0;

		// Token: 0x04000201 RID: 513
		public byte Cbus1;

		// Token: 0x04000202 RID: 514
		public byte Cbus2;

		// Token: 0x04000203 RID: 515
		public byte Cbus3;

		// Token: 0x04000204 RID: 516
		public byte Cbus4;

		// Token: 0x04000205 RID: 517
		public byte Cbus5;

		// Token: 0x04000206 RID: 518
		public byte Cbus6;

		// Token: 0x04000207 RID: 519
		public byte InvertTXD;

		// Token: 0x04000208 RID: 520
		public byte InvertRXD;

		// Token: 0x04000209 RID: 521
		public byte InvertRTS;

		// Token: 0x0400020A RID: 522
		public byte InvertCTS;

		// Token: 0x0400020B RID: 523
		public byte InvertDTR;

		// Token: 0x0400020C RID: 524
		public byte InvertDSR;

		// Token: 0x0400020D RID: 525
		public byte InvertDCD;

		// Token: 0x0400020E RID: 526
		public byte InvertRI;

		// Token: 0x0400020F RID: 527
		public byte BCDEnable;

		// Token: 0x04000210 RID: 528
		public byte BCDForceCbusPWREN;

		// Token: 0x04000211 RID: 529
		public byte BCDDisableSleep;

		// Token: 0x04000212 RID: 530
		public ushort I2CSlaveAddress;

		// Token: 0x04000213 RID: 531
		public uint I2CDeviceId;

		// Token: 0x04000214 RID: 532
		public byte I2CDisableSchmitt;

		// Token: 0x04000215 RID: 533
		public byte FT1248Cpol;

		// Token: 0x04000216 RID: 534
		public byte FT1248Lsb;

		// Token: 0x04000217 RID: 535
		public byte FT1248FlowControl;

		// Token: 0x04000218 RID: 536
		public byte RS485EchoSuppress;

		// Token: 0x04000219 RID: 537
		public byte PowerSaveEnable;

		// Token: 0x0400021A RID: 538
		public byte IsVCP;
	}
	public class FT4232H_EEPROM_STRUCTURE : FT_EEPROM_DATA
	{
		// Token: 0x040001C5 RID: 453
		public bool PullDownEnable;

		// Token: 0x040001C6 RID: 454
		public bool SerNumEnable = true;

		// Token: 0x040001C7 RID: 455
		public bool ASlowSlew;

		// Token: 0x040001C8 RID: 456
		public bool ASchmittInput;

		// Token: 0x040001C9 RID: 457
		public byte ADriveCurrent = 4;

		// Token: 0x040001CA RID: 458
		public bool BSlowSlew;

		// Token: 0x040001CB RID: 459
		public bool BSchmittInput;

		// Token: 0x040001CC RID: 460
		public byte BDriveCurrent = 4;

		// Token: 0x040001CD RID: 461
		public bool CSlowSlew;

		// Token: 0x040001CE RID: 462
		public bool CSchmittInput;

		// Token: 0x040001CF RID: 463
		public byte CDriveCurrent = 4;

		// Token: 0x040001D0 RID: 464
		public bool DSlowSlew;

		// Token: 0x040001D1 RID: 465
		public bool DSchmittInput;

		// Token: 0x040001D2 RID: 466
		public byte DDriveCurrent = 4;

		// Token: 0x040001D3 RID: 467
		public bool ARIIsTXDEN;

		// Token: 0x040001D4 RID: 468
		public bool BRIIsTXDEN;

		// Token: 0x040001D5 RID: 469
		public bool CRIIsTXDEN;

		// Token: 0x040001D6 RID: 470
		public bool DRIIsTXDEN;

		// Token: 0x040001D7 RID: 471
		public bool AIsVCP = true;

		// Token: 0x040001D8 RID: 472
		public bool BIsVCP = true;

		// Token: 0x040001D9 RID: 473
		public bool CIsVCP = true;

		// Token: 0x040001DA RID: 474
		public bool DIsVCP = true;
	}
	public class FT232R_EEPROM_STRUCTURE : FT_EEPROM_DATA
	{
		// Token: 0x0400019B RID: 411
		public bool UseExtOsc;

		// Token: 0x0400019C RID: 412
		public bool HighDriveIOs;

		// Token: 0x0400019D RID: 413
		public byte EndpointSize = 64;

		// Token: 0x0400019E RID: 414
		public bool PullDownEnable;

		// Token: 0x0400019F RID: 415
		public bool SerNumEnable = true;

		// Token: 0x040001A0 RID: 416
		public bool InvertTXD;

		// Token: 0x040001A1 RID: 417
		public bool InvertRXD;

		// Token: 0x040001A2 RID: 418
		public bool InvertRTS;

		// Token: 0x040001A3 RID: 419
		public bool InvertCTS;

		// Token: 0x040001A4 RID: 420
		public bool InvertDTR;

		// Token: 0x040001A5 RID: 421
		public bool InvertDSR;

		// Token: 0x040001A6 RID: 422
		public bool InvertDCD;

		// Token: 0x040001A7 RID: 423
		public bool InvertRI;

		// Token: 0x040001A8 RID: 424
		public byte Cbus0 = 5;

		// Token: 0x040001A9 RID: 425
		public byte Cbus1 = 5;

		// Token: 0x040001AA RID: 426
		public byte Cbus2 = 5;

		// Token: 0x040001AB RID: 427
		public byte Cbus3 = 5;

		// Token: 0x040001AC RID: 428
		public byte Cbus4 = 5;

		// Token: 0x040001AD RID: 429
		public bool RIsD2XX;
	}
	public class FT232H_EEPROM_STRUCTURE : FT_EEPROM_DATA
	{
		// Token: 0x040001DB RID: 475
		public bool PullDownEnable;

		// Token: 0x040001DC RID: 476
		public bool SerNumEnable = true;

		// Token: 0x040001DD RID: 477
		public bool ACSlowSlew;

		// Token: 0x040001DE RID: 478
		public bool ACSchmittInput;

		// Token: 0x040001DF RID: 479
		public byte ACDriveCurrent = 4;

		// Token: 0x040001E0 RID: 480
		public bool ADSlowSlew;

		// Token: 0x040001E1 RID: 481
		public bool ADSchmittInput;

		// Token: 0x040001E2 RID: 482
		public byte ADDriveCurrent = 4;

		// Token: 0x040001E3 RID: 483
		public byte Cbus0;

		// Token: 0x040001E4 RID: 484
		public byte Cbus1;

		// Token: 0x040001E5 RID: 485
		public byte Cbus2;

		// Token: 0x040001E6 RID: 486
		public byte Cbus3;

		// Token: 0x040001E7 RID: 487
		public byte Cbus4;

		// Token: 0x040001E8 RID: 488
		public byte Cbus5;

		// Token: 0x040001E9 RID: 489
		public byte Cbus6;

		// Token: 0x040001EA RID: 490
		public byte Cbus7;

		// Token: 0x040001EB RID: 491
		public byte Cbus8;

		// Token: 0x040001EC RID: 492
		public byte Cbus9;

		// Token: 0x040001ED RID: 493
		public bool IsFifo;

		// Token: 0x040001EE RID: 494
		public bool IsFifoTar;

		// Token: 0x040001EF RID: 495
		public bool IsFastSer;

		// Token: 0x040001F0 RID: 496
		public bool IsFT1248;

		// Token: 0x040001F1 RID: 497
		public bool FT1248Cpol;

		// Token: 0x040001F2 RID: 498
		public bool FT1248Lsb;

		// Token: 0x040001F3 RID: 499
		public bool FT1248FlowControl;

		// Token: 0x040001F4 RID: 500
		public bool IsVCP = true;

		// Token: 0x040001F5 RID: 501
		public bool PowerSaveEnable;
	}
	public class FT232B_EEPROM_STRUCTURE : FT_EEPROM_DATA
	{
		// Token: 0x04000189 RID: 393
		public bool PullDownEnable;

		// Token: 0x0400018A RID: 394
		public bool SerNumEnable = true;

		// Token: 0x0400018B RID: 395
		public bool USBVersionEnable = true;

		// Token: 0x0400018C RID: 396
		public ushort USBVersion = 512;
	}
	public class FT2232_EEPROM_STRUCTURE : FT_EEPROM_DATA
	{
		// Token: 0x0400018D RID: 397
		public bool PullDownEnable;

		// Token: 0x0400018E RID: 398
		public bool SerNumEnable = true;

		// Token: 0x0400018F RID: 399
		public bool USBVersionEnable = true;

		// Token: 0x04000190 RID: 400
		public ushort USBVersion = 512;

		// Token: 0x04000191 RID: 401
		public bool AIsHighCurrent;

		// Token: 0x04000192 RID: 402
		public bool BIsHighCurrent;

		// Token: 0x04000193 RID: 403
		public bool IFAIsFifo;

		// Token: 0x04000194 RID: 404
		public bool IFAIsFifoTar;

		// Token: 0x04000195 RID: 405
		public bool IFAIsFastSer;

		// Token: 0x04000196 RID: 406
		public bool AIsVCP = true;

		// Token: 0x04000197 RID: 407
		public bool IFBIsFifo;

		// Token: 0x04000198 RID: 408
		public bool IFBIsFifoTar;

		// Token: 0x04000199 RID: 409
		public bool IFBIsFastSer;

		// Token: 0x0400019A RID: 410
		public bool BIsVCP = true;
	}
	public enum FT_WORDLENGTH
	{
		FT_BITS_8 = 8,
		FT_BITS_7 = 7
	}
	public enum FT_STOPBITS
	{
		FT_STOP_BITS_1 = 0,
		FT_STOP_BITS_2 = 2,
	}
	public enum FT_PARITY
	{
		FT_PARITY_NONE = 0,
		FT_PARITY_ODD,
		FT_PARITY_EVEN,
		FT_PARITY_MARK,
		FT_PARITY_SPACE
	}

	public enum FT_ERROR
	{
		// Token: 0x04000057 RID: 87
		FT_NO_ERROR,
		// Token: 0x04000058 RID: 88
		FT_INCORRECT_DEVICE,
		// Token: 0x04000059 RID: 89
		FT_INVALID_BITMODE,
		// Token: 0x0400005A RID: 90
		FT_BUFFER_SIZE
	}
	public enum FT_DEVICE
	{
		// Token: 0x040000B4 RID: 180
		FT_DEVICE_BM,
		// Token: 0x040000B5 RID: 181
		FT_DEVICE_AM,
		// Token: 0x040000B6 RID: 182
		FT_DEVICE_100AX,
		// Token: 0x040000B7 RID: 183
		FT_DEVICE_UNKNOWN,
		// Token: 0x040000B8 RID: 184
		FT_DEVICE_2232,
		// Token: 0x040000B9 RID: 185
		FT_DEVICE_232R,
		// Token: 0x040000BA RID: 186
		FT_DEVICE_2232H,
		// Token: 0x040000BB RID: 187
		FT_DEVICE_4232H,
		// Token: 0x040000BC RID: 188
		FT_DEVICE_232H,
		// Token: 0x040000BD RID: 189
		FT_DEVICE_X_SERIES,
		// Token: 0x040000BE RID: 190
		FT_DEVICE_4222H_0,
		// Token: 0x040000BF RID: 191
		FT_DEVICE_4222H_1_2,
		// Token: 0x040000C0 RID: 192
		FT_DEVICE_4222H_3,
		// Token: 0x040000C1 RID: 193
		FT_DEVICE_4222_PROG,
		// Token: 0x040000C2 RID: 194
		FT_DEVICE_FT900,
		// Token: 0x040000C3 RID: 195
		FT_DEVICE_FT930,
		// Token: 0x040000C4 RID: 196
		FT_DEVICE_UMFTPD3A,
		// Token: 0x040000C5 RID: 197
		FT_DEVICE_2233HP,
		// Token: 0x040000C6 RID: 198
		FT_DEVICE_4233HP,
		// Token: 0x040000C7 RID: 199
		FT_DEVICE_2232HP,
		// Token: 0x040000C8 RID: 200
		FT_DEVICE_4232HP,
		// Token: 0x040000C9 RID: 201
		FT_DEVICE_233HP,
		// Token: 0x040000CA RID: 202
		FT_DEVICE_232HP,
		// Token: 0x040000CB RID: 203
		FT_DEVICE_2232HA,
		// Token: 0x040000CC RID: 204
		FT_DEVICE_4232HA
	}
	public enum FT_STATUS
	{
		// Token: 0x04000044 RID: 68
		FT_OK,
		// Token: 0x04000045 RID: 69
		FT_INVALID_HANDLE,
		// Token: 0x04000046 RID: 70
		FT_DEVICE_NOT_FOUND,
		// Token: 0x04000047 RID: 71
		FT_DEVICE_NOT_OPENED,
		// Token: 0x04000048 RID: 72
		FT_IO_ERROR,
		// Token: 0x04000049 RID: 73
		FT_INSUFFICIENT_RESOURCES,
		// Token: 0x0400004A RID: 74
		FT_INVALID_PARAMETER,
		// Token: 0x0400004B RID: 75
		FT_INVALID_BAUD_RATE,
		// Token: 0x0400004C RID: 76
		FT_DEVICE_NOT_OPENED_FOR_ERASE,
		// Token: 0x0400004D RID: 77
		FT_DEVICE_NOT_OPENED_FOR_WRITE,
		// Token: 0x0400004E RID: 78
		FT_FAILED_TO_WRITE_DEVICE,
		// Token: 0x0400004F RID: 79
		FT_EEPROM_READ_FAILED,
		// Token: 0x04000050 RID: 80
		FT_EEPROM_WRITE_FAILED,
		// Token: 0x04000051 RID: 81
		FT_EEPROM_ERASE_FAILED,
		// Token: 0x04000052 RID: 82
		FT_EEPROM_NOT_PRESENT,
		// Token: 0x04000053 RID: 83
		FT_EEPROM_NOT_PROGRAMMED,
		// Token: 0x04000054 RID: 84
		FT_INVALID_ARGS,
		// Token: 0x04000055 RID: 85
		FT_OTHER_ERROR
	}
	#endregion
}
