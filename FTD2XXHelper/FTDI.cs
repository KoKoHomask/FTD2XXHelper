using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace FTD2XXHelper
{
    public class FTDI
    {
        #region 相关IntPtr
        private IntPtr ftHandle = IntPtr.Zero;

		private IntPtr hFTD2XXDLL = IntPtr.Zero;

		private IntPtr pFT_CreateDeviceInfoList = IntPtr.Zero;

		private IntPtr pFT_GetDeviceInfoDetail = IntPtr.Zero;

		private IntPtr pFT_Open = IntPtr.Zero;

		private IntPtr pFT_OpenEx = IntPtr.Zero;

		private IntPtr pFT_Close = IntPtr.Zero;

		private IntPtr pFT_Read = IntPtr.Zero;

		private IntPtr pFT_Write = IntPtr.Zero;

		private IntPtr pFT_GetQueueStatus = IntPtr.Zero;

		private IntPtr pFT_GetModemStatus = IntPtr.Zero;

		private IntPtr pFT_GetStatus = IntPtr.Zero;
		private IntPtr pFT_SetBaudRate = IntPtr.Zero;

		private IntPtr pFT_SetDataCharacteristics = IntPtr.Zero;

		private IntPtr pFT_SetFlowControl = IntPtr.Zero;

		private IntPtr pFT_SetDtr = IntPtr.Zero;

		private IntPtr pFT_ClrDtr = IntPtr.Zero;

		private IntPtr pFT_SetRts = IntPtr.Zero;

		private IntPtr pFT_ClrRts = IntPtr.Zero;

		private IntPtr pFT_ResetDevice = IntPtr.Zero;

		private IntPtr pFT_ResetPort = IntPtr.Zero;

		private IntPtr pFT_CyclePort = IntPtr.Zero;

		private IntPtr pFT_Rescan = IntPtr.Zero;

		private IntPtr pFT_Reload = IntPtr.Zero;

		private IntPtr pFT_Purge = IntPtr.Zero;

		private IntPtr pFT_SetTimeouts = IntPtr.Zero;

		private IntPtr pFT_SetBreakOn = IntPtr.Zero;

		private IntPtr pFT_SetBreakOff = IntPtr.Zero;

		private IntPtr pFT_GetDeviceInfo = IntPtr.Zero;

		private IntPtr pFT_SetResetPipeRetryCount = IntPtr.Zero;

		private IntPtr pFT_StopInTask = IntPtr.Zero;

		private IntPtr pFT_RestartInTask = IntPtr.Zero;

		private IntPtr pFT_GetDriverVersion = IntPtr.Zero;

		private IntPtr pFT_GetLibraryVersion = IntPtr.Zero;

		private IntPtr pFT_SetDeadmanTimeout = IntPtr.Zero;

		private IntPtr pFT_SetChars = IntPtr.Zero;

		private IntPtr pFT_SetEventNotification = IntPtr.Zero;

		private IntPtr pFT_GetComPortNumber = IntPtr.Zero;

		private IntPtr pFT_SetLatencyTimer = IntPtr.Zero;

		private IntPtr pFT_GetLatencyTimer = IntPtr.Zero;

		private IntPtr pFT_SetBitMode = IntPtr.Zero;

		private IntPtr pFT_GetBitMode = IntPtr.Zero;

		private IntPtr pFT_SetUSBParameters = IntPtr.Zero;

		private IntPtr pFT_ReadEE = IntPtr.Zero;

		private IntPtr pFT_WriteEE = IntPtr.Zero;

		private IntPtr pFT_EraseEE = IntPtr.Zero;

		private IntPtr pFT_EE_UASize = IntPtr.Zero;

		private IntPtr pFT_EE_UARead = IntPtr.Zero;

		private IntPtr pFT_EE_UAWrite = IntPtr.Zero;

		private IntPtr pFT_EE_Read = IntPtr.Zero;

		private IntPtr pFT_EE_Program = IntPtr.Zero;

		private IntPtr pFT_EEPROM_Read = IntPtr.Zero;

		private IntPtr pFT_EEPROM_Program = IntPtr.Zero;

		private IntPtr pFT_VendorCmdGet = IntPtr.Zero;

		private IntPtr pFT_VendorCmdSet = IntPtr.Zero;

		private IntPtr pFT_VendorCmdSetX = IntPtr.Zero;
		#endregion
		#region 相关委托

		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate FT_STATUS tFT_CreateDeviceInfoList(ref uint numdevs);


		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate FT_STATUS tFT_GetDeviceInfoDetail(uint index, ref uint flags, ref FT_DEVICE chiptype, ref uint id, ref uint locid, byte[] serialnumber, byte[] description, ref IntPtr ftHandle);


		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate FT_STATUS tFT_Open(uint index, ref IntPtr ftHandle);


		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate FT_STATUS tFT_OpenEx(string devstring, uint dwFlags, ref IntPtr ftHandle);


		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate FT_STATUS tFT_OpenExLoc(uint devloc, uint dwFlags, ref IntPtr ftHandle);


		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate FT_STATUS tFT_Close(IntPtr ftHandle);


		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate FT_STATUS tFT_Read(IntPtr ftHandle, byte[] lpBuffer, uint dwBytesToRead, ref uint lpdwBytesReturned);


		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate FT_STATUS tFT_Write(IntPtr ftHandle, byte[] lpBuffer, uint dwBytesToWrite, ref uint lpdwBytesWritten);


		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate FT_STATUS tFT_GetQueueStatus(IntPtr ftHandle, ref uint lpdwAmountInRxQueue);


		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate FT_STATUS tFT_GetModemStatus(IntPtr ftHandle, ref uint lpdwModemStatus);


		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate FT_STATUS tFT_GetStatus(IntPtr ftHandle, ref uint lpdwAmountInRxQueue, ref uint lpdwAmountInTxQueue, ref uint lpdwEventStatus);


		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate FT_STATUS tFT_SetBaudRate(IntPtr ftHandle, uint dwBaudRate);


		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate FT_STATUS tFT_SetDataCharacteristics(IntPtr ftHandle, byte uWordLength, byte uStopBits, byte uParity);


		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate FT_STATUS tFT_SetFlowControl(IntPtr ftHandle, ushort usFlowControl, byte uXon, byte uXoff);


		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate FT_STATUS tFT_SetDtr(IntPtr ftHandle);


		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate FT_STATUS tFT_ClrDtr(IntPtr ftHandle);


		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate FT_STATUS tFT_SetRts(IntPtr ftHandle);


		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate FT_STATUS tFT_ClrRts(IntPtr ftHandle);


		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate FT_STATUS tFT_ResetDevice(IntPtr ftHandle);


		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate FT_STATUS tFT_ResetPort(IntPtr ftHandle);


		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate FT_STATUS tFT_CyclePort(IntPtr ftHandle);

		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate FT_STATUS tFT_Rescan();

		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate FT_STATUS tFT_Reload(ushort wVID, ushort wPID);


		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate FT_STATUS tFT_Purge(IntPtr ftHandle, uint dwMask);


		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate FT_STATUS tFT_SetTimeouts(IntPtr ftHandle, uint dwReadTimeout, uint dwWriteTimeout);

		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate FT_STATUS tFT_SetBreakOn(IntPtr ftHandle);

		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate FT_STATUS tFT_SetBreakOff(IntPtr ftHandle);


		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate FT_STATUS tFT_GetDeviceInfo(IntPtr ftHandle, ref FT_DEVICE pftType, ref uint lpdwID, byte[] pcSerialNumber, byte[] pcDescription, IntPtr pvDummy);


		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate FT_STATUS tFT_SetResetPipeRetryCount(IntPtr ftHandle, uint dwCount);

		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate FT_STATUS tFT_StopInTask(IntPtr ftHandle);

		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate FT_STATUS tFT_RestartInTask(IntPtr ftHandle);


		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate FT_STATUS tFT_GetDriverVersion(IntPtr ftHandle, ref uint lpdwDriverVersion);


		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate FT_STATUS tFT_GetLibraryVersion(ref uint lpdwLibraryVersion);


		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate FT_STATUS tFT_SetDeadmanTimeout(IntPtr ftHandle, uint dwDeadmanTimeout);

		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate FT_STATUS tFT_SetChars(IntPtr ftHandle, byte uEventCh, byte uEventChEn, byte uErrorCh, byte uErrorChEn);

		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate FT_STATUS tFT_SetEventNotification(IntPtr ftHandle, uint dwEventMask, SafeHandle hEvent);

		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate FT_STATUS tFT_GetComPortNumber(IntPtr ftHandle, ref int dwComPortNumber);


		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate FT_STATUS tFT_SetLatencyTimer(IntPtr ftHandle, byte ucLatency);


		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate FT_STATUS tFT_GetLatencyTimer(IntPtr ftHandle, ref byte ucLatency);


		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate FT_STATUS tFT_SetBitMode(IntPtr ftHandle, byte ucMask, byte ucMode);

		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate FT_STATUS tFT_GetBitMode(IntPtr ftHandle, ref byte ucMode);


		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate FT_STATUS tFT_SetUSBParameters(IntPtr ftHandle, uint dwInTransferSize, uint dwOutTransferSize);


		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate FT_STATUS tFT_ReadEE(IntPtr ftHandle, uint dwWordOffset, ref ushort lpwValue);


		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate FT_STATUS tFT_WriteEE(IntPtr ftHandle, uint dwWordOffset, ushort wValue);


		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate FT_STATUS tFT_EraseEE(IntPtr ftHandle);


		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate FT_STATUS tFT_EE_UASize(IntPtr ftHandle, ref uint dwSize);


		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate FT_STATUS tFT_EE_UARead(IntPtr ftHandle, byte[] pucData, int dwDataLen, ref uint lpdwDataRead);


		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate FT_STATUS tFT_EE_UAWrite(IntPtr ftHandle, byte[] pucData, int dwDataLen);


		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate FT_STATUS tFT_EE_Read(IntPtr ftHandle, FT_PROGRAM_DATA pData);

		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate FT_STATUS tFT_EE_Program(IntPtr ftHandle, FT_PROGRAM_DATA pData);


		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate FT_STATUS tFT_EEPROM_Read(IntPtr ftHandle, IntPtr eepromData, uint eepromDataSize, byte[] manufacturer, byte[] manufacturerID, byte[] description, byte[] serialnumber);

		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate FT_STATUS tFT_EEPROM_Program(IntPtr ftHandle, IntPtr eepromData, uint eepromDataSize, byte[] manufacturer, byte[] manufacturerID, byte[] description, byte[] serialnumber);


		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate FT_STATUS tFT_VendorCmdGet(IntPtr ftHandle, ushort request, byte[] buf, ushort len);

		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate FT_STATUS tFT_VendorCmdSet(IntPtr ftHandle, ushort request, byte[] buf, ushort len);

		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate FT_STATUS tFT_VendorCmdSetX(IntPtr ftHandle, ushort request, byte[] buf, ushort len);
		#endregion
	

		ILibraryLoaderLogic libraryLoader;
		public FTDI()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                libraryLoader = new WindowsLibraryLoaderLogic();
				hFTD2XXDLL = libraryLoader.LoadLibrary("FTD2XX.DLL");
				//if (Environment.Is64BitProcess)
    //                hFTD2XXDLL = libraryLoader.LoadLibrary("amd64/ftd2xx64.dll");
    //            else
    //                hFTD2XXDLL = libraryLoader.LoadLibrary("i386/ftd2xx.dll");
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                libraryLoader = new UnixLibraryLoaderLogic();
                hFTD2XXDLL = libraryLoader.LoadLibrary("libftd2xx.so");
            }
            else
				throw new Exception("not support os system");
			if (this.hFTD2XXDLL != IntPtr.Zero)
				FindFunctionPointers();
			else
				Console.WriteLine("Failed to load FTD2XX.DLL.  Are the FTDI drivers installed?");
		}
        public FTDI(string path)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                libraryLoader = new WindowsLibraryLoaderLogic();
			else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
				libraryLoader = new UnixLibraryLoaderLogic();
			else
				throw new Exception("not support os system");
			hFTD2XXDLL = libraryLoader.LoadLibrary(path);
			if (this.hFTD2XXDLL != IntPtr.Zero)
				FindFunctionPointers();
			else
				Console.WriteLine("Failed to load FTD2XX.DLL.  Are the FTDI drivers installed?");
		}
        ~FTDI()
        {
			if (!libraryLoader.FreeLibrary(this.hFTD2XXDLL))
				Console.WriteLine("error dispose ftdi: free library return false");
			this.hFTD2XXDLL = IntPtr.Zero;
		}
        private void FindFunctionPointers()
		{
			this.pFT_CreateDeviceInfoList = libraryLoader.GetProcAddress(this.hFTD2XXDLL, "FT_CreateDeviceInfoList");
			this.pFT_GetDeviceInfoDetail = libraryLoader.GetProcAddress(this.hFTD2XXDLL, "FT_GetDeviceInfoDetail");
			this.pFT_Open = libraryLoader.GetProcAddress(this.hFTD2XXDLL, "FT_Open");
			this.pFT_OpenEx = libraryLoader.GetProcAddress(this.hFTD2XXDLL, "FT_OpenEx");
			this.pFT_Close = libraryLoader.GetProcAddress(this.hFTD2XXDLL, "FT_Close");
			this.pFT_Read = libraryLoader.GetProcAddress(this.hFTD2XXDLL, "FT_Read");
			this.pFT_Write = libraryLoader.GetProcAddress(this.hFTD2XXDLL, "FT_Write");
			this.pFT_GetQueueStatus = libraryLoader.GetProcAddress(this.hFTD2XXDLL, "FT_GetQueueStatus");
			this.pFT_GetModemStatus = libraryLoader.GetProcAddress(this.hFTD2XXDLL, "FT_GetModemStatus");
			this.pFT_GetStatus = libraryLoader.GetProcAddress(this.hFTD2XXDLL, "FT_GetStatus");
			this.pFT_SetBaudRate = libraryLoader.GetProcAddress(this.hFTD2XXDLL, "FT_SetBaudRate");
			this.pFT_SetDataCharacteristics = libraryLoader.GetProcAddress(this.hFTD2XXDLL, "FT_SetDataCharacteristics");
			this.pFT_SetFlowControl = libraryLoader.GetProcAddress(this.hFTD2XXDLL, "FT_SetFlowControl");
			this.pFT_SetDtr = libraryLoader.GetProcAddress(this.hFTD2XXDLL, "FT_SetDtr");
			this.pFT_ClrDtr = libraryLoader.GetProcAddress(this.hFTD2XXDLL, "FT_ClrDtr");
			this.pFT_SetRts = libraryLoader.GetProcAddress(this.hFTD2XXDLL, "FT_SetRts");
			this.pFT_ClrRts = libraryLoader.GetProcAddress(this.hFTD2XXDLL, "FT_ClrRts");
			this.pFT_ResetDevice = libraryLoader.GetProcAddress(this.hFTD2XXDLL, "FT_ResetDevice");
			this.pFT_ResetPort = libraryLoader.GetProcAddress(this.hFTD2XXDLL, "FT_ResetPort");
			this.pFT_CyclePort = libraryLoader.GetProcAddress(this.hFTD2XXDLL, "FT_CyclePort");
			this.pFT_Rescan = libraryLoader.GetProcAddress(this.hFTD2XXDLL, "FT_Rescan");
			this.pFT_Reload = libraryLoader.GetProcAddress(this.hFTD2XXDLL, "FT_Reload");
			this.pFT_Purge = libraryLoader.GetProcAddress(this.hFTD2XXDLL, "FT_Purge");
			this.pFT_SetTimeouts = libraryLoader.GetProcAddress(this.hFTD2XXDLL, "FT_SetTimeouts");
			this.pFT_SetBreakOn = libraryLoader.GetProcAddress(this.hFTD2XXDLL, "FT_SetBreakOn");
			this.pFT_SetBreakOff = libraryLoader.GetProcAddress(this.hFTD2XXDLL, "FT_SetBreakOff");
			this.pFT_GetDeviceInfo = libraryLoader.GetProcAddress(this.hFTD2XXDLL, "FT_GetDeviceInfo");
			this.pFT_SetResetPipeRetryCount = libraryLoader.GetProcAddress(this.hFTD2XXDLL, "FT_SetResetPipeRetryCount");
			this.pFT_StopInTask = libraryLoader.GetProcAddress(this.hFTD2XXDLL, "FT_StopInTask");
			this.pFT_RestartInTask = libraryLoader.GetProcAddress(this.hFTD2XXDLL, "FT_RestartInTask");
			this.pFT_GetDriverVersion = libraryLoader.GetProcAddress(this.hFTD2XXDLL, "FT_GetDriverVersion");
			this.pFT_GetLibraryVersion = libraryLoader.GetProcAddress(this.hFTD2XXDLL, "FT_GetLibraryVersion");
			this.pFT_SetDeadmanTimeout = libraryLoader.GetProcAddress(this.hFTD2XXDLL, "FT_SetDeadmanTimeout");
			this.pFT_SetChars = libraryLoader.GetProcAddress(this.hFTD2XXDLL, "FT_SetChars");
			this.pFT_SetEventNotification = libraryLoader.GetProcAddress(this.hFTD2XXDLL, "FT_SetEventNotification");
			this.pFT_GetComPortNumber = libraryLoader.GetProcAddress(this.hFTD2XXDLL, "FT_GetComPortNumber");
			this.pFT_SetLatencyTimer = libraryLoader.GetProcAddress(this.hFTD2XXDLL, "FT_SetLatencyTimer");
			this.pFT_GetLatencyTimer = libraryLoader.GetProcAddress(this.hFTD2XXDLL, "FT_GetLatencyTimer");
			this.pFT_SetBitMode = libraryLoader.GetProcAddress(this.hFTD2XXDLL, "FT_SetBitMode");
			this.pFT_GetBitMode = libraryLoader.GetProcAddress(this.hFTD2XXDLL, "FT_GetBitMode");
			this.pFT_SetUSBParameters = libraryLoader.GetProcAddress(this.hFTD2XXDLL, "FT_SetUSBParameters");
			this.pFT_ReadEE = libraryLoader.GetProcAddress(this.hFTD2XXDLL, "FT_ReadEE");
			this.pFT_WriteEE = libraryLoader.GetProcAddress(this.hFTD2XXDLL, "FT_WriteEE");
			this.pFT_EraseEE = libraryLoader.GetProcAddress(this.hFTD2XXDLL, "FT_EraseEE");
			this.pFT_EE_UASize = libraryLoader.GetProcAddress(this.hFTD2XXDLL, "FT_EE_UASize");
			this.pFT_EE_UARead = libraryLoader.GetProcAddress(this.hFTD2XXDLL, "FT_EE_UARead");
			this.pFT_EE_UAWrite = libraryLoader.GetProcAddress(this.hFTD2XXDLL, "FT_EE_UAWrite");
			this.pFT_EE_Read = libraryLoader.GetProcAddress(this.hFTD2XXDLL, "FT_EE_Read");
			this.pFT_EE_Program = libraryLoader.GetProcAddress(this.hFTD2XXDLL, "FT_EE_Program");
			this.pFT_EEPROM_Read = libraryLoader.GetProcAddress(this.hFTD2XXDLL, "FT_EEPROM_Read");
			this.pFT_EEPROM_Program = libraryLoader.GetProcAddress(this.hFTD2XXDLL, "FT_EEPROM_Program");
			this.pFT_VendorCmdGet = libraryLoader.GetProcAddress(this.hFTD2XXDLL, "FT_VendorCmdGet");
			this.pFT_VendorCmdSet = libraryLoader.GetProcAddress(this.hFTD2XXDLL, "FT_VendorCmdSet");
			this.pFT_VendorCmdSetX = libraryLoader.GetProcAddress(this.hFTD2XXDLL, "FT_VendorCmdSetX");
		}
		private void ErrorHandler(FT_STATUS ftStatus, FT_ERROR ftErrorCondition)
		{
			if (ftStatus != FT_STATUS.FT_OK)
			{
				switch (ftStatus)
				{
					case FT_STATUS.FT_INVALID_HANDLE:
						throw new Exception("Invalid handle for FTDI device.");
					case FT_STATUS.FT_DEVICE_NOT_FOUND:
						throw new Exception("FTDI device not found.");
					case FT_STATUS.FT_DEVICE_NOT_OPENED:
						throw new Exception("FTDI device not opened.");
					case FT_STATUS.FT_IO_ERROR:
						throw new Exception("FTDI device IO error.");
					case FT_STATUS.FT_INSUFFICIENT_RESOURCES:
						throw new Exception("Insufficient resources.");
					case FT_STATUS.FT_INVALID_PARAMETER:
						throw new Exception("Invalid parameter for FTD2XX function call.");
					case FT_STATUS.FT_INVALID_BAUD_RATE:
						throw new Exception("Invalid Baud rate for FTDI device.");
					case FT_STATUS.FT_DEVICE_NOT_OPENED_FOR_ERASE:
						throw new Exception("FTDI device not opened for erase.");
					case FT_STATUS.FT_DEVICE_NOT_OPENED_FOR_WRITE:
						throw new Exception("FTDI device not opened for write.");
					case FT_STATUS.FT_FAILED_TO_WRITE_DEVICE:
						throw new Exception("Failed to write to FTDI device.");
					case FT_STATUS.FT_EEPROM_READ_FAILED:
						throw new Exception("Failed to read FTDI device EEPROM.");
					case FT_STATUS.FT_EEPROM_WRITE_FAILED:
						throw new Exception("Failed to write FTDI device EEPROM.");
					case FT_STATUS.FT_EEPROM_ERASE_FAILED:
						throw new Exception("Failed to erase FTDI device EEPROM.");
					case FT_STATUS.FT_EEPROM_NOT_PRESENT:
						throw new Exception("No EEPROM fitted to FTDI device.");
					case FT_STATUS.FT_EEPROM_NOT_PROGRAMMED:
						throw new Exception("FTDI device EEPROM not programmed.");
					case FT_STATUS.FT_INVALID_ARGS:
						throw new Exception("Invalid arguments for FTD2XX function call.");
					case FT_STATUS.FT_OTHER_ERROR:
						throw new Exception("An unexpected error has occurred when trying to communicate with the FTDI device.");
				}
			}
			if (ftErrorCondition == FT_ERROR.FT_NO_ERROR)
			{
				return;
			}
			switch (ftErrorCondition)
			{
				case FT_ERROR.FT_INCORRECT_DEVICE:
					throw new Exception("The current device type does not match the EEPROM structure.");
				case FT_ERROR.FT_INVALID_BITMODE:
					throw new Exception("The requested bit mode is not valid for the current device.");
				case FT_ERROR.FT_BUFFER_SIZE:
					throw new Exception("The supplied buffer is not big enough.");
				default:
					return;
			}
		}

		public FT_STATUS Close()
		{
			FT_STATUS ft_STATUS = FT_STATUS.FT_OTHER_ERROR;
			if (this.hFTD2XXDLL == IntPtr.Zero)
			{
				return ft_STATUS;
			}
			if (this.pFT_Close != IntPtr.Zero)
			{
				FTDI.tFT_Close tFT_Close = (FTDI.tFT_Close)Marshal.GetDelegateForFunctionPointer(this.pFT_Close, typeof(FTDI.tFT_Close));
				ft_STATUS = tFT_Close(this.ftHandle);
				if (ft_STATUS == FT_STATUS.FT_OK)
				{
					this.ftHandle = IntPtr.Zero;
				}
			}
			else if (this.pFT_Close == IntPtr.Zero)
			{
				Console.WriteLine("Failed to load function FT_Close.");
			}
			return ft_STATUS;
		}


		public FT_STATUS CyclePort()
		{
			FT_STATUS ft_STATUS = FT_STATUS.FT_OTHER_ERROR;
			if (this.hFTD2XXDLL == IntPtr.Zero)
			{
				return ft_STATUS;
			}
			if (this.pFT_CyclePort != IntPtr.Zero & this.pFT_Close != IntPtr.Zero)
			{
				FTDI.tFT_CyclePort tFT_CyclePort = (FTDI.tFT_CyclePort)Marshal.GetDelegateForFunctionPointer(this.pFT_CyclePort, typeof(FTDI.tFT_CyclePort));
				FTDI.tFT_Close tFT_Close = (FTDI.tFT_Close)Marshal.GetDelegateForFunctionPointer(this.pFT_Close, typeof(FTDI.tFT_Close));
				if (this.ftHandle != IntPtr.Zero)
				{
					ft_STATUS = tFT_CyclePort(this.ftHandle);
					if (ft_STATUS == FT_STATUS.FT_OK)
					{
						ft_STATUS = tFT_Close(this.ftHandle);
						if (ft_STATUS == FT_STATUS.FT_OK)
						{
							this.ftHandle = IntPtr.Zero;
						}
					}
				}
			}
			else
			{
				if (this.pFT_CyclePort == IntPtr.Zero)
				{
					Console.WriteLine("Failed to load function FT_CyclePort.");
				}
				if (this.pFT_Close == IntPtr.Zero)
				{
					Console.WriteLine("Failed to load function FT_Close.");
				}
			}
			return ft_STATUS;
		}

		public FT_STATUS EEReadUserArea(byte[] UserAreaDataBuffer, ref uint numBytesRead)
		{
			FT_STATUS result = FT_STATUS.FT_OTHER_ERROR;
			if (this.hFTD2XXDLL == IntPtr.Zero)
			{
				return result;
			}
			if (this.pFT_EE_UASize != IntPtr.Zero & this.pFT_EE_UARead != IntPtr.Zero)
			{
				FTDI.tFT_EE_UASize tFT_EE_UASize = (FTDI.tFT_EE_UASize)Marshal.GetDelegateForFunctionPointer(this.pFT_EE_UASize, typeof(FTDI.tFT_EE_UASize));
				FTDI.tFT_EE_UARead tFT_EE_UARead = (FTDI.tFT_EE_UARead)Marshal.GetDelegateForFunctionPointer(this.pFT_EE_UARead, typeof(FTDI.tFT_EE_UARead));
				if (this.ftHandle != IntPtr.Zero)
				{
					uint num = 0U;
					result = tFT_EE_UASize(this.ftHandle, ref num);
					if ((long)UserAreaDataBuffer.Length >= (long)((ulong)num))
					{
						result = tFT_EE_UARead(this.ftHandle, UserAreaDataBuffer, UserAreaDataBuffer.Length, ref numBytesRead);
					}
				}
			}
			else
			{
				if (this.pFT_EE_UASize == IntPtr.Zero)
				{
					Console.WriteLine("Failed to load function FT_EE_UASize.");
				}
				if (this.pFT_EE_UARead == IntPtr.Zero)
				{
					Console.WriteLine("Failed to load function FT_EE_UARead.");
				}
			}
			return result;
		}

		public FT_STATUS EEUserAreaSize(ref uint UASize)
		{
			FT_STATUS result = FT_STATUS.FT_OTHER_ERROR;
			if (this.hFTD2XXDLL == IntPtr.Zero)
			{
				return result;
			}
			if (this.pFT_EE_UASize != IntPtr.Zero)
			{
				FTDI.tFT_EE_UASize tFT_EE_UASize = (FTDI.tFT_EE_UASize)Marshal.GetDelegateForFunctionPointer(this.pFT_EE_UASize, typeof(FTDI.tFT_EE_UASize));
				if (this.ftHandle != IntPtr.Zero)
				{
					result = tFT_EE_UASize(this.ftHandle, ref UASize);
				}
			}
			else if (this.pFT_EE_UASize == IntPtr.Zero)
			{
				Console.WriteLine("Failed to load function FT_EE_UASize.");
			}
			return result;
		}

		public FT_STATUS EEWriteUserArea(byte[] UserAreaDataBuffer)
		{
			FT_STATUS result = FT_STATUS.FT_OTHER_ERROR;
			if (this.hFTD2XXDLL == IntPtr.Zero)
			{
				return result;
			}
			if (this.pFT_EE_UASize != IntPtr.Zero & this.pFT_EE_UAWrite != IntPtr.Zero)
			{
				FTDI.tFT_EE_UASize tFT_EE_UASize = (FTDI.tFT_EE_UASize)Marshal.GetDelegateForFunctionPointer(this.pFT_EE_UASize, typeof(FTDI.tFT_EE_UASize));
				FTDI.tFT_EE_UAWrite tFT_EE_UAWrite = (FTDI.tFT_EE_UAWrite)Marshal.GetDelegateForFunctionPointer(this.pFT_EE_UAWrite, typeof(FTDI.tFT_EE_UAWrite));
				if (this.ftHandle != IntPtr.Zero)
				{
					uint num = 0U;
					result = tFT_EE_UASize(this.ftHandle, ref num);
					if ((long)UserAreaDataBuffer.Length <= (long)((ulong)num))
					{
						result = tFT_EE_UAWrite(this.ftHandle, UserAreaDataBuffer, UserAreaDataBuffer.Length);
					}
				}
			}
			else
			{
				if (this.pFT_EE_UASize == IntPtr.Zero)
				{
					Console.WriteLine("Failed to load function FT_EE_UASize.");
				}
				if (this.pFT_EE_UAWrite == IntPtr.Zero)
				{
					Console.WriteLine("Failed to load function FT_EE_UAWrite.");
				}
			}
			return result;
		}

		public FT_STATUS EraseEEPROM()
		{
			FT_STATUS ft_STATUS = FT_STATUS.FT_OTHER_ERROR;
			if (this.hFTD2XXDLL == IntPtr.Zero)
			{
				return ft_STATUS;
			}
			if (this.pFT_EraseEE != IntPtr.Zero)
			{
				FTDI.tFT_EraseEE tFT_EraseEE = (FTDI.tFT_EraseEE)Marshal.GetDelegateForFunctionPointer(this.pFT_EraseEE, typeof(FTDI.tFT_EraseEE));
				if (this.ftHandle != IntPtr.Zero)
				{
					FT_DEVICE ft_DEVICE = FT_DEVICE.FT_DEVICE_UNKNOWN;
					this.GetDeviceType(ref ft_DEVICE);
					if (ft_DEVICE == FT_DEVICE.FT_DEVICE_232R)
					{
						FT_ERROR ftErrorCondition = FT_ERROR.FT_INCORRECT_DEVICE;
						this.ErrorHandler(ft_STATUS, ftErrorCondition);
					}
					ft_STATUS = tFT_EraseEE(this.ftHandle);
				}
			}
			else if (this.pFT_EraseEE == IntPtr.Zero)
			{
				Console.WriteLine("Failed to load function FT_EraseEE.");
			}
			return ft_STATUS;
		}
		public FT_STATUS GetCOMPort(out string ComPortName)
		{
			FT_STATUS result = FT_STATUS.FT_OTHER_ERROR;
			ComPortName = string.Empty;
			if (this.hFTD2XXDLL == IntPtr.Zero)
			{
				return result;
			}
			if (this.pFT_GetComPortNumber != IntPtr.Zero)
			{
				FTDI.tFT_GetComPortNumber tFT_GetComPortNumber = (FTDI.tFT_GetComPortNumber)Marshal.GetDelegateForFunctionPointer(this.pFT_GetComPortNumber, typeof(FTDI.tFT_GetComPortNumber));
				int num = -1;
				if (this.ftHandle != IntPtr.Zero)
				{
					result = tFT_GetComPortNumber(this.ftHandle, ref num);
				}
				if (num == -1)
				{
					ComPortName = string.Empty;
				}
				else
				{
					ComPortName = "COM" + num.ToString();
				}
			}
			else if (this.pFT_GetComPortNumber == IntPtr.Zero)
			{
				Console.WriteLine("Failed to load function FT_GetComPortNumber.");
			}
			return result;
		}
		public FT_STATUS GetDescription(out string Description)
		{
			FT_STATUS result = FT_STATUS.FT_OTHER_ERROR;
			Description = string.Empty;
			if (this.hFTD2XXDLL == IntPtr.Zero)
			{
				return result;
			}
			if (this.pFT_GetDeviceInfo != IntPtr.Zero)
			{
				FTDI.tFT_GetDeviceInfo tFT_GetDeviceInfo = (FTDI.tFT_GetDeviceInfo)Marshal.GetDelegateForFunctionPointer(this.pFT_GetDeviceInfo, typeof(FTDI.tFT_GetDeviceInfo));
				uint num = 0U;
				FT_DEVICE ft_DEVICE = FT_DEVICE.FT_DEVICE_UNKNOWN;
				byte[] pcSerialNumber = new byte[16];
				byte[] array = new byte[64];
				if (this.ftHandle != IntPtr.Zero)
				{
					result = tFT_GetDeviceInfo(this.ftHandle, ref ft_DEVICE, ref num, pcSerialNumber, array, IntPtr.Zero);
					Description = Encoding.ASCII.GetString(array);
					Description = Description.Substring(0, Description.IndexOf('\0'));
				}
			}
			else if (this.pFT_GetDeviceInfo == IntPtr.Zero)
			{
				Console.WriteLine("Failed to load function FT_GetDeviceInfo.");
			}
			return result;
		}
		public FT_STATUS GetDeviceID(ref uint DeviceID)
		{
			FT_STATUS result = FT_STATUS.FT_OTHER_ERROR;
			if (this.hFTD2XXDLL == IntPtr.Zero)
			{
				return result;
			}
			if (this.pFT_GetDeviceInfo != IntPtr.Zero)
			{
				FTDI.tFT_GetDeviceInfo tFT_GetDeviceInfo = (FTDI.tFT_GetDeviceInfo)Marshal.GetDelegateForFunctionPointer(this.pFT_GetDeviceInfo, typeof(FTDI.tFT_GetDeviceInfo));
				FT_DEVICE ft_DEVICE = FT_DEVICE.FT_DEVICE_UNKNOWN;
				byte[] pcSerialNumber = new byte[16];
				byte[] pcDescription = new byte[64];
				if (this.ftHandle != IntPtr.Zero)
				{
					result = tFT_GetDeviceInfo(this.ftHandle, ref ft_DEVICE, ref DeviceID, pcSerialNumber, pcDescription, IntPtr.Zero);
				}
			}
			else if (this.pFT_GetDeviceInfo == IntPtr.Zero)
			{
				Console.WriteLine("Failed to load function FT_GetDeviceInfo.");
			}
			return result;
		}
		public FT_STATUS GetDeviceList(FT_DEVICE_INFO_NODE[] devicelist)
		{
			FT_STATUS ft_STATUS = FT_STATUS.FT_OTHER_ERROR;
			if (this.hFTD2XXDLL == IntPtr.Zero)
			{
				return ft_STATUS;
			}
			if (this.pFT_CreateDeviceInfoList != IntPtr.Zero & this.pFT_GetDeviceInfoDetail != IntPtr.Zero)
			{
				uint num = 0U;
				FTDI.tFT_CreateDeviceInfoList tFT_CreateDeviceInfoList = (FTDI.tFT_CreateDeviceInfoList)Marshal.GetDelegateForFunctionPointer(this.pFT_CreateDeviceInfoList, typeof(FTDI.tFT_CreateDeviceInfoList));
				FTDI.tFT_GetDeviceInfoDetail tFT_GetDeviceInfoDetail = (FTDI.tFT_GetDeviceInfoDetail)Marshal.GetDelegateForFunctionPointer(this.pFT_GetDeviceInfoDetail, typeof(FTDI.tFT_GetDeviceInfoDetail));
				ft_STATUS = tFT_CreateDeviceInfoList(ref num);
				byte[] array = new byte[16];
				byte[] array2 = new byte[64];
				if (num > 0U)
				{
					if ((long)devicelist.Length < (long)((ulong)num))
					{
						FT_ERROR ftErrorCondition = FT_ERROR.FT_BUFFER_SIZE;
						this.ErrorHandler(ft_STATUS, ftErrorCondition);
					}
					for (uint num2 = 0U; num2 < num; num2 += 1U)
					{
						devicelist[(int)((UIntPtr)num2)] = new FT_DEVICE_INFO_NODE();
						ft_STATUS = tFT_GetDeviceInfoDetail(num2, ref devicelist[(int)((UIntPtr)num2)].Flags, ref devicelist[(int)((UIntPtr)num2)].Type, ref devicelist[(int)((UIntPtr)num2)].ID, ref devicelist[(int)((UIntPtr)num2)].LocId, array, array2, ref devicelist[(int)((UIntPtr)num2)].ftHandle);
						devicelist[(int)((UIntPtr)num2)].SerialNumber = Encoding.ASCII.GetString(array);
						devicelist[(int)((UIntPtr)num2)].Description = Encoding.ASCII.GetString(array2);
						int num3 = devicelist[(int)((UIntPtr)num2)].SerialNumber.IndexOf('\0');
						if (num3 != -1)
						{
							devicelist[(int)((UIntPtr)num2)].SerialNumber = devicelist[(int)((UIntPtr)num2)].SerialNumber.Substring(0, num3);
						}
						num3 = devicelist[(int)((UIntPtr)num2)].Description.IndexOf('\0');
						if (num3 != -1)
						{
							devicelist[(int)((UIntPtr)num2)].Description = devicelist[(int)((UIntPtr)num2)].Description.Substring(0, num3);
						}
					}
				}
			}
			else
			{
				if (this.pFT_CreateDeviceInfoList == IntPtr.Zero)
				{
					Console.WriteLine("Failed to load function FT_CreateDeviceInfoList.");
				}
				if (this.pFT_GetDeviceInfoDetail == IntPtr.Zero)
				{
					Console.WriteLine("Failed to load function FT_GetDeviceInfoListDetail.");
				}
			}
			return ft_STATUS;
		}
		public FT_STATUS GetDeviceType(ref FT_DEVICE DeviceType)
		{
			FT_STATUS result = FT_STATUS.FT_OTHER_ERROR;
			if (this.hFTD2XXDLL == IntPtr.Zero)
			{
				return result;
			}
			if (this.pFT_GetDeviceInfo != IntPtr.Zero)
			{
				FTDI.tFT_GetDeviceInfo tFT_GetDeviceInfo = (FTDI.tFT_GetDeviceInfo)Marshal.GetDelegateForFunctionPointer(this.pFT_GetDeviceInfo, typeof(FTDI.tFT_GetDeviceInfo));
				uint num = 0U;
				byte[] pcSerialNumber = new byte[16];
				byte[] pcDescription = new byte[64];
				DeviceType = FT_DEVICE.FT_DEVICE_UNKNOWN;
				if (this.ftHandle != IntPtr.Zero)
				{
					result = tFT_GetDeviceInfo(this.ftHandle, ref DeviceType, ref num, pcSerialNumber, pcDescription, IntPtr.Zero);
				}
			}
			else if (this.pFT_GetDeviceInfo == IntPtr.Zero)
			{
				Console.WriteLine("Failed to load function FT_GetDeviceInfo.");
			}
			return result;
		}
		public FT_STATUS GetDriverVersion(ref uint DriverVersion)
		{
			FT_STATUS result = FT_STATUS.FT_OTHER_ERROR;
			if (this.hFTD2XXDLL == IntPtr.Zero)
			{
				return result;
			}
			if (this.pFT_GetDriverVersion != IntPtr.Zero)
			{
				FTDI.tFT_GetDriverVersion tFT_GetDriverVersion = (FTDI.tFT_GetDriverVersion)Marshal.GetDelegateForFunctionPointer(this.pFT_GetDriverVersion, typeof(FTDI.tFT_GetDriverVersion));
				if (this.ftHandle != IntPtr.Zero)
				{
					result = tFT_GetDriverVersion(this.ftHandle, ref DriverVersion);
				}
			}
			else if (this.pFT_GetDriverVersion == IntPtr.Zero)
			{
				Console.WriteLine("Failed to load function FT_GetDriverVersion.");
			}
			return result;
		}
		public FT_STATUS GetEventType(ref uint EventType)
		{
			FT_STATUS result = FT_STATUS.FT_OTHER_ERROR;
			if (this.hFTD2XXDLL == IntPtr.Zero)
			{
				return result;
			}
			if (this.pFT_GetStatus != IntPtr.Zero)
			{
				FTDI.tFT_GetStatus tFT_GetStatus = (FTDI.tFT_GetStatus)Marshal.GetDelegateForFunctionPointer(this.pFT_GetStatus, typeof(FTDI.tFT_GetStatus));
				uint num = 0U;
				uint num2 = 0U;
				if (this.ftHandle != IntPtr.Zero)
				{
					result = tFT_GetStatus(this.ftHandle, ref num, ref num2, ref EventType);
				}
			}
			else if (this.pFT_GetStatus == IntPtr.Zero)
			{
				Console.WriteLine("Failed to load function FT_GetStatus.");
			}
			return result;
		}
		public FT_STATUS GetLatency(ref byte Latency)
		{
			FT_STATUS result = FT_STATUS.FT_OTHER_ERROR;
			if (this.hFTD2XXDLL == IntPtr.Zero)
			{
				return result;
			}
			if (this.pFT_GetLatencyTimer != IntPtr.Zero)
			{
				FTDI.tFT_GetLatencyTimer tFT_GetLatencyTimer = (FTDI.tFT_GetLatencyTimer)Marshal.GetDelegateForFunctionPointer(this.pFT_GetLatencyTimer, typeof(FTDI.tFT_GetLatencyTimer));
				if (this.ftHandle != IntPtr.Zero)
				{
					result = tFT_GetLatencyTimer(this.ftHandle, ref Latency);
				}
			}
			else if (this.pFT_GetLatencyTimer == IntPtr.Zero)
			{
				Console.WriteLine("Failed to load function FT_GetLatencyTimer.");
			}
			return result;
		}
		public FT_STATUS GetLibraryVersion(ref uint LibraryVersion)
		{
			FT_STATUS result = FT_STATUS.FT_OTHER_ERROR;
			if (this.hFTD2XXDLL == IntPtr.Zero)
			{
				return result;
			}
			if (this.pFT_GetLibraryVersion != IntPtr.Zero)
			{
				FTDI.tFT_GetLibraryVersion tFT_GetLibraryVersion = (FTDI.tFT_GetLibraryVersion)Marshal.GetDelegateForFunctionPointer(this.pFT_GetLibraryVersion, typeof(FTDI.tFT_GetLibraryVersion));
				result = tFT_GetLibraryVersion(ref LibraryVersion);
			}
			else if (this.pFT_GetLibraryVersion == IntPtr.Zero)
			{
				Console.WriteLine("Failed to load function FT_GetLibraryVersion.");
			}
			return result;
		}
		public FT_STATUS GetLineStatus(ref byte LineStatus)
		{
			FT_STATUS result = FT_STATUS.FT_OTHER_ERROR;
			if (this.hFTD2XXDLL == IntPtr.Zero)
			{
				return result;
			}
			if (this.pFT_GetModemStatus != IntPtr.Zero)
			{
				FTDI.tFT_GetModemStatus tFT_GetModemStatus = (FTDI.tFT_GetModemStatus)Marshal.GetDelegateForFunctionPointer(this.pFT_GetModemStatus, typeof(FTDI.tFT_GetModemStatus));
				uint num = 0U;
				if (this.ftHandle != IntPtr.Zero)
				{
					result = tFT_GetModemStatus(this.ftHandle, ref num);
				}
				LineStatus = Convert.ToByte(num >> 8 & 255U);
			}
			else if (this.pFT_GetModemStatus == IntPtr.Zero)
			{
				Console.WriteLine("Failed to load function FT_GetModemStatus.");
			}
			return result;
		}
		public FT_STATUS GetModemStatus(ref byte ModemStatus)
		{
			FT_STATUS result = FT_STATUS.FT_OTHER_ERROR;
			if (this.hFTD2XXDLL == IntPtr.Zero)
			{
				return result;
			}
			if (this.pFT_GetModemStatus != IntPtr.Zero)
			{
				FTDI.tFT_GetModemStatus tFT_GetModemStatus = (FTDI.tFT_GetModemStatus)Marshal.GetDelegateForFunctionPointer(this.pFT_GetModemStatus, typeof(FTDI.tFT_GetModemStatus));
				uint num = 0U;
				if (this.ftHandle != IntPtr.Zero)
				{
					result = tFT_GetModemStatus(this.ftHandle, ref num);
				}
				ModemStatus = Convert.ToByte(num & 255U);
			}
			else if (this.pFT_GetModemStatus == IntPtr.Zero)
			{
				Console.WriteLine("Failed to load function FT_GetModemStatus.");
			}
			return result;
		}
		public FT_STATUS GetNumberOfDevices(ref uint devcount)
		{
			FT_STATUS result = FT_STATUS.FT_OTHER_ERROR;
			if (this.hFTD2XXDLL == IntPtr.Zero)
			{
				return result;
			}
			if (this.pFT_CreateDeviceInfoList != IntPtr.Zero)
			{
				FTDI.tFT_CreateDeviceInfoList tFT_CreateDeviceInfoList = (FTDI.tFT_CreateDeviceInfoList)Marshal.GetDelegateForFunctionPointer(this.pFT_CreateDeviceInfoList, typeof(FTDI.tFT_CreateDeviceInfoList));
				result = tFT_CreateDeviceInfoList(ref devcount);
			}
			else
			{
				Console.WriteLine("Failed to load function FT_CreateDeviceInfoList.");
			}
			return result;
		}
		public FT_STATUS GetPinStates(ref byte BitMode)
		{
			FT_STATUS result = FT_STATUS.FT_OTHER_ERROR;
			if (this.hFTD2XXDLL == IntPtr.Zero)
			{
				return result;
			}
			if (this.pFT_GetBitMode != IntPtr.Zero)
			{
				FTDI.tFT_GetBitMode tFT_GetBitMode = (FTDI.tFT_GetBitMode)Marshal.GetDelegateForFunctionPointer(this.pFT_GetBitMode, typeof(FTDI.tFT_GetBitMode));
				if (this.ftHandle != IntPtr.Zero)
				{
					result = tFT_GetBitMode(this.ftHandle, ref BitMode);
				}
			}
			else if (this.pFT_GetBitMode == IntPtr.Zero)
			{
				Console.WriteLine("Failed to load function FT_GetBitMode.");
			}
			return result;
		}
		public FT_STATUS GetRxBytesAvailable(ref uint RxQueue)
		{
			FT_STATUS result = FT_STATUS.FT_OTHER_ERROR;
			if (this.hFTD2XXDLL == IntPtr.Zero)
			{
				return result;
			}
			if (this.pFT_GetQueueStatus != IntPtr.Zero)
			{
				FTDI.tFT_GetQueueStatus tFT_GetQueueStatus = (FTDI.tFT_GetQueueStatus)Marshal.GetDelegateForFunctionPointer(this.pFT_GetQueueStatus, typeof(FTDI.tFT_GetQueueStatus));
				if (this.ftHandle != IntPtr.Zero)
				{
					result = tFT_GetQueueStatus(this.ftHandle, ref RxQueue);
				}
			}
			else if (this.pFT_GetQueueStatus == IntPtr.Zero)
			{
				Console.WriteLine("Failed to load function FT_GetQueueStatus.");
			}
			return result;
		}
		public FT_STATUS GetSerialNumber(out string SerialNumber)
		{
			FT_STATUS result = FT_STATUS.FT_OTHER_ERROR;
			SerialNumber = string.Empty;
			if (this.hFTD2XXDLL == IntPtr.Zero)
			{
				return result;
			}
			if (this.pFT_GetDeviceInfo != IntPtr.Zero)
			{
				FTDI.tFT_GetDeviceInfo tFT_GetDeviceInfo = (FTDI.tFT_GetDeviceInfo)Marshal.GetDelegateForFunctionPointer(this.pFT_GetDeviceInfo, typeof(FTDI.tFT_GetDeviceInfo));
				uint num = 0U;
				FT_DEVICE ft_DEVICE = FT_DEVICE.FT_DEVICE_UNKNOWN;
				byte[] array = new byte[16];
				byte[] pcDescription = new byte[64];
				if (this.ftHandle != IntPtr.Zero)
				{
					result = tFT_GetDeviceInfo(this.ftHandle, ref ft_DEVICE, ref num, array, pcDescription, IntPtr.Zero);
					SerialNumber = Encoding.ASCII.GetString(array);
					SerialNumber = SerialNumber.Substring(0, SerialNumber.IndexOf('\0'));
				}
			}
			else if (this.pFT_GetDeviceInfo == IntPtr.Zero)
			{
				Console.WriteLine("Failed to load function FT_GetDeviceInfo.");
			}
			return result;
		}
		public FT_STATUS GetTxBytesWaiting(ref uint TxQueue)
		{
			FT_STATUS result = FT_STATUS.FT_OTHER_ERROR;
			if (this.hFTD2XXDLL == IntPtr.Zero)
			{
				return result;
			}
			if (this.pFT_GetStatus != IntPtr.Zero)
			{
				FTDI.tFT_GetStatus tFT_GetStatus = (FTDI.tFT_GetStatus)Marshal.GetDelegateForFunctionPointer(this.pFT_GetStatus, typeof(FTDI.tFT_GetStatus));
				uint num = 0U;
				uint num2 = 0U;
				if (this.ftHandle != IntPtr.Zero)
				{
					result = tFT_GetStatus(this.ftHandle, ref num, ref TxQueue, ref num2);
				}
			}
			else if (this.pFT_GetStatus == IntPtr.Zero)
			{
				Console.WriteLine("Failed to load function FT_GetStatus.");
			}
			return result;
		}
		public FT_STATUS InTransferSize(uint InTransferSize)
		{
			FT_STATUS result = FT_STATUS.FT_OTHER_ERROR;
			if (this.hFTD2XXDLL == IntPtr.Zero)
			{
				return result;
			}
			if (this.pFT_SetUSBParameters != IntPtr.Zero)
			{
				FTDI.tFT_SetUSBParameters tFT_SetUSBParameters = (FTDI.tFT_SetUSBParameters)Marshal.GetDelegateForFunctionPointer(this.pFT_SetUSBParameters, typeof(FTDI.tFT_SetUSBParameters));
				if (this.ftHandle != IntPtr.Zero)
				{
					result = tFT_SetUSBParameters(this.ftHandle, InTransferSize, InTransferSize);
				}
			}
			else if (this.pFT_SetUSBParameters == IntPtr.Zero)
			{
				Console.WriteLine("Failed to load function FT_SetUSBParameters.");
			}
			return result;
		}
		public FT_STATUS OpenByDescription(string description)
		{
			FT_STATUS ft_STATUS = FT_STATUS.FT_OTHER_ERROR;
			if (this.hFTD2XXDLL == IntPtr.Zero)
			{
				return ft_STATUS;
			}
			if (this.pFT_OpenEx != IntPtr.Zero & this.pFT_SetDataCharacteristics != IntPtr.Zero & this.pFT_SetFlowControl != IntPtr.Zero & this.pFT_SetBaudRate != IntPtr.Zero)
			{
				FTDI.tFT_OpenEx tFT_OpenEx = (FTDI.tFT_OpenEx)Marshal.GetDelegateForFunctionPointer(this.pFT_OpenEx, typeof(FTDI.tFT_OpenEx));
				FTDI.tFT_SetDataCharacteristics tFT_SetDataCharacteristics = (FTDI.tFT_SetDataCharacteristics)Marshal.GetDelegateForFunctionPointer(this.pFT_SetDataCharacteristics, typeof(FTDI.tFT_SetDataCharacteristics));
				FTDI.tFT_SetFlowControl tFT_SetFlowControl = (FTDI.tFT_SetFlowControl)Marshal.GetDelegateForFunctionPointer(this.pFT_SetFlowControl, typeof(FTDI.tFT_SetFlowControl));
				FTDI.tFT_SetBaudRate tFT_SetBaudRate = (FTDI.tFT_SetBaudRate)Marshal.GetDelegateForFunctionPointer(this.pFT_SetBaudRate, typeof(FTDI.tFT_SetBaudRate));
				ft_STATUS = tFT_OpenEx(description, 2U, ref this.ftHandle);
				if (ft_STATUS != FT_STATUS.FT_OK)
				{
					this.ftHandle = IntPtr.Zero;
				}
				if (this.ftHandle != IntPtr.Zero)
				{
					byte uWordLength = 8;
					byte uStopBits = 0;
					byte uParity = 0;
					ft_STATUS = tFT_SetDataCharacteristics(this.ftHandle, uWordLength, uStopBits, uParity);
					ushort usFlowControl = 0;
					byte uXon = 17;
					byte uXoff = 19;
					ft_STATUS = tFT_SetFlowControl(this.ftHandle, usFlowControl, uXon, uXoff);
					uint dwBaudRate = 9600U;
					ft_STATUS = tFT_SetBaudRate(this.ftHandle, dwBaudRate);
				}
			}
			else
			{
				if (this.pFT_OpenEx == IntPtr.Zero)
				{
					Console.WriteLine("Failed to load function FT_OpenEx.");
				}
				if (this.pFT_SetDataCharacteristics == IntPtr.Zero)
				{
					Console.WriteLine("Failed to load function FT_SetDataCharacteristics.");
				}
				if (this.pFT_SetFlowControl == IntPtr.Zero)
				{
					Console.WriteLine("Failed to load function FT_SetFlowControl.");
				}
				if (this.pFT_SetBaudRate == IntPtr.Zero)
				{
					Console.WriteLine("Failed to load function FT_SetBaudRate.");
				}
			}
			return ft_STATUS;
		}
		public FT_STATUS OpenByIndex(uint index)
		{
			FT_STATUS ft_STATUS = FT_STATUS.FT_OTHER_ERROR;
			if (this.hFTD2XXDLL == IntPtr.Zero)
			{
				return ft_STATUS;
			}
			if (this.pFT_Open != IntPtr.Zero & this.pFT_SetDataCharacteristics != IntPtr.Zero & this.pFT_SetFlowControl != IntPtr.Zero & this.pFT_SetBaudRate != IntPtr.Zero)
			{
				FTDI.tFT_Open tFT_Open = (FTDI.tFT_Open)Marshal.GetDelegateForFunctionPointer(this.pFT_Open, typeof(FTDI.tFT_Open));
				FTDI.tFT_SetDataCharacteristics tFT_SetDataCharacteristics = (FTDI.tFT_SetDataCharacteristics)Marshal.GetDelegateForFunctionPointer(this.pFT_SetDataCharacteristics, typeof(FTDI.tFT_SetDataCharacteristics));
				FTDI.tFT_SetFlowControl tFT_SetFlowControl = (FTDI.tFT_SetFlowControl)Marshal.GetDelegateForFunctionPointer(this.pFT_SetFlowControl, typeof(FTDI.tFT_SetFlowControl));
				FTDI.tFT_SetBaudRate tFT_SetBaudRate = (FTDI.tFT_SetBaudRate)Marshal.GetDelegateForFunctionPointer(this.pFT_SetBaudRate, typeof(FTDI.tFT_SetBaudRate));
				ft_STATUS = tFT_Open(index, ref this.ftHandle);
				if (ft_STATUS != FT_STATUS.FT_OK)
				{
					this.ftHandle = IntPtr.Zero;
				}
				if (this.ftHandle != IntPtr.Zero)
				{
					byte uWordLength = 8;
					byte uStopBits = 0;
					byte uParity = 0;
					ft_STATUS = tFT_SetDataCharacteristics(this.ftHandle, uWordLength, uStopBits, uParity);
					ushort usFlowControl = 0;
					byte uXon = 17;
					byte uXoff = 19;
					ft_STATUS = tFT_SetFlowControl(this.ftHandle, usFlowControl, uXon, uXoff);
					uint dwBaudRate = 9600U;
					ft_STATUS = tFT_SetBaudRate(this.ftHandle, dwBaudRate);
				}
			}
			else
			{
				if (this.pFT_Open == IntPtr.Zero)
				{
					Console.WriteLine("Failed to load function FT_Open.");
				}
				if (this.pFT_SetDataCharacteristics == IntPtr.Zero)
				{
					Console.WriteLine("Failed to load function FT_SetDataCharacteristics.");
				}
				if (this.pFT_SetFlowControl == IntPtr.Zero)
				{
					Console.WriteLine("Failed to load function FT_SetFlowControl.");
				}
				if (this.pFT_SetBaudRate == IntPtr.Zero)
				{
					Console.WriteLine("Failed to load function FT_SetBaudRate.");
				}
			}
			return ft_STATUS;
		}

		public FT_STATUS OpenByLocation(uint location)
		{
			FT_STATUS ft_STATUS = FT_STATUS.FT_OTHER_ERROR;
			if (this.hFTD2XXDLL == IntPtr.Zero)
			{
				return ft_STATUS;
			}
			if (this.pFT_OpenEx != IntPtr.Zero & this.pFT_SetDataCharacteristics != IntPtr.Zero & this.pFT_SetFlowControl != IntPtr.Zero & this.pFT_SetBaudRate != IntPtr.Zero)
			{
				FTDI.tFT_OpenExLoc tFT_OpenExLoc = (FTDI.tFT_OpenExLoc)Marshal.GetDelegateForFunctionPointer(this.pFT_OpenEx, typeof(FTDI.tFT_OpenExLoc));
				FTDI.tFT_SetDataCharacteristics tFT_SetDataCharacteristics = (FTDI.tFT_SetDataCharacteristics)Marshal.GetDelegateForFunctionPointer(this.pFT_SetDataCharacteristics, typeof(FTDI.tFT_SetDataCharacteristics));
				FTDI.tFT_SetFlowControl tFT_SetFlowControl = (FTDI.tFT_SetFlowControl)Marshal.GetDelegateForFunctionPointer(this.pFT_SetFlowControl, typeof(FTDI.tFT_SetFlowControl));
				FTDI.tFT_SetBaudRate tFT_SetBaudRate = (FTDI.tFT_SetBaudRate)Marshal.GetDelegateForFunctionPointer(this.pFT_SetBaudRate, typeof(FTDI.tFT_SetBaudRate));
				ft_STATUS = tFT_OpenExLoc(location, 4U, ref this.ftHandle);
				if (ft_STATUS != FT_STATUS.FT_OK)
				{
					this.ftHandle = IntPtr.Zero;
				}
				if (this.ftHandle != IntPtr.Zero)
				{
					byte uWordLength = 8;
					byte uStopBits = 0;
					byte uParity = 0;
					tFT_SetDataCharacteristics(this.ftHandle, uWordLength, uStopBits, uParity);
					ushort usFlowControl = 0;
					byte uXon = 17;
					byte uXoff = 19;
					tFT_SetFlowControl(this.ftHandle, usFlowControl, uXon, uXoff);
					uint dwBaudRate = 9600U;
					tFT_SetBaudRate(this.ftHandle, dwBaudRate);
				}
			}
			else
			{
				if (this.pFT_OpenEx == IntPtr.Zero)
				{
					Console.WriteLine("Failed to load function FT_OpenEx.");
				}
				if (this.pFT_SetDataCharacteristics == IntPtr.Zero)
				{
					Console.WriteLine("Failed to load function FT_SetDataCharacteristics.");
				}
				if (this.pFT_SetFlowControl == IntPtr.Zero)
				{
					Console.WriteLine("Failed to load function FT_SetFlowControl.");
				}
				if (this.pFT_SetBaudRate == IntPtr.Zero)
				{
					Console.WriteLine("Failed to load function FT_SetBaudRate.");
				}
			}
			return ft_STATUS;
		}

		public FT_STATUS OpenBySerialNumber(string serialnumber)
		{
			FT_STATUS ft_STATUS = FT_STATUS.FT_OTHER_ERROR;
			if (this.hFTD2XXDLL == IntPtr.Zero)
			{
				return ft_STATUS;
			}
			if (this.pFT_OpenEx != IntPtr.Zero & this.pFT_SetDataCharacteristics != IntPtr.Zero & this.pFT_SetFlowControl != IntPtr.Zero & this.pFT_SetBaudRate != IntPtr.Zero)
			{
				FTDI.tFT_OpenEx tFT_OpenEx = (FTDI.tFT_OpenEx)Marshal.GetDelegateForFunctionPointer(this.pFT_OpenEx, typeof(FTDI.tFT_OpenEx));
				FTDI.tFT_SetDataCharacteristics tFT_SetDataCharacteristics = (FTDI.tFT_SetDataCharacteristics)Marshal.GetDelegateForFunctionPointer(this.pFT_SetDataCharacteristics, typeof(FTDI.tFT_SetDataCharacteristics));
				FTDI.tFT_SetFlowControl tFT_SetFlowControl = (FTDI.tFT_SetFlowControl)Marshal.GetDelegateForFunctionPointer(this.pFT_SetFlowControl, typeof(FTDI.tFT_SetFlowControl));
				FTDI.tFT_SetBaudRate tFT_SetBaudRate = (FTDI.tFT_SetBaudRate)Marshal.GetDelegateForFunctionPointer(this.pFT_SetBaudRate, typeof(FTDI.tFT_SetBaudRate));
				ft_STATUS = tFT_OpenEx(serialnumber, 1U, ref this.ftHandle);
				if (ft_STATUS != FT_STATUS.FT_OK)
				{
					this.ftHandle = IntPtr.Zero;
				}
				if (this.ftHandle != IntPtr.Zero)
				{
					byte uWordLength = 8;
					byte uStopBits = 0;
					byte uParity = 0;
					ft_STATUS = tFT_SetDataCharacteristics(this.ftHandle, uWordLength, uStopBits, uParity);
					ushort usFlowControl = 0;
					byte uXon = 17;
					byte uXoff = 19;
					ft_STATUS = tFT_SetFlowControl(this.ftHandle, usFlowControl, uXon, uXoff);
					uint dwBaudRate = 9600U;
					ft_STATUS = tFT_SetBaudRate(this.ftHandle, dwBaudRate);
				}
			}
			else
			{
				if (this.pFT_OpenEx == IntPtr.Zero)
				{
					Console.WriteLine("Failed to load function FT_OpenEx.");
				}
				if (this.pFT_SetDataCharacteristics == IntPtr.Zero)
				{
					Console.WriteLine("Failed to load function FT_SetDataCharacteristics.");
				}
				if (this.pFT_SetFlowControl == IntPtr.Zero)
				{
					Console.WriteLine("Failed to load function FT_SetFlowControl.");
				}
				if (this.pFT_SetBaudRate == IntPtr.Zero)
				{
					Console.WriteLine("Failed to load function FT_SetBaudRate.");
				}
			}
			return ft_STATUS;
		}
		public FT_STATUS Purge(uint purgemask)
		{
			FT_STATUS result = FT_STATUS.FT_OTHER_ERROR;
			if (this.hFTD2XXDLL == IntPtr.Zero)
			{
				return result;
			}
			if (this.pFT_Purge != IntPtr.Zero)
			{
				FTDI.tFT_Purge tFT_Purge = (FTDI.tFT_Purge)Marshal.GetDelegateForFunctionPointer(this.pFT_Purge, typeof(FTDI.tFT_Purge));
				if (this.ftHandle != IntPtr.Zero)
				{
					result = tFT_Purge(this.ftHandle, purgemask);
				}
			}
			else if (this.pFT_Purge == IntPtr.Zero)
			{
				Console.WriteLine("Failed to load function FT_Purge.");
			}
			return result;
		}
		public FT_STATUS Read(byte[] dataBuffer, uint numBytesToRead, ref uint numBytesRead)
		{
			FT_STATUS result = FT_STATUS.FT_OTHER_ERROR;
			if (this.hFTD2XXDLL == IntPtr.Zero)
			{
				return result;
			}
			if (this.pFT_Read != IntPtr.Zero)
			{
				FTDI.tFT_Read tFT_Read = (FTDI.tFT_Read)Marshal.GetDelegateForFunctionPointer(this.pFT_Read, typeof(FTDI.tFT_Read));
				if ((long)dataBuffer.Length < (long)((ulong)numBytesToRead))
				{
					numBytesToRead = (uint)dataBuffer.Length;
				}
				if (this.ftHandle != IntPtr.Zero)
				{
					result = tFT_Read(this.ftHandle, dataBuffer, numBytesToRead, ref numBytesRead);
				}
			}
			else if (this.pFT_Read == IntPtr.Zero)
			{
				Console.WriteLine("Failed to load function FT_Read.");
			}
			return result;
		}
		public FT_STATUS Read(out string dataBuffer, uint numBytesToRead, ref uint numBytesRead)
		{
			FT_STATUS result = FT_STATUS.FT_OTHER_ERROR;
			dataBuffer = string.Empty;
			if (this.hFTD2XXDLL == IntPtr.Zero)
			{
				return result;
			}
			if (this.pFT_Read != IntPtr.Zero)
			{
				FTDI.tFT_Read tFT_Read = (FTDI.tFT_Read)Marshal.GetDelegateForFunctionPointer(this.pFT_Read, typeof(FTDI.tFT_Read));
				byte[] array = new byte[numBytesToRead];
				if (this.ftHandle != IntPtr.Zero)
				{
					result = tFT_Read(this.ftHandle, array, numBytesToRead, ref numBytesRead);
					dataBuffer = Encoding.ASCII.GetString(array);
					dataBuffer = dataBuffer.Substring(0, (int)numBytesRead);
				}
			}
			else if (this.pFT_Read == IntPtr.Zero)
			{
				Console.WriteLine("Failed to load function FT_Read.");
			}
			return result;
		}
		public FT_STATUS ReadEEPROMLocation(uint Address, ref ushort EEValue)
		{
			FT_STATUS result = FT_STATUS.FT_OTHER_ERROR;
			if (this.hFTD2XXDLL == IntPtr.Zero)
			{
				return result;
			}
			if (this.pFT_ReadEE != IntPtr.Zero)
			{
				FTDI.tFT_ReadEE tFT_ReadEE = (FTDI.tFT_ReadEE)Marshal.GetDelegateForFunctionPointer(this.pFT_ReadEE, typeof(FTDI.tFT_ReadEE));
				if (this.ftHandle != IntPtr.Zero)
				{
					result = tFT_ReadEE(this.ftHandle, Address, ref EEValue);
				}
			}
			else if (this.pFT_ReadEE == IntPtr.Zero)
			{
				Console.WriteLine("Failed to load function FT_ReadEE.");
			}
			return result;
		}
		public FT_STATUS ReadFT2232EEPROM(FT2232_EEPROM_STRUCTURE ee2232)
		{
			FT_STATUS ft_STATUS = FT_STATUS.FT_OTHER_ERROR;
			if (this.hFTD2XXDLL == IntPtr.Zero)
			{
				return ft_STATUS;
			}
			if (this.pFT_EE_Read != IntPtr.Zero)
			{
				FTDI.tFT_EE_Read tFT_EE_Read = (FTDI.tFT_EE_Read)Marshal.GetDelegateForFunctionPointer(this.pFT_EE_Read, typeof(FTDI.tFT_EE_Read));
				if (this.ftHandle != IntPtr.Zero)
				{
					FT_DEVICE ft_DEVICE = FT_DEVICE.FT_DEVICE_UNKNOWN;
					this.GetDeviceType(ref ft_DEVICE);
					if (ft_DEVICE != FT_DEVICE.FT_DEVICE_2232)
					{
						FT_ERROR ftErrorCondition = FT_ERROR.FT_INCORRECT_DEVICE;
						this.ErrorHandler(ft_STATUS, ftErrorCondition);
					}
					FT_PROGRAM_DATA ft_PROGRAM_DATA = new FT_PROGRAM_DATA();
					ft_PROGRAM_DATA.Signature1 = 0U;
					ft_PROGRAM_DATA.Signature2 = uint.MaxValue;
					ft_PROGRAM_DATA.Version = 2U;
					ft_PROGRAM_DATA.Manufacturer = Marshal.AllocHGlobal(32);
					ft_PROGRAM_DATA.ManufacturerID = Marshal.AllocHGlobal(16);
					ft_PROGRAM_DATA.Description = Marshal.AllocHGlobal(64);
					ft_PROGRAM_DATA.SerialNumber = Marshal.AllocHGlobal(16);
					ft_STATUS = tFT_EE_Read(this.ftHandle, ft_PROGRAM_DATA);
					ee2232.Manufacturer = Marshal.PtrToStringAnsi(ft_PROGRAM_DATA.Manufacturer);
					ee2232.ManufacturerID = Marshal.PtrToStringAnsi(ft_PROGRAM_DATA.ManufacturerID);
					ee2232.Description = Marshal.PtrToStringAnsi(ft_PROGRAM_DATA.Description);
					ee2232.SerialNumber = Marshal.PtrToStringAnsi(ft_PROGRAM_DATA.SerialNumber);
					Marshal.FreeHGlobal(ft_PROGRAM_DATA.Manufacturer);
					Marshal.FreeHGlobal(ft_PROGRAM_DATA.ManufacturerID);
					Marshal.FreeHGlobal(ft_PROGRAM_DATA.Description);
					Marshal.FreeHGlobal(ft_PROGRAM_DATA.SerialNumber);
					ee2232.VendorID = ft_PROGRAM_DATA.VendorID;
					ee2232.ProductID = ft_PROGRAM_DATA.ProductID;
					ee2232.MaxPower = ft_PROGRAM_DATA.MaxPower;
					ee2232.SelfPowered = Convert.ToBoolean(ft_PROGRAM_DATA.SelfPowered);
					ee2232.RemoteWakeup = Convert.ToBoolean(ft_PROGRAM_DATA.RemoteWakeup);
					ee2232.PullDownEnable = Convert.ToBoolean(ft_PROGRAM_DATA.PullDownEnable5);
					ee2232.SerNumEnable = Convert.ToBoolean(ft_PROGRAM_DATA.SerNumEnable5);
					ee2232.USBVersionEnable = Convert.ToBoolean(ft_PROGRAM_DATA.USBVersionEnable5);
					ee2232.USBVersion = ft_PROGRAM_DATA.USBVersion5;
					ee2232.AIsHighCurrent = Convert.ToBoolean(ft_PROGRAM_DATA.AIsHighCurrent);
					ee2232.BIsHighCurrent = Convert.ToBoolean(ft_PROGRAM_DATA.BIsHighCurrent);
					ee2232.IFAIsFifo = Convert.ToBoolean(ft_PROGRAM_DATA.IFAIsFifo);
					ee2232.IFAIsFifoTar = Convert.ToBoolean(ft_PROGRAM_DATA.IFAIsFifoTar);
					ee2232.IFAIsFastSer = Convert.ToBoolean(ft_PROGRAM_DATA.IFAIsFastSer);
					ee2232.AIsVCP = Convert.ToBoolean(ft_PROGRAM_DATA.AIsVCP);
					ee2232.IFBIsFifo = Convert.ToBoolean(ft_PROGRAM_DATA.IFBIsFifo);
					ee2232.IFBIsFifoTar = Convert.ToBoolean(ft_PROGRAM_DATA.IFBIsFifoTar);
					ee2232.IFBIsFastSer = Convert.ToBoolean(ft_PROGRAM_DATA.IFBIsFastSer);
					ee2232.BIsVCP = Convert.ToBoolean(ft_PROGRAM_DATA.BIsVCP);
				}
			}
			else if (this.pFT_EE_Read == IntPtr.Zero)
			{
				Console.WriteLine("Failed to load function FT_EE_Read.");
			}
			return ft_STATUS;
		}
		public FT_STATUS ReadFT2232HEEPROM(FT2232H_EEPROM_STRUCTURE ee2232h)
		{
			FT_STATUS ft_STATUS = FT_STATUS.FT_OTHER_ERROR;
			if (this.hFTD2XXDLL == IntPtr.Zero)
			{
				return ft_STATUS;
			}
			if (this.pFT_EE_Read != IntPtr.Zero)
			{
				FTDI.tFT_EE_Read tFT_EE_Read = (FTDI.tFT_EE_Read)Marshal.GetDelegateForFunctionPointer(this.pFT_EE_Read, typeof(FTDI.tFT_EE_Read));
				if (this.ftHandle != IntPtr.Zero)
				{
					FT_DEVICE ft_DEVICE = FT_DEVICE.FT_DEVICE_UNKNOWN;
					this.GetDeviceType(ref ft_DEVICE);
					if (ft_DEVICE != FT_DEVICE.FT_DEVICE_2232H)
					{
						FT_ERROR ftErrorCondition = FT_ERROR.FT_INCORRECT_DEVICE;
						this.ErrorHandler(ft_STATUS, ftErrorCondition);
					}
					FT_PROGRAM_DATA ft_PROGRAM_DATA = new FT_PROGRAM_DATA();
					ft_PROGRAM_DATA.Signature1 = 0U;
					ft_PROGRAM_DATA.Signature2 = uint.MaxValue;
					ft_PROGRAM_DATA.Version = 3U;
					ft_PROGRAM_DATA.Manufacturer = Marshal.AllocHGlobal(32);
					ft_PROGRAM_DATA.ManufacturerID = Marshal.AllocHGlobal(16);
					ft_PROGRAM_DATA.Description = Marshal.AllocHGlobal(64);
					ft_PROGRAM_DATA.SerialNumber = Marshal.AllocHGlobal(16);
					ft_STATUS = tFT_EE_Read(this.ftHandle, ft_PROGRAM_DATA);
					ee2232h.Manufacturer = Marshal.PtrToStringAnsi(ft_PROGRAM_DATA.Manufacturer);
					ee2232h.ManufacturerID = Marshal.PtrToStringAnsi(ft_PROGRAM_DATA.ManufacturerID);
					ee2232h.Description = Marshal.PtrToStringAnsi(ft_PROGRAM_DATA.Description);
					ee2232h.SerialNumber = Marshal.PtrToStringAnsi(ft_PROGRAM_DATA.SerialNumber);
					Marshal.FreeHGlobal(ft_PROGRAM_DATA.Manufacturer);
					Marshal.FreeHGlobal(ft_PROGRAM_DATA.ManufacturerID);
					Marshal.FreeHGlobal(ft_PROGRAM_DATA.Description);
					Marshal.FreeHGlobal(ft_PROGRAM_DATA.SerialNumber);
					ee2232h.VendorID = ft_PROGRAM_DATA.VendorID;
					ee2232h.ProductID = ft_PROGRAM_DATA.ProductID;
					ee2232h.MaxPower = ft_PROGRAM_DATA.MaxPower;
					ee2232h.SelfPowered = Convert.ToBoolean(ft_PROGRAM_DATA.SelfPowered);
					ee2232h.RemoteWakeup = Convert.ToBoolean(ft_PROGRAM_DATA.RemoteWakeup);
					ee2232h.PullDownEnable = Convert.ToBoolean(ft_PROGRAM_DATA.PullDownEnable7);
					ee2232h.SerNumEnable = Convert.ToBoolean(ft_PROGRAM_DATA.SerNumEnable7);
					ee2232h.ALSlowSlew = Convert.ToBoolean(ft_PROGRAM_DATA.ALSlowSlew);
					ee2232h.ALSchmittInput = Convert.ToBoolean(ft_PROGRAM_DATA.ALSchmittInput);
					ee2232h.ALDriveCurrent = ft_PROGRAM_DATA.ALDriveCurrent;
					ee2232h.AHSlowSlew = Convert.ToBoolean(ft_PROGRAM_DATA.AHSlowSlew);
					ee2232h.AHSchmittInput = Convert.ToBoolean(ft_PROGRAM_DATA.AHSchmittInput);
					ee2232h.AHDriveCurrent = ft_PROGRAM_DATA.AHDriveCurrent;
					ee2232h.BLSlowSlew = Convert.ToBoolean(ft_PROGRAM_DATA.BLSlowSlew);
					ee2232h.BLSchmittInput = Convert.ToBoolean(ft_PROGRAM_DATA.BLSchmittInput);
					ee2232h.BLDriveCurrent = ft_PROGRAM_DATA.BLDriveCurrent;
					ee2232h.BHSlowSlew = Convert.ToBoolean(ft_PROGRAM_DATA.BHSlowSlew);
					ee2232h.BHSchmittInput = Convert.ToBoolean(ft_PROGRAM_DATA.BHSchmittInput);
					ee2232h.BHDriveCurrent = ft_PROGRAM_DATA.BHDriveCurrent;
					ee2232h.IFAIsFifo = Convert.ToBoolean(ft_PROGRAM_DATA.IFAIsFifo7);
					ee2232h.IFAIsFifoTar = Convert.ToBoolean(ft_PROGRAM_DATA.IFAIsFifoTar7);
					ee2232h.IFAIsFastSer = Convert.ToBoolean(ft_PROGRAM_DATA.IFAIsFastSer7);
					ee2232h.AIsVCP = Convert.ToBoolean(ft_PROGRAM_DATA.AIsVCP7);
					ee2232h.IFBIsFifo = Convert.ToBoolean(ft_PROGRAM_DATA.IFBIsFifo7);
					ee2232h.IFBIsFifoTar = Convert.ToBoolean(ft_PROGRAM_DATA.IFBIsFifoTar7);
					ee2232h.IFBIsFastSer = Convert.ToBoolean(ft_PROGRAM_DATA.IFBIsFastSer7);
					ee2232h.BIsVCP = Convert.ToBoolean(ft_PROGRAM_DATA.BIsVCP7);
					ee2232h.PowerSaveEnable = Convert.ToBoolean(ft_PROGRAM_DATA.PowerSaveEnable);
				}
			}
			else if (this.pFT_EE_Read == IntPtr.Zero)
			{
				Console.WriteLine("Failed to load function FT_EE_Read.");
			}
			return ft_STATUS;
		}

		public FT_STATUS ReadFT232BEEPROM(FT232B_EEPROM_STRUCTURE ee232b)
		{
			FT_STATUS ft_STATUS = FT_STATUS.FT_OTHER_ERROR;
			if (this.hFTD2XXDLL == IntPtr.Zero)
			{
				return ft_STATUS;
			}
			if (this.pFT_EE_Read != IntPtr.Zero)
			{
				FTDI.tFT_EE_Read tFT_EE_Read = (FTDI.tFT_EE_Read)Marshal.GetDelegateForFunctionPointer(this.pFT_EE_Read, typeof(FTDI.tFT_EE_Read));
				if (this.ftHandle != IntPtr.Zero)
				{
					FT_DEVICE ft_DEVICE = FT_DEVICE.FT_DEVICE_UNKNOWN;
					this.GetDeviceType(ref ft_DEVICE);
					if (ft_DEVICE != FT_DEVICE.FT_DEVICE_BM)
					{
						FT_ERROR ftErrorCondition = FT_ERROR.FT_INCORRECT_DEVICE;
						this.ErrorHandler(ft_STATUS, ftErrorCondition);
					}
					FT_PROGRAM_DATA ft_PROGRAM_DATA = new FT_PROGRAM_DATA();
					ft_PROGRAM_DATA.Signature1 = 0U;
					ft_PROGRAM_DATA.Signature2 = uint.MaxValue;
					ft_PROGRAM_DATA.Version = 2U;
					ft_PROGRAM_DATA.Manufacturer = Marshal.AllocHGlobal(32);
					ft_PROGRAM_DATA.ManufacturerID = Marshal.AllocHGlobal(16);
					ft_PROGRAM_DATA.Description = Marshal.AllocHGlobal(64);
					ft_PROGRAM_DATA.SerialNumber = Marshal.AllocHGlobal(16);
					ft_STATUS = tFT_EE_Read(this.ftHandle, ft_PROGRAM_DATA);
					ee232b.Manufacturer = Marshal.PtrToStringAnsi(ft_PROGRAM_DATA.Manufacturer);
					ee232b.ManufacturerID = Marshal.PtrToStringAnsi(ft_PROGRAM_DATA.ManufacturerID);
					ee232b.Description = Marshal.PtrToStringAnsi(ft_PROGRAM_DATA.Description);
					ee232b.SerialNumber = Marshal.PtrToStringAnsi(ft_PROGRAM_DATA.SerialNumber);
					Marshal.FreeHGlobal(ft_PROGRAM_DATA.Manufacturer);
					Marshal.FreeHGlobal(ft_PROGRAM_DATA.ManufacturerID);
					Marshal.FreeHGlobal(ft_PROGRAM_DATA.Description);
					Marshal.FreeHGlobal(ft_PROGRAM_DATA.SerialNumber);
					ee232b.VendorID = ft_PROGRAM_DATA.VendorID;
					ee232b.ProductID = ft_PROGRAM_DATA.ProductID;
					ee232b.MaxPower = ft_PROGRAM_DATA.MaxPower;
					ee232b.SelfPowered = Convert.ToBoolean(ft_PROGRAM_DATA.SelfPowered);
					ee232b.RemoteWakeup = Convert.ToBoolean(ft_PROGRAM_DATA.RemoteWakeup);
					ee232b.PullDownEnable = Convert.ToBoolean(ft_PROGRAM_DATA.PullDownEnable);
					ee232b.SerNumEnable = Convert.ToBoolean(ft_PROGRAM_DATA.SerNumEnable);
					ee232b.USBVersionEnable = Convert.ToBoolean(ft_PROGRAM_DATA.USBVersionEnable);
					ee232b.USBVersion = ft_PROGRAM_DATA.USBVersion;
				}
			}
			else if (this.pFT_EE_Read == IntPtr.Zero)
			{
				Console.WriteLine("Failed to load function FT_EE_Read.");
			}
			return ft_STATUS;
		}

		public FT_STATUS ReadFT232HEEPROM(FT232H_EEPROM_STRUCTURE ee232h)
		{
			FT_STATUS ft_STATUS = FT_STATUS.FT_OTHER_ERROR;
			if (this.hFTD2XXDLL == IntPtr.Zero)
			{
				return ft_STATUS;
			}
			if (this.pFT_EE_Read != IntPtr.Zero)
			{
				FTDI.tFT_EE_Read tFT_EE_Read = (FTDI.tFT_EE_Read)Marshal.GetDelegateForFunctionPointer(this.pFT_EE_Read, typeof(FTDI.tFT_EE_Read));
				if (this.ftHandle != IntPtr.Zero)
				{
					FT_DEVICE ft_DEVICE = FT_DEVICE.FT_DEVICE_UNKNOWN;
					this.GetDeviceType(ref ft_DEVICE);
					if (ft_DEVICE != FT_DEVICE.FT_DEVICE_232H && ft_DEVICE != FT_DEVICE.FT_DEVICE_232HP && ft_DEVICE != FT_DEVICE.FT_DEVICE_233HP)
					{
						FT_ERROR ftErrorCondition = FT_ERROR.FT_INCORRECT_DEVICE;
						this.ErrorHandler(ft_STATUS, ftErrorCondition);
					}
					FT_PROGRAM_DATA ft_PROGRAM_DATA = new FT_PROGRAM_DATA();
					ft_PROGRAM_DATA.Signature1 = 0U;
					ft_PROGRAM_DATA.Signature2 = uint.MaxValue;
					ft_PROGRAM_DATA.Version = 5U;
					ft_PROGRAM_DATA.Manufacturer = Marshal.AllocHGlobal(32);
					ft_PROGRAM_DATA.ManufacturerID = Marshal.AllocHGlobal(16);
					ft_PROGRAM_DATA.Description = Marshal.AllocHGlobal(64);
					ft_PROGRAM_DATA.SerialNumber = Marshal.AllocHGlobal(16);
					ft_STATUS = tFT_EE_Read(this.ftHandle, ft_PROGRAM_DATA);
					ee232h.Manufacturer = Marshal.PtrToStringAnsi(ft_PROGRAM_DATA.Manufacturer);
					ee232h.ManufacturerID = Marshal.PtrToStringAnsi(ft_PROGRAM_DATA.ManufacturerID);
					ee232h.Description = Marshal.PtrToStringAnsi(ft_PROGRAM_DATA.Description);
					ee232h.SerialNumber = Marshal.PtrToStringAnsi(ft_PROGRAM_DATA.SerialNumber);
					Marshal.FreeHGlobal(ft_PROGRAM_DATA.Manufacturer);
					Marshal.FreeHGlobal(ft_PROGRAM_DATA.ManufacturerID);
					Marshal.FreeHGlobal(ft_PROGRAM_DATA.Description);
					Marshal.FreeHGlobal(ft_PROGRAM_DATA.SerialNumber);
					ee232h.VendorID = ft_PROGRAM_DATA.VendorID;
					ee232h.ProductID = ft_PROGRAM_DATA.ProductID;
					ee232h.MaxPower = ft_PROGRAM_DATA.MaxPower;
					ee232h.SelfPowered = Convert.ToBoolean(ft_PROGRAM_DATA.SelfPowered);
					ee232h.RemoteWakeup = Convert.ToBoolean(ft_PROGRAM_DATA.RemoteWakeup);
					ee232h.PullDownEnable = Convert.ToBoolean(ft_PROGRAM_DATA.PullDownEnableH);
					ee232h.SerNumEnable = Convert.ToBoolean(ft_PROGRAM_DATA.SerNumEnableH);
					ee232h.ACSlowSlew = Convert.ToBoolean(ft_PROGRAM_DATA.ACSlowSlewH);
					ee232h.ACSchmittInput = Convert.ToBoolean(ft_PROGRAM_DATA.ACSchmittInputH);
					ee232h.ACDriveCurrent = ft_PROGRAM_DATA.ACDriveCurrentH;
					ee232h.ADSlowSlew = Convert.ToBoolean(ft_PROGRAM_DATA.ADSlowSlewH);
					ee232h.ADSchmittInput = Convert.ToBoolean(ft_PROGRAM_DATA.ADSchmittInputH);
					ee232h.ADDriveCurrent = ft_PROGRAM_DATA.ADDriveCurrentH;
					ee232h.Cbus0 = ft_PROGRAM_DATA.Cbus0H;
					ee232h.Cbus1 = ft_PROGRAM_DATA.Cbus1H;
					ee232h.Cbus2 = ft_PROGRAM_DATA.Cbus2H;
					ee232h.Cbus3 = ft_PROGRAM_DATA.Cbus3H;
					ee232h.Cbus4 = ft_PROGRAM_DATA.Cbus4H;
					ee232h.Cbus5 = ft_PROGRAM_DATA.Cbus5H;
					ee232h.Cbus6 = ft_PROGRAM_DATA.Cbus6H;
					ee232h.Cbus7 = ft_PROGRAM_DATA.Cbus7H;
					ee232h.Cbus8 = ft_PROGRAM_DATA.Cbus8H;
					ee232h.Cbus9 = ft_PROGRAM_DATA.Cbus9H;
					ee232h.IsFifo = Convert.ToBoolean(ft_PROGRAM_DATA.IsFifoH);
					ee232h.IsFifoTar = Convert.ToBoolean(ft_PROGRAM_DATA.IsFifoTarH);
					ee232h.IsFastSer = Convert.ToBoolean(ft_PROGRAM_DATA.IsFastSerH);
					ee232h.IsFT1248 = Convert.ToBoolean(ft_PROGRAM_DATA.IsFT1248H);
					ee232h.FT1248Cpol = Convert.ToBoolean(ft_PROGRAM_DATA.FT1248CpolH);
					ee232h.FT1248Lsb = Convert.ToBoolean(ft_PROGRAM_DATA.FT1248LsbH);
					ee232h.FT1248FlowControl = Convert.ToBoolean(ft_PROGRAM_DATA.FT1248FlowControlH);
					ee232h.IsVCP = Convert.ToBoolean(ft_PROGRAM_DATA.IsVCPH);
					ee232h.PowerSaveEnable = Convert.ToBoolean(ft_PROGRAM_DATA.PowerSaveEnableH);
				}
			}
			else if (this.pFT_EE_Read == IntPtr.Zero)
			{
				Console.WriteLine("Failed to load function FT_EE_Read.");
			}
			return ft_STATUS;
		}

		public FT_STATUS ReadFT232REEPROM(FT232R_EEPROM_STRUCTURE ee232r)
		{
			FT_STATUS ft_STATUS = FT_STATUS.FT_OTHER_ERROR;
			if (this.hFTD2XXDLL == IntPtr.Zero)
			{
				return ft_STATUS;
			}
			if (this.pFT_EE_Read != IntPtr.Zero)
			{
				FTDI.tFT_EE_Read tFT_EE_Read = (FTDI.tFT_EE_Read)Marshal.GetDelegateForFunctionPointer(this.pFT_EE_Read, typeof(FTDI.tFT_EE_Read));
				if (this.ftHandle != IntPtr.Zero)
				{
					FT_DEVICE ft_DEVICE = FT_DEVICE.FT_DEVICE_UNKNOWN;
					this.GetDeviceType(ref ft_DEVICE);
					if (ft_DEVICE != FT_DEVICE.FT_DEVICE_232R)
					{
						FT_ERROR ftErrorCondition = FT_ERROR.FT_INCORRECT_DEVICE;
						this.ErrorHandler(ft_STATUS, ftErrorCondition);
					}
					FT_PROGRAM_DATA ft_PROGRAM_DATA = new FT_PROGRAM_DATA();
					ft_PROGRAM_DATA.Signature1 = 0U;
					ft_PROGRAM_DATA.Signature2 = uint.MaxValue;
					ft_PROGRAM_DATA.Version = 2U;
					ft_PROGRAM_DATA.Manufacturer = Marshal.AllocHGlobal(32);
					ft_PROGRAM_DATA.ManufacturerID = Marshal.AllocHGlobal(16);
					ft_PROGRAM_DATA.Description = Marshal.AllocHGlobal(64);
					ft_PROGRAM_DATA.SerialNumber = Marshal.AllocHGlobal(16);
					ft_STATUS = tFT_EE_Read(this.ftHandle, ft_PROGRAM_DATA);
					ee232r.Manufacturer = Marshal.PtrToStringAnsi(ft_PROGRAM_DATA.Manufacturer);
					ee232r.ManufacturerID = Marshal.PtrToStringAnsi(ft_PROGRAM_DATA.ManufacturerID);
					ee232r.Description = Marshal.PtrToStringAnsi(ft_PROGRAM_DATA.Description);
					ee232r.SerialNumber = Marshal.PtrToStringAnsi(ft_PROGRAM_DATA.SerialNumber);
					Marshal.FreeHGlobal(ft_PROGRAM_DATA.Manufacturer);
					Marshal.FreeHGlobal(ft_PROGRAM_DATA.ManufacturerID);
					Marshal.FreeHGlobal(ft_PROGRAM_DATA.Description);
					Marshal.FreeHGlobal(ft_PROGRAM_DATA.SerialNumber);
					ee232r.VendorID = ft_PROGRAM_DATA.VendorID;
					ee232r.ProductID = ft_PROGRAM_DATA.ProductID;
					ee232r.MaxPower = ft_PROGRAM_DATA.MaxPower;
					ee232r.SelfPowered = Convert.ToBoolean(ft_PROGRAM_DATA.SelfPowered);
					ee232r.RemoteWakeup = Convert.ToBoolean(ft_PROGRAM_DATA.RemoteWakeup);
					ee232r.UseExtOsc = Convert.ToBoolean(ft_PROGRAM_DATA.UseExtOsc);
					ee232r.HighDriveIOs = Convert.ToBoolean(ft_PROGRAM_DATA.HighDriveIOs);
					ee232r.EndpointSize = ft_PROGRAM_DATA.EndpointSize;
					ee232r.PullDownEnable = Convert.ToBoolean(ft_PROGRAM_DATA.PullDownEnableR);
					ee232r.SerNumEnable = Convert.ToBoolean(ft_PROGRAM_DATA.SerNumEnableR);
					ee232r.InvertTXD = Convert.ToBoolean(ft_PROGRAM_DATA.InvertTXD);
					ee232r.InvertRXD = Convert.ToBoolean(ft_PROGRAM_DATA.InvertRXD);
					ee232r.InvertRTS = Convert.ToBoolean(ft_PROGRAM_DATA.InvertRTS);
					ee232r.InvertCTS = Convert.ToBoolean(ft_PROGRAM_DATA.InvertCTS);
					ee232r.InvertDTR = Convert.ToBoolean(ft_PROGRAM_DATA.InvertDTR);
					ee232r.InvertDSR = Convert.ToBoolean(ft_PROGRAM_DATA.InvertDSR);
					ee232r.InvertDCD = Convert.ToBoolean(ft_PROGRAM_DATA.InvertDCD);
					ee232r.InvertRI = Convert.ToBoolean(ft_PROGRAM_DATA.InvertRI);
					ee232r.Cbus0 = ft_PROGRAM_DATA.Cbus0;
					ee232r.Cbus1 = ft_PROGRAM_DATA.Cbus1;
					ee232r.Cbus2 = ft_PROGRAM_DATA.Cbus2;
					ee232r.Cbus3 = ft_PROGRAM_DATA.Cbus3;
					ee232r.Cbus4 = ft_PROGRAM_DATA.Cbus4;
					ee232r.RIsD2XX = Convert.ToBoolean(ft_PROGRAM_DATA.RIsD2XX);
				}
			}
			else if (this.pFT_EE_Read == IntPtr.Zero)
			{
				Console.WriteLine("Failed to load function FT_EE_Read.");
			}
			return ft_STATUS;
		}

		public FT_STATUS ReadFT4232HEEPROM(FT4232H_EEPROM_STRUCTURE ee4232h)
		{
			FT_STATUS ft_STATUS = FT_STATUS.FT_OTHER_ERROR;
			if (this.hFTD2XXDLL == IntPtr.Zero)
			{
				return ft_STATUS;
			}
			if (this.pFT_EE_Read != IntPtr.Zero)
			{
				FTDI.tFT_EE_Read tFT_EE_Read = (FTDI.tFT_EE_Read)Marshal.GetDelegateForFunctionPointer(this.pFT_EE_Read, typeof(FTDI.tFT_EE_Read));
				if (this.ftHandle != IntPtr.Zero)
				{
					FT_DEVICE ft_DEVICE = FT_DEVICE.FT_DEVICE_UNKNOWN;
					this.GetDeviceType(ref ft_DEVICE);
					if (ft_DEVICE != FT_DEVICE.FT_DEVICE_4232H)
					{
						FT_ERROR ftErrorCondition = FT_ERROR.FT_INCORRECT_DEVICE;
						this.ErrorHandler(ft_STATUS, ftErrorCondition);
					}
					FT_PROGRAM_DATA ft_PROGRAM_DATA = new FT_PROGRAM_DATA();
					ft_PROGRAM_DATA.Signature1 = 0U;
					ft_PROGRAM_DATA.Signature2 = uint.MaxValue;
					ft_PROGRAM_DATA.Version = 4U;
					ft_PROGRAM_DATA.Manufacturer = Marshal.AllocHGlobal(32);
					ft_PROGRAM_DATA.ManufacturerID = Marshal.AllocHGlobal(16);
					ft_PROGRAM_DATA.Description = Marshal.AllocHGlobal(64);
					ft_PROGRAM_DATA.SerialNumber = Marshal.AllocHGlobal(16);
					ft_STATUS = tFT_EE_Read(this.ftHandle, ft_PROGRAM_DATA);
					ee4232h.Manufacturer = Marshal.PtrToStringAnsi(ft_PROGRAM_DATA.Manufacturer);
					ee4232h.ManufacturerID = Marshal.PtrToStringAnsi(ft_PROGRAM_DATA.ManufacturerID);
					ee4232h.Description = Marshal.PtrToStringAnsi(ft_PROGRAM_DATA.Description);
					ee4232h.SerialNumber = Marshal.PtrToStringAnsi(ft_PROGRAM_DATA.SerialNumber);
					Marshal.FreeHGlobal(ft_PROGRAM_DATA.Manufacturer);
					Marshal.FreeHGlobal(ft_PROGRAM_DATA.ManufacturerID);
					Marshal.FreeHGlobal(ft_PROGRAM_DATA.Description);
					Marshal.FreeHGlobal(ft_PROGRAM_DATA.SerialNumber);
					ee4232h.VendorID = ft_PROGRAM_DATA.VendorID;
					ee4232h.ProductID = ft_PROGRAM_DATA.ProductID;
					ee4232h.MaxPower = ft_PROGRAM_DATA.MaxPower;
					ee4232h.SelfPowered = Convert.ToBoolean(ft_PROGRAM_DATA.SelfPowered);
					ee4232h.RemoteWakeup = Convert.ToBoolean(ft_PROGRAM_DATA.RemoteWakeup);
					ee4232h.PullDownEnable = Convert.ToBoolean(ft_PROGRAM_DATA.PullDownEnable8);
					ee4232h.SerNumEnable = Convert.ToBoolean(ft_PROGRAM_DATA.SerNumEnable8);
					ee4232h.ASlowSlew = Convert.ToBoolean(ft_PROGRAM_DATA.ASlowSlew);
					ee4232h.ASchmittInput = Convert.ToBoolean(ft_PROGRAM_DATA.ASchmittInput);
					ee4232h.ADriveCurrent = ft_PROGRAM_DATA.ADriveCurrent;
					ee4232h.BSlowSlew = Convert.ToBoolean(ft_PROGRAM_DATA.BSlowSlew);
					ee4232h.BSchmittInput = Convert.ToBoolean(ft_PROGRAM_DATA.BSchmittInput);
					ee4232h.BDriveCurrent = ft_PROGRAM_DATA.BDriveCurrent;
					ee4232h.CSlowSlew = Convert.ToBoolean(ft_PROGRAM_DATA.CSlowSlew);
					ee4232h.CSchmittInput = Convert.ToBoolean(ft_PROGRAM_DATA.CSchmittInput);
					ee4232h.CDriveCurrent = ft_PROGRAM_DATA.CDriveCurrent;
					ee4232h.DSlowSlew = Convert.ToBoolean(ft_PROGRAM_DATA.DSlowSlew);
					ee4232h.DSchmittInput = Convert.ToBoolean(ft_PROGRAM_DATA.DSchmittInput);
					ee4232h.DDriveCurrent = ft_PROGRAM_DATA.DDriveCurrent;
					ee4232h.ARIIsTXDEN = Convert.ToBoolean(ft_PROGRAM_DATA.ARIIsTXDEN);
					ee4232h.BRIIsTXDEN = Convert.ToBoolean(ft_PROGRAM_DATA.BRIIsTXDEN);
					ee4232h.CRIIsTXDEN = Convert.ToBoolean(ft_PROGRAM_DATA.CRIIsTXDEN);
					ee4232h.DRIIsTXDEN = Convert.ToBoolean(ft_PROGRAM_DATA.DRIIsTXDEN);
					ee4232h.AIsVCP = Convert.ToBoolean(ft_PROGRAM_DATA.AIsVCP8);
					ee4232h.BIsVCP = Convert.ToBoolean(ft_PROGRAM_DATA.BIsVCP8);
					ee4232h.CIsVCP = Convert.ToBoolean(ft_PROGRAM_DATA.CIsVCP8);
					ee4232h.DIsVCP = Convert.ToBoolean(ft_PROGRAM_DATA.DIsVCP8);
				}
			}
			else if (this.pFT_EE_Read == IntPtr.Zero)
			{
				Console.WriteLine("Failed to load function FT_EE_Read.");
			}
			return ft_STATUS;
		}
		public FT_STATUS ReadXSeriesEEPROM(FT_XSERIES_EEPROM_STRUCTURE eeX)
		{
			FT_STATUS ft_STATUS = FT_STATUS.FT_OTHER_ERROR;
			if (this.hFTD2XXDLL == IntPtr.Zero)
			{
				return ft_STATUS;
			}
			if (this.pFT_EEPROM_Read != IntPtr.Zero)
			{
				FTDI.tFT_EEPROM_Read tFT_EEPROM_Read = (FTDI.tFT_EEPROM_Read)Marshal.GetDelegateForFunctionPointer(this.pFT_EEPROM_Read, typeof(FTDI.tFT_EEPROM_Read));
				if (this.ftHandle != IntPtr.Zero)
				{
					FT_DEVICE ft_DEVICE = FT_DEVICE.FT_DEVICE_UNKNOWN;
					this.GetDeviceType(ref ft_DEVICE);
					if (ft_DEVICE != FT_DEVICE.FT_DEVICE_X_SERIES)
					{
						FT_ERROR ftErrorCondition = FT_ERROR.FT_INCORRECT_DEVICE;
						this.ErrorHandler(ft_STATUS, ftErrorCondition);
					}
					FT_XSERIES_DATA ft_XSERIES_DATA = default(FT_XSERIES_DATA);
					FT_EEPROM_HEADER common = default(FT_EEPROM_HEADER);
					byte[] array = new byte[32];
					byte[] array2 = new byte[16];
					byte[] array3 = new byte[64];
					byte[] array4 = new byte[16];
					common.deviceType = 9U;
					ft_XSERIES_DATA.common = common;
					int num = Marshal.SizeOf(ft_XSERIES_DATA);
					IntPtr intPtr = Marshal.AllocHGlobal(num);
					Marshal.StructureToPtr(ft_XSERIES_DATA, intPtr, false);
					ft_STATUS = tFT_EEPROM_Read(this.ftHandle, intPtr, (uint)num, array, array2, array3, array4);
					if (ft_STATUS == FT_STATUS.FT_OK)
					{
						ft_XSERIES_DATA = (FT_XSERIES_DATA)Marshal.PtrToStructure(intPtr, typeof(FT_XSERIES_DATA));
						UTF8Encoding utf8Encoding = new UTF8Encoding();
						eeX.Manufacturer = utf8Encoding.GetString(array);
						eeX.ManufacturerID = utf8Encoding.GetString(array2);
						eeX.Description = utf8Encoding.GetString(array3);
						eeX.SerialNumber = utf8Encoding.GetString(array4);
						eeX.VendorID = ft_XSERIES_DATA.common.VendorId;
						eeX.ProductID = ft_XSERIES_DATA.common.ProductId;
						eeX.MaxPower = ft_XSERIES_DATA.common.MaxPower;
						eeX.SelfPowered = Convert.ToBoolean(ft_XSERIES_DATA.common.SelfPowered);
						eeX.RemoteWakeup = Convert.ToBoolean(ft_XSERIES_DATA.common.RemoteWakeup);
						eeX.SerNumEnable = Convert.ToBoolean(ft_XSERIES_DATA.common.SerNumEnable);
						eeX.PullDownEnable = Convert.ToBoolean(ft_XSERIES_DATA.common.PullDownEnable);
						eeX.Cbus0 = ft_XSERIES_DATA.Cbus0;
						eeX.Cbus1 = ft_XSERIES_DATA.Cbus1;
						eeX.Cbus2 = ft_XSERIES_DATA.Cbus2;
						eeX.Cbus3 = ft_XSERIES_DATA.Cbus3;
						eeX.Cbus4 = ft_XSERIES_DATA.Cbus4;
						eeX.Cbus5 = ft_XSERIES_DATA.Cbus5;
						eeX.Cbus6 = ft_XSERIES_DATA.Cbus6;
						eeX.ACDriveCurrent = ft_XSERIES_DATA.ACDriveCurrent;
						eeX.ACSchmittInput = ft_XSERIES_DATA.ACSchmittInput;
						eeX.ACSlowSlew = ft_XSERIES_DATA.ACSlowSlew;
						eeX.ADDriveCurrent = ft_XSERIES_DATA.ADDriveCurrent;
						eeX.ADSchmittInput = ft_XSERIES_DATA.ADSchmittInput;
						eeX.ADSlowSlew = ft_XSERIES_DATA.ADSlowSlew;
						eeX.BCDDisableSleep = ft_XSERIES_DATA.BCDDisableSleep;
						eeX.BCDEnable = ft_XSERIES_DATA.BCDEnable;
						eeX.BCDForceCbusPWREN = ft_XSERIES_DATA.BCDForceCbusPWREN;
						eeX.FT1248Cpol = ft_XSERIES_DATA.FT1248Cpol;
						eeX.FT1248FlowControl = ft_XSERIES_DATA.FT1248FlowControl;
						eeX.FT1248Lsb = ft_XSERIES_DATA.FT1248Lsb;
						eeX.I2CDeviceId = ft_XSERIES_DATA.I2CDeviceId;
						eeX.I2CDisableSchmitt = ft_XSERIES_DATA.I2CDisableSchmitt;
						eeX.I2CSlaveAddress = ft_XSERIES_DATA.I2CSlaveAddress;
						eeX.InvertCTS = ft_XSERIES_DATA.InvertCTS;
						eeX.InvertDCD = ft_XSERIES_DATA.InvertDCD;
						eeX.InvertDSR = ft_XSERIES_DATA.InvertDSR;
						eeX.InvertDTR = ft_XSERIES_DATA.InvertDTR;
						eeX.InvertRI = ft_XSERIES_DATA.InvertRI;
						eeX.InvertRTS = ft_XSERIES_DATA.InvertRTS;
						eeX.InvertRXD = ft_XSERIES_DATA.InvertRXD;
						eeX.InvertTXD = ft_XSERIES_DATA.InvertTXD;
						eeX.PowerSaveEnable = ft_XSERIES_DATA.PowerSaveEnable;
						eeX.RS485EchoSuppress = ft_XSERIES_DATA.RS485EchoSuppress;
						eeX.IsVCP = ft_XSERIES_DATA.DriverType;
					}
				}
			}
			else if (this.pFT_EE_Read == IntPtr.Zero)
			{
				Console.WriteLine("Failed to load function FT_EE_Read.");
			}
			return ft_STATUS;
		}
		public FT_STATUS Reload(ushort VendorID, ushort ProductID)
		{
			FT_STATUS result = FT_STATUS.FT_OTHER_ERROR;
			if (this.hFTD2XXDLL == IntPtr.Zero)
			{
				return result;
			}
			if (this.pFT_Reload != IntPtr.Zero)
			{
				FTDI.tFT_Reload tFT_Reload = (FTDI.tFT_Reload)Marshal.GetDelegateForFunctionPointer(this.pFT_Reload, typeof(FTDI.tFT_Reload));
				result = tFT_Reload(VendorID, ProductID);
			}
			else if (this.pFT_Reload == IntPtr.Zero)
			{
				Console.WriteLine("Failed to load function FT_Reload.");
			}
			return result;
		}
		public FT_STATUS Rescan()
		{
			FT_STATUS result = FT_STATUS.FT_OTHER_ERROR;
			if (this.hFTD2XXDLL == IntPtr.Zero)
			{
				return result;
			}
			if (this.pFT_Rescan != IntPtr.Zero)
			{
				FTDI.tFT_Rescan tFT_Rescan = (FTDI.tFT_Rescan)Marshal.GetDelegateForFunctionPointer(this.pFT_Rescan, typeof(FTDI.tFT_Rescan));
				result = tFT_Rescan();
			}
			else if (this.pFT_Rescan == IntPtr.Zero)
			{
				Console.WriteLine("Failed to load function FT_Rescan.");
			}
			return result;
		}

		public FT_STATUS ResetDevice()
		{
			FT_STATUS result = FT_STATUS.FT_OTHER_ERROR;
			if (this.hFTD2XXDLL == IntPtr.Zero)
			{
				return result;
			}
			if (this.pFT_ResetDevice != IntPtr.Zero)
			{
				FTDI.tFT_ResetDevice tFT_ResetDevice = (FTDI.tFT_ResetDevice)Marshal.GetDelegateForFunctionPointer(this.pFT_ResetDevice, typeof(FTDI.tFT_ResetDevice));
				if (this.ftHandle != IntPtr.Zero)
				{
					result = tFT_ResetDevice(this.ftHandle);
				}
			}
			else if (this.pFT_ResetDevice == IntPtr.Zero)
			{
				Console.WriteLine("Failed to load function FT_ResetDevice.");
			}
			return result;
		}


		public FT_STATUS ResetPort()
		{
			FT_STATUS result = FT_STATUS.FT_OTHER_ERROR;
			if (this.hFTD2XXDLL == IntPtr.Zero)
			{
				return result;
			}
			if (this.pFT_ResetPort != IntPtr.Zero)
			{
				FTDI.tFT_ResetPort tFT_ResetPort = (FTDI.tFT_ResetPort)Marshal.GetDelegateForFunctionPointer(this.pFT_ResetPort, typeof(FTDI.tFT_ResetPort));
				if (this.ftHandle != IntPtr.Zero)
				{
					result = tFT_ResetPort(this.ftHandle);
				}
			}
			else if (this.pFT_ResetPort == IntPtr.Zero)
			{
				Console.WriteLine("Failed to load function FT_ResetPort.");
			}
			return result;
		}

		public FT_STATUS RestartInTask()
		{
			FT_STATUS result = FT_STATUS.FT_OTHER_ERROR;
			if (this.hFTD2XXDLL == IntPtr.Zero)
			{
				return result;
			}
			if (this.pFT_RestartInTask != IntPtr.Zero)
			{
				FTDI.tFT_RestartInTask tFT_RestartInTask = (FTDI.tFT_RestartInTask)Marshal.GetDelegateForFunctionPointer(this.pFT_RestartInTask, typeof(FTDI.tFT_RestartInTask));
				if (this.ftHandle != IntPtr.Zero)
				{
					result = tFT_RestartInTask(this.ftHandle);
				}
			}
			else if (this.pFT_RestartInTask == IntPtr.Zero)
			{
				Console.WriteLine("Failed to load function FT_RestartInTask.");
			}
			return result;
		}

		public FT_STATUS SetBaudRate(uint BaudRate)
		{
			FT_STATUS result = FT_STATUS.FT_OTHER_ERROR;
			if (this.hFTD2XXDLL == IntPtr.Zero)
			{
				return result;
			}
			if (this.pFT_SetBaudRate != IntPtr.Zero)
			{
				FTDI.tFT_SetBaudRate tFT_SetBaudRate = (FTDI.tFT_SetBaudRate)Marshal.GetDelegateForFunctionPointer(this.pFT_SetBaudRate, typeof(FTDI.tFT_SetBaudRate));
				if (this.ftHandle != IntPtr.Zero)
				{
					result = tFT_SetBaudRate(this.ftHandle, BaudRate);
				}
			}
			else if (this.pFT_SetBaudRate == IntPtr.Zero)
			{
				Console.WriteLine("Failed to load function FT_SetBaudRate.");
			}
			return result;
		}
		public bool IsOpen
		{
			get
			{
				return !(this.ftHandle == IntPtr.Zero);
			}
		}
		private string InterfaceIdentifier
		{
			get
			{
				string empty = string.Empty;
				if (this.IsOpen)
				{
					FT_DEVICE ft_DEVICE = FT_DEVICE.FT_DEVICE_BM;
					this.GetDeviceType(ref ft_DEVICE);
					if (ft_DEVICE == FT_DEVICE.FT_DEVICE_2232H || ft_DEVICE == FT_DEVICE.FT_DEVICE_4232H || ft_DEVICE == FT_DEVICE.FT_DEVICE_2233HP || ft_DEVICE == FT_DEVICE.FT_DEVICE_4233HP || ft_DEVICE == FT_DEVICE.FT_DEVICE_2232HP || ft_DEVICE == FT_DEVICE.FT_DEVICE_4232HP || ft_DEVICE == FT_DEVICE.FT_DEVICE_2232HA || ft_DEVICE == FT_DEVICE.FT_DEVICE_4232HA || ft_DEVICE == FT_DEVICE.FT_DEVICE_2232)
					{
						string text;
						this.GetDescription(out text);
						return text.Substring(text.Length - 1);
					}
				}
				return empty;
			}
		}
		public FT_STATUS SetBitMode(byte Mask, byte BitMode)
		{
			FT_STATUS ft_STATUS = FT_STATUS.FT_OTHER_ERROR;
			if (this.hFTD2XXDLL == IntPtr.Zero)
			{
				return ft_STATUS;
			}
			if (this.pFT_SetBitMode != IntPtr.Zero)
			{
				FTDI.tFT_SetBitMode tFT_SetBitMode = (FTDI.tFT_SetBitMode)Marshal.GetDelegateForFunctionPointer(this.pFT_SetBitMode, typeof(FTDI.tFT_SetBitMode));
				if (this.ftHandle != IntPtr.Zero)
				{
					FT_DEVICE ft_DEVICE = FT_DEVICE.FT_DEVICE_UNKNOWN;
					this.GetDeviceType(ref ft_DEVICE);
					if (ft_DEVICE == FT_DEVICE.FT_DEVICE_AM)
					{
						FT_ERROR ftErrorCondition = FT_ERROR.FT_INVALID_BITMODE;
						this.ErrorHandler(ft_STATUS, ftErrorCondition);
					}
					else if (ft_DEVICE == FT_DEVICE.FT_DEVICE_100AX)
					{
						FT_ERROR ftErrorCondition = FT_ERROR.FT_INVALID_BITMODE;
						this.ErrorHandler(ft_STATUS, ftErrorCondition);
					}
					else if (ft_DEVICE == FT_DEVICE.FT_DEVICE_BM && BitMode != 0)
					{
						if ((BitMode & 1) == 0)
						{
							FT_ERROR ftErrorCondition = FT_ERROR.FT_INVALID_BITMODE;
							this.ErrorHandler(ft_STATUS, ftErrorCondition);
						}
					}
					else if (ft_DEVICE == FT_DEVICE.FT_DEVICE_2232 && BitMode != 0)
					{
						if ((BitMode & 31) == 0)
						{
							FT_ERROR ftErrorCondition = FT_ERROR.FT_INVALID_BITMODE;
							this.ErrorHandler(ft_STATUS, ftErrorCondition);
						}
						if (BitMode == 2 & this.InterfaceIdentifier != "A")
						{
							FT_ERROR ftErrorCondition = FT_ERROR.FT_INVALID_BITMODE;
							this.ErrorHandler(ft_STATUS, ftErrorCondition);
						}
					}
					else if (ft_DEVICE == FT_DEVICE.FT_DEVICE_232R && BitMode != 0)
					{
						if ((BitMode & 37) == 0)
						{
							FT_ERROR ftErrorCondition = FT_ERROR.FT_INVALID_BITMODE;
							this.ErrorHandler(ft_STATUS, ftErrorCondition);
						}
					}
					else if ((ft_DEVICE == FT_DEVICE.FT_DEVICE_2232H || ft_DEVICE == FT_DEVICE.FT_DEVICE_2232HP || ft_DEVICE == FT_DEVICE.FT_DEVICE_2233HP || ft_DEVICE == FT_DEVICE.FT_DEVICE_2232HA) && BitMode != 0)
					{
						if ((BitMode & 95) == 0)
						{
							FT_ERROR ftErrorCondition = FT_ERROR.FT_INVALID_BITMODE;
							this.ErrorHandler(ft_STATUS, ftErrorCondition);
						}
						if ((BitMode == 8 | BitMode == 64) & this.InterfaceIdentifier != "A")
						{
							FT_ERROR ftErrorCondition = FT_ERROR.FT_INVALID_BITMODE;
							this.ErrorHandler(ft_STATUS, ftErrorCondition);
						}
					}
					else if ((ft_DEVICE == FT_DEVICE.FT_DEVICE_4232H || ft_DEVICE == FT_DEVICE.FT_DEVICE_4232HP || ft_DEVICE == FT_DEVICE.FT_DEVICE_4233HP || ft_DEVICE == FT_DEVICE.FT_DEVICE_4232HA) && BitMode != 0)
					{
						if ((BitMode & 7) == 0)
						{
							FT_ERROR ftErrorCondition = FT_ERROR.FT_INVALID_BITMODE;
							this.ErrorHandler(ft_STATUS, ftErrorCondition);
						}
						if (BitMode == 2 & (this.InterfaceIdentifier != "A" & this.InterfaceIdentifier != "B"))
						{
							FT_ERROR ftErrorCondition = FT_ERROR.FT_INVALID_BITMODE;
							this.ErrorHandler(ft_STATUS, ftErrorCondition);
						}
					}
					else if ((ft_DEVICE == FT_DEVICE.FT_DEVICE_232H || ft_DEVICE == FT_DEVICE.FT_DEVICE_232HP || ft_DEVICE == FT_DEVICE.FT_DEVICE_233HP) && BitMode != 0 && BitMode > 64)
					{
						FT_ERROR ftErrorCondition = FT_ERROR.FT_INVALID_BITMODE;
						this.ErrorHandler(ft_STATUS, ftErrorCondition);
					}
					ft_STATUS = tFT_SetBitMode(this.ftHandle, Mask, BitMode);
				}
			}
			else if (this.pFT_SetBitMode == IntPtr.Zero)
			{
				Console.WriteLine("Failed to load function FT_SetBitMode.");
			}
			return ft_STATUS;
		}
		public FT_STATUS SetBreak(bool Enable)
		{
			FT_STATUS result = FT_STATUS.FT_OTHER_ERROR;
			if (this.hFTD2XXDLL == IntPtr.Zero)
			{
				return result;
			}
			if (this.pFT_SetBreakOn != IntPtr.Zero & this.pFT_SetBreakOff != IntPtr.Zero)
			{
				FTDI.tFT_SetBreakOn tFT_SetBreakOn = (FTDI.tFT_SetBreakOn)Marshal.GetDelegateForFunctionPointer(this.pFT_SetBreakOn, typeof(FTDI.tFT_SetBreakOn));
				FTDI.tFT_SetBreakOff tFT_SetBreakOff = (FTDI.tFT_SetBreakOff)Marshal.GetDelegateForFunctionPointer(this.pFT_SetBreakOff, typeof(FTDI.tFT_SetBreakOff));
				if (this.ftHandle != IntPtr.Zero)
				{
					if (Enable)
					{
						result = tFT_SetBreakOn(this.ftHandle);
					}
					else
					{
						result = tFT_SetBreakOff(this.ftHandle);
					}
				}
			}
			else
			{
				if (this.pFT_SetBreakOn == IntPtr.Zero)
				{
					Console.WriteLine("Failed to load function FT_SetBreakOn.");
				}
				if (this.pFT_SetBreakOff == IntPtr.Zero)
				{
					Console.WriteLine("Failed to load function FT_SetBreakOff.");
				}
			}
			return result;
		}
		public FT_STATUS SetCharacters(byte EventChar, bool EventCharEnable, byte ErrorChar, bool ErrorCharEnable)
		{
			FT_STATUS result = FT_STATUS.FT_OTHER_ERROR;
			if (this.hFTD2XXDLL == IntPtr.Zero)
			{
				return result;
			}
			if (this.pFT_SetChars != IntPtr.Zero)
			{
				FTDI.tFT_SetChars tFT_SetChars = (FTDI.tFT_SetChars)Marshal.GetDelegateForFunctionPointer(this.pFT_SetChars, typeof(FTDI.tFT_SetChars));
				if (this.ftHandle != IntPtr.Zero)
				{
					result = tFT_SetChars(this.ftHandle, EventChar, Convert.ToByte(EventCharEnable), ErrorChar, Convert.ToByte(ErrorCharEnable));
				}
			}
			else if (this.pFT_SetChars == IntPtr.Zero)
			{
				Console.WriteLine("Failed to load function FT_SetChars.");
			}
			return result;
		}

		public FT_STATUS SetDataCharacteristics(byte DataBits, byte StopBits, byte Parity)
		{
			FT_STATUS result = FT_STATUS.FT_OTHER_ERROR;
			if (this.hFTD2XXDLL == IntPtr.Zero)
			{
				return result;
			}
			if (this.pFT_SetDataCharacteristics != IntPtr.Zero)
			{
				FTDI.tFT_SetDataCharacteristics tFT_SetDataCharacteristics = (FTDI.tFT_SetDataCharacteristics)Marshal.GetDelegateForFunctionPointer(this.pFT_SetDataCharacteristics, typeof(FTDI.tFT_SetDataCharacteristics));
				if (this.ftHandle != IntPtr.Zero)
				{
					result = tFT_SetDataCharacteristics(this.ftHandle, DataBits, StopBits, Parity);
				}
			}
			else if (this.pFT_SetDataCharacteristics == IntPtr.Zero)
			{
				Console.WriteLine("Failed to load function FT_SetDataCharacteristics.");
			}
			return result;
		}
		public FT_STATUS SetDeadmanTimeout(uint DeadmanTimeout)
		{
			FT_STATUS result = FT_STATUS.FT_OTHER_ERROR;
			if (this.hFTD2XXDLL == IntPtr.Zero)
			{
				return result;
			}
			if (this.pFT_SetDeadmanTimeout != IntPtr.Zero)
			{
				FTDI.tFT_SetDeadmanTimeout tFT_SetDeadmanTimeout = (FTDI.tFT_SetDeadmanTimeout)Marshal.GetDelegateForFunctionPointer(this.pFT_SetDeadmanTimeout, typeof(FTDI.tFT_SetDeadmanTimeout));
				if (this.ftHandle != IntPtr.Zero)
				{
					result = tFT_SetDeadmanTimeout(this.ftHandle, DeadmanTimeout);
				}
			}
			else if (this.pFT_SetDeadmanTimeout == IntPtr.Zero)
			{
				Console.WriteLine("Failed to load function FT_SetDeadmanTimeout.");
			}
			return result;
		}
		public FT_STATUS SetDTR(bool Enable)
		{
			FT_STATUS result = FT_STATUS.FT_OTHER_ERROR;
			if (this.hFTD2XXDLL == IntPtr.Zero)
			{
				return result;
			}
			if (this.pFT_SetDtr != IntPtr.Zero & this.pFT_ClrDtr != IntPtr.Zero)
			{
				FTDI.tFT_SetDtr tFT_SetDtr = (FTDI.tFT_SetDtr)Marshal.GetDelegateForFunctionPointer(this.pFT_SetDtr, typeof(FTDI.tFT_SetDtr));
				FTDI.tFT_ClrDtr tFT_ClrDtr = (FTDI.tFT_ClrDtr)Marshal.GetDelegateForFunctionPointer(this.pFT_ClrDtr, typeof(FTDI.tFT_ClrDtr));
				if (this.ftHandle != IntPtr.Zero)
				{
					if (Enable)
					{
						result = tFT_SetDtr(this.ftHandle);
					}
					else
					{
						result = tFT_ClrDtr(this.ftHandle);
					}
				}
			}
			else
			{
				if (this.pFT_SetDtr == IntPtr.Zero)
				{
					Console.WriteLine("Failed to load function FT_SetDtr.");
				}
				if (this.pFT_ClrDtr == IntPtr.Zero)
				{
					Console.WriteLine("Failed to load function FT_ClrDtr.");
				}
			}
			return result;
		}
		public FT_STATUS SetEventNotification(uint eventmask, EventWaitHandle eventhandle)
		{
			FT_STATUS result = FT_STATUS.FT_OTHER_ERROR;
			if (this.hFTD2XXDLL == IntPtr.Zero)
			{
				return result;
			}
			if (this.pFT_SetEventNotification != IntPtr.Zero)
			{
				FTDI.tFT_SetEventNotification tFT_SetEventNotification = (FTDI.tFT_SetEventNotification)Marshal.GetDelegateForFunctionPointer(this.pFT_SetEventNotification, typeof(FTDI.tFT_SetEventNotification));
				if (this.ftHandle != IntPtr.Zero)
				{
					result = tFT_SetEventNotification(this.ftHandle, eventmask, eventhandle.SafeWaitHandle);
				}
			}
			else if (this.pFT_SetEventNotification == IntPtr.Zero)
			{
				Console.WriteLine("Failed to load function FT_SetEventNotification.");
			}
			return result;
		}
		public FT_STATUS SetFlowControl(ushort FlowControl, byte Xon, byte Xoff)
		{
			FT_STATUS result = FT_STATUS.FT_OTHER_ERROR;
			if (this.hFTD2XXDLL == IntPtr.Zero)
			{
				return result;
			}
			if (this.pFT_SetFlowControl != IntPtr.Zero)
			{
				FTDI.tFT_SetFlowControl tFT_SetFlowControl = (FTDI.tFT_SetFlowControl)Marshal.GetDelegateForFunctionPointer(this.pFT_SetFlowControl, typeof(FTDI.tFT_SetFlowControl));
				if (this.ftHandle != IntPtr.Zero)
				{
					result = tFT_SetFlowControl(this.ftHandle, FlowControl, Xon, Xoff);
				}
			}
			else if (this.pFT_SetFlowControl == IntPtr.Zero)
			{
				Console.WriteLine("Failed to load function FT_SetFlowControl.");
			}
			return result;
		}
		public FT_STATUS SetLatency(byte Latency)
		{
			FT_STATUS result = FT_STATUS.FT_OTHER_ERROR;
			if (this.hFTD2XXDLL == IntPtr.Zero)
			{
				return result;
			}
			if (this.pFT_SetLatencyTimer != IntPtr.Zero)
			{
				FTDI.tFT_SetLatencyTimer tFT_SetLatencyTimer = (FTDI.tFT_SetLatencyTimer)Marshal.GetDelegateForFunctionPointer(this.pFT_SetLatencyTimer, typeof(FTDI.tFT_SetLatencyTimer));
				if (this.ftHandle != IntPtr.Zero)
				{
					FT_DEVICE ft_DEVICE = FT_DEVICE.FT_DEVICE_UNKNOWN;
					this.GetDeviceType(ref ft_DEVICE);
					if ((ft_DEVICE == FT_DEVICE.FT_DEVICE_BM || ft_DEVICE == FT_DEVICE.FT_DEVICE_2232) && Latency < 2)
					{
						Latency = 2;
					}
					result = tFT_SetLatencyTimer(this.ftHandle, Latency);
				}
			}
			else if (this.pFT_SetLatencyTimer == IntPtr.Zero)
			{
				Console.WriteLine("Failed to load function FT_SetLatencyTimer.");
			}
			return result;
		}
		public FT_STATUS SetResetPipeRetryCount(uint ResetPipeRetryCount)
		{
			FT_STATUS result = FT_STATUS.FT_OTHER_ERROR;
			if (this.hFTD2XXDLL == IntPtr.Zero)
			{
				return result;
			}
			if (this.pFT_SetResetPipeRetryCount != IntPtr.Zero)
			{
				FTDI.tFT_SetResetPipeRetryCount tFT_SetResetPipeRetryCount = (FTDI.tFT_SetResetPipeRetryCount)Marshal.GetDelegateForFunctionPointer(this.pFT_SetResetPipeRetryCount, typeof(FTDI.tFT_SetResetPipeRetryCount));
				if (this.ftHandle != IntPtr.Zero)
				{
					result = tFT_SetResetPipeRetryCount(this.ftHandle, ResetPipeRetryCount);
				}
			}
			else if (this.pFT_SetResetPipeRetryCount == IntPtr.Zero)
			{
				Console.WriteLine("Failed to load function FT_SetResetPipeRetryCount.");
			}
			return result;
		}
		public FT_STATUS SetRTS(bool Enable)
		{
			FT_STATUS result = FT_STATUS.FT_OTHER_ERROR;
			if (this.hFTD2XXDLL == IntPtr.Zero)
			{
				return result;
			}
			if (this.pFT_SetRts != IntPtr.Zero & this.pFT_ClrRts != IntPtr.Zero)
			{
				FTDI.tFT_SetRts tFT_SetRts = (FTDI.tFT_SetRts)Marshal.GetDelegateForFunctionPointer(this.pFT_SetRts, typeof(FTDI.tFT_SetRts));
				FTDI.tFT_ClrRts tFT_ClrRts = (FTDI.tFT_ClrRts)Marshal.GetDelegateForFunctionPointer(this.pFT_ClrRts, typeof(FTDI.tFT_ClrRts));
				if (this.ftHandle != IntPtr.Zero)
				{
					if (Enable)
					{
						result = tFT_SetRts(this.ftHandle);
					}
					else
					{
						result = tFT_ClrRts(this.ftHandle);
					}
				}
			}
			else
			{
				if (this.pFT_SetRts == IntPtr.Zero)
				{
					Console.WriteLine("Failed to load function FT_SetRts.");
				}
				if (this.pFT_ClrRts == IntPtr.Zero)
				{
					Console.WriteLine("Failed to load function FT_ClrRts.");
				}
			}
			return result;
		}
		public FT_STATUS SetTimeouts(uint ReadTimeout, uint WriteTimeout)
		{
			FT_STATUS result = FT_STATUS.FT_OTHER_ERROR;
			if (this.hFTD2XXDLL == IntPtr.Zero)
			{
				return result;
			}
			if (this.pFT_SetTimeouts != IntPtr.Zero)
			{
				FTDI.tFT_SetTimeouts tFT_SetTimeouts = (FTDI.tFT_SetTimeouts)Marshal.GetDelegateForFunctionPointer(this.pFT_SetTimeouts, typeof(FTDI.tFT_SetTimeouts));
				if (this.ftHandle != IntPtr.Zero)
				{
					result = tFT_SetTimeouts(this.ftHandle, ReadTimeout, WriteTimeout);
				}
			}
			else if (this.pFT_SetTimeouts == IntPtr.Zero)
			{
				Console.WriteLine("Failed to load function FT_SetTimeouts.");
			}
			return result;
		}
		public FT_STATUS StopInTask()
		{
			FT_STATUS result = FT_STATUS.FT_OTHER_ERROR;
			if (this.hFTD2XXDLL == IntPtr.Zero)
			{
				return result;
			}
			if (this.pFT_StopInTask != IntPtr.Zero)
			{
				FTDI.tFT_StopInTask tFT_StopInTask = (FTDI.tFT_StopInTask)Marshal.GetDelegateForFunctionPointer(this.pFT_StopInTask, typeof(FTDI.tFT_StopInTask));
				if (this.ftHandle != IntPtr.Zero)
				{
					result = tFT_StopInTask(this.ftHandle);
				}
			}
			else if (this.pFT_StopInTask == IntPtr.Zero)
			{
				Console.WriteLine("Failed to load function FT_StopInTask.");
			}
			return result;
		}
		public FT_STATUS VendorCmdGet(ushort request, byte[] buf, ushort len)
		{
			FT_STATUS result = FT_STATUS.FT_OTHER_ERROR;
			if (this.hFTD2XXDLL == IntPtr.Zero)
			{
				return result;
			}
			if (this.pFT_VendorCmdGet != IntPtr.Zero)
			{
				FTDI.tFT_VendorCmdGet tFT_VendorCmdGet = (FTDI.tFT_VendorCmdGet)Marshal.GetDelegateForFunctionPointer(this.pFT_VendorCmdGet, typeof(FTDI.tFT_VendorCmdGet));
				if (this.ftHandle != IntPtr.Zero)
				{
					result = tFT_VendorCmdGet(this.ftHandle, request, buf, len);
				}
			}
			else if (this.pFT_VendorCmdGet == IntPtr.Zero)
			{
				Console.WriteLine("Failed to load function FT_VendorCmdGet.");
			}
			return result;
		}

		public FT_STATUS VendorCmdSet(ushort request, byte[] buf, ushort len)
		{
			FT_STATUS result = FT_STATUS.FT_OTHER_ERROR;
			if (this.hFTD2XXDLL == IntPtr.Zero)
			{
				return result;
			}
			if (this.pFT_VendorCmdSet != IntPtr.Zero)
			{
				FTDI.tFT_VendorCmdSet tFT_VendorCmdSet = (FTDI.tFT_VendorCmdSet)Marshal.GetDelegateForFunctionPointer(this.pFT_VendorCmdSet, typeof(FTDI.tFT_VendorCmdSet));
				if (this.ftHandle != IntPtr.Zero)
				{
					result = tFT_VendorCmdSet(this.ftHandle, request, buf, len);
				}
			}
			else if (this.pFT_VendorCmdSet == IntPtr.Zero)
			{
				Console.WriteLine("Failed to load function FT_VendorCmdSet.");
			}
			return result;
		}

		public FT_STATUS Write(byte[] dataBuffer, int numBytesToWrite, ref uint numBytesWritten)
		{
			FT_STATUS result = FT_STATUS.FT_OTHER_ERROR;
			if (this.hFTD2XXDLL == IntPtr.Zero)
			{
				return result;
			}
			if (this.pFT_Write != IntPtr.Zero)
			{
				FTDI.tFT_Write tFT_Write = (FTDI.tFT_Write)Marshal.GetDelegateForFunctionPointer(this.pFT_Write, typeof(FTDI.tFT_Write));
				if (this.ftHandle != IntPtr.Zero)
				{
					result = tFT_Write(this.ftHandle, dataBuffer, (uint)numBytesToWrite, ref numBytesWritten);
				}
			}
			else if (this.pFT_Write == IntPtr.Zero)
			{
				Console.WriteLine("Failed to load function FT_Write.");
			}
			return result;
		}
		public FT_STATUS Write(byte[] dataBuffer, uint numBytesToWrite, ref uint numBytesWritten)
		{
			FT_STATUS result = FT_STATUS.FT_OTHER_ERROR;
			if (this.hFTD2XXDLL == IntPtr.Zero)
			{
				return result;
			}
			if (this.pFT_Write != IntPtr.Zero)
			{
				FTDI.tFT_Write tFT_Write = (FTDI.tFT_Write)Marshal.GetDelegateForFunctionPointer(this.pFT_Write, typeof(FTDI.tFT_Write));
				if (this.ftHandle != IntPtr.Zero)
				{
					result = tFT_Write(this.ftHandle, dataBuffer, numBytesToWrite, ref numBytesWritten);
				}
			}
			else if (this.pFT_Write == IntPtr.Zero)
			{
				Console.WriteLine("Failed to load function FT_Write.");
			}
			return result;
		}
		public FT_STATUS Write(string dataBuffer, int numBytesToWrite, ref uint numBytesWritten)
		{
			FT_STATUS result = FT_STATUS.FT_OTHER_ERROR;
			if (this.hFTD2XXDLL == IntPtr.Zero)
			{
				return result;
			}
			if (this.pFT_Write != IntPtr.Zero)
			{
				FTDI.tFT_Write tFT_Write = (FTDI.tFT_Write)Marshal.GetDelegateForFunctionPointer(this.pFT_Write, typeof(FTDI.tFT_Write));
				byte[] bytes = Encoding.ASCII.GetBytes(dataBuffer);
				if (this.ftHandle != IntPtr.Zero)
				{
					result = tFT_Write(this.ftHandle, bytes, (uint)numBytesToWrite, ref numBytesWritten);
				}
			}
			else if (this.pFT_Write == IntPtr.Zero)
			{
				Console.WriteLine("Failed to load function FT_Write.");
			}
			return result;
		}
		public FT_STATUS Write(string dataBuffer, uint numBytesToWrite, ref uint numBytesWritten)
		{
			FT_STATUS result = FT_STATUS.FT_OTHER_ERROR;
			if (this.hFTD2XXDLL == IntPtr.Zero)
			{
				return result;
			}
			if (this.pFT_Write != IntPtr.Zero)
			{
				FTDI.tFT_Write tFT_Write = (FTDI.tFT_Write)Marshal.GetDelegateForFunctionPointer(this.pFT_Write, typeof(FTDI.tFT_Write));
				byte[] bytes = Encoding.ASCII.GetBytes(dataBuffer);
				if (this.ftHandle != IntPtr.Zero)
				{
					result = tFT_Write(this.ftHandle, bytes, numBytesToWrite, ref numBytesWritten);
				}
			}
			else if (this.pFT_Write == IntPtr.Zero)
			{
				Console.WriteLine("Failed to load function FT_Write.");
			}
			return result;
		}
		public FT_STATUS WriteEEPROMLocation(uint Address, ushort EEValue)
		{
			FT_STATUS result = FT_STATUS.FT_OTHER_ERROR;
			if (this.hFTD2XXDLL == IntPtr.Zero)
			{
				return result;
			}
			if (this.pFT_WriteEE != IntPtr.Zero)
			{
				FTDI.tFT_WriteEE tFT_WriteEE = (FTDI.tFT_WriteEE)Marshal.GetDelegateForFunctionPointer(this.pFT_WriteEE, typeof(FTDI.tFT_WriteEE));
				if (this.ftHandle != IntPtr.Zero)
				{
					result = tFT_WriteEE(this.ftHandle, Address, EEValue);
				}
			}
			else if (this.pFT_WriteEE == IntPtr.Zero)
			{
				Console.WriteLine("Failed to load function FT_WriteEE.");
			}
			return result;
		}

		public FT_STATUS WriteFT2232EEPROM(FT2232_EEPROM_STRUCTURE ee2232)
		{
			FT_STATUS ft_STATUS = FT_STATUS.FT_OTHER_ERROR;
			if (this.hFTD2XXDLL == IntPtr.Zero)
			{
				return ft_STATUS;
			}
			if (this.pFT_EE_Program != IntPtr.Zero)
			{
				FTDI.tFT_EE_Program tFT_EE_Program = (FTDI.tFT_EE_Program)Marshal.GetDelegateForFunctionPointer(this.pFT_EE_Program, typeof(FTDI.tFT_EE_Program));
				if (this.ftHandle != IntPtr.Zero)
				{
					FT_DEVICE ft_DEVICE = FT_DEVICE.FT_DEVICE_UNKNOWN;
					this.GetDeviceType(ref ft_DEVICE);
					if (ft_DEVICE != FT_DEVICE.FT_DEVICE_2232)
					{
						FT_ERROR ftErrorCondition = FT_ERROR.FT_INCORRECT_DEVICE;
						this.ErrorHandler(ft_STATUS, ftErrorCondition);
					}
					if (ee2232.VendorID == 0 | ee2232.ProductID == 0)
					{
						return FT_STATUS.FT_INVALID_PARAMETER;
					}
					FT_PROGRAM_DATA ft_PROGRAM_DATA = new FT_PROGRAM_DATA();
					ft_PROGRAM_DATA.Signature1 = 0U;
					ft_PROGRAM_DATA.Signature2 = uint.MaxValue;
					ft_PROGRAM_DATA.Version = 2U;
					ft_PROGRAM_DATA.Manufacturer = Marshal.AllocHGlobal(32);
					ft_PROGRAM_DATA.ManufacturerID = Marshal.AllocHGlobal(16);
					ft_PROGRAM_DATA.Description = Marshal.AllocHGlobal(64);
					ft_PROGRAM_DATA.SerialNumber = Marshal.AllocHGlobal(16);
					if (ee2232.Manufacturer.Length > 32)
					{
						ee2232.Manufacturer = ee2232.Manufacturer.Substring(0, 32);
					}
					if (ee2232.ManufacturerID.Length > 16)
					{
						ee2232.ManufacturerID = ee2232.ManufacturerID.Substring(0, 16);
					}
					if (ee2232.Description.Length > 64)
					{
						ee2232.Description = ee2232.Description.Substring(0, 64);
					}
					if (ee2232.SerialNumber.Length > 16)
					{
						ee2232.SerialNumber = ee2232.SerialNumber.Substring(0, 16);
					}
					ft_PROGRAM_DATA.Manufacturer = Marshal.StringToHGlobalAnsi(ee2232.Manufacturer);
					ft_PROGRAM_DATA.ManufacturerID = Marshal.StringToHGlobalAnsi(ee2232.ManufacturerID);
					ft_PROGRAM_DATA.Description = Marshal.StringToHGlobalAnsi(ee2232.Description);
					ft_PROGRAM_DATA.SerialNumber = Marshal.StringToHGlobalAnsi(ee2232.SerialNumber);
					ft_PROGRAM_DATA.VendorID = ee2232.VendorID;
					ft_PROGRAM_DATA.ProductID = ee2232.ProductID;
					ft_PROGRAM_DATA.MaxPower = ee2232.MaxPower;
					ft_PROGRAM_DATA.SelfPowered = Convert.ToUInt16(ee2232.SelfPowered);
					ft_PROGRAM_DATA.RemoteWakeup = Convert.ToUInt16(ee2232.RemoteWakeup);
					ft_PROGRAM_DATA.Rev5 = Convert.ToByte(true);
					ft_PROGRAM_DATA.PullDownEnable5 = Convert.ToByte(ee2232.PullDownEnable);
					ft_PROGRAM_DATA.SerNumEnable5 = Convert.ToByte(ee2232.SerNumEnable);
					ft_PROGRAM_DATA.USBVersionEnable5 = Convert.ToByte(ee2232.USBVersionEnable);
					ft_PROGRAM_DATA.USBVersion5 = ee2232.USBVersion;
					ft_PROGRAM_DATA.AIsHighCurrent = Convert.ToByte(ee2232.AIsHighCurrent);
					ft_PROGRAM_DATA.BIsHighCurrent = Convert.ToByte(ee2232.BIsHighCurrent);
					ft_PROGRAM_DATA.IFAIsFifo = Convert.ToByte(ee2232.IFAIsFifo);
					ft_PROGRAM_DATA.IFAIsFifoTar = Convert.ToByte(ee2232.IFAIsFifoTar);
					ft_PROGRAM_DATA.IFAIsFastSer = Convert.ToByte(ee2232.IFAIsFastSer);
					ft_PROGRAM_DATA.AIsVCP = Convert.ToByte(ee2232.AIsVCP);
					ft_PROGRAM_DATA.IFBIsFifo = Convert.ToByte(ee2232.IFBIsFifo);
					ft_PROGRAM_DATA.IFBIsFifoTar = Convert.ToByte(ee2232.IFBIsFifoTar);
					ft_PROGRAM_DATA.IFBIsFastSer = Convert.ToByte(ee2232.IFBIsFastSer);
					ft_PROGRAM_DATA.BIsVCP = Convert.ToByte(ee2232.BIsVCP);
					ft_STATUS = tFT_EE_Program(this.ftHandle, ft_PROGRAM_DATA);
					Marshal.FreeHGlobal(ft_PROGRAM_DATA.Manufacturer);
					Marshal.FreeHGlobal(ft_PROGRAM_DATA.ManufacturerID);
					Marshal.FreeHGlobal(ft_PROGRAM_DATA.Description);
					Marshal.FreeHGlobal(ft_PROGRAM_DATA.SerialNumber);
				}
			}
			else if (this.pFT_EE_Program == IntPtr.Zero)
			{
				Console.WriteLine("Failed to load function FT_EE_Program.");
			}
			return ft_STATUS;
		}
		public FT_STATUS WriteFT2232HEEPROM(FT2232H_EEPROM_STRUCTURE ee2232h)
		{
			FT_STATUS ft_STATUS = FT_STATUS.FT_OTHER_ERROR;
			if (this.hFTD2XXDLL == IntPtr.Zero)
			{
				return ft_STATUS;
			}
			if (this.pFT_EE_Program != IntPtr.Zero)
			{
				FTDI.tFT_EE_Program tFT_EE_Program = (FTDI.tFT_EE_Program)Marshal.GetDelegateForFunctionPointer(this.pFT_EE_Program, typeof(FTDI.tFT_EE_Program));
				if (this.ftHandle != IntPtr.Zero)
				{
					FT_DEVICE ft_DEVICE = FT_DEVICE.FT_DEVICE_UNKNOWN;
					this.GetDeviceType(ref ft_DEVICE);
					if (ft_DEVICE != FT_DEVICE.FT_DEVICE_2232H)
					{
						FT_ERROR ftErrorCondition = FT_ERROR.FT_INCORRECT_DEVICE;
						this.ErrorHandler(ft_STATUS, ftErrorCondition);
					}
					if (ee2232h.VendorID == 0 | ee2232h.ProductID == 0)
					{
						return FT_STATUS.FT_INVALID_PARAMETER;
					}
					FT_PROGRAM_DATA ft_PROGRAM_DATA = new FT_PROGRAM_DATA();
					ft_PROGRAM_DATA.Signature1 = 0U;
					ft_PROGRAM_DATA.Signature2 = uint.MaxValue;
					ft_PROGRAM_DATA.Version = 3U;
					ft_PROGRAM_DATA.Manufacturer = Marshal.AllocHGlobal(32);
					ft_PROGRAM_DATA.ManufacturerID = Marshal.AllocHGlobal(16);
					ft_PROGRAM_DATA.Description = Marshal.AllocHGlobal(64);
					ft_PROGRAM_DATA.SerialNumber = Marshal.AllocHGlobal(16);
					if (ee2232h.Manufacturer.Length > 32)
					{
						ee2232h.Manufacturer = ee2232h.Manufacturer.Substring(0, 32);
					}
					if (ee2232h.ManufacturerID.Length > 16)
					{
						ee2232h.ManufacturerID = ee2232h.ManufacturerID.Substring(0, 16);
					}
					if (ee2232h.Description.Length > 64)
					{
						ee2232h.Description = ee2232h.Description.Substring(0, 64);
					}
					if (ee2232h.SerialNumber.Length > 16)
					{
						ee2232h.SerialNumber = ee2232h.SerialNumber.Substring(0, 16);
					}
					ft_PROGRAM_DATA.Manufacturer = Marshal.StringToHGlobalAnsi(ee2232h.Manufacturer);
					ft_PROGRAM_DATA.ManufacturerID = Marshal.StringToHGlobalAnsi(ee2232h.ManufacturerID);
					ft_PROGRAM_DATA.Description = Marshal.StringToHGlobalAnsi(ee2232h.Description);
					ft_PROGRAM_DATA.SerialNumber = Marshal.StringToHGlobalAnsi(ee2232h.SerialNumber);
					ft_PROGRAM_DATA.VendorID = ee2232h.VendorID;
					ft_PROGRAM_DATA.ProductID = ee2232h.ProductID;
					ft_PROGRAM_DATA.MaxPower = ee2232h.MaxPower;
					ft_PROGRAM_DATA.SelfPowered = Convert.ToUInt16(ee2232h.SelfPowered);
					ft_PROGRAM_DATA.RemoteWakeup = Convert.ToUInt16(ee2232h.RemoteWakeup);
					ft_PROGRAM_DATA.PullDownEnable7 = Convert.ToByte(ee2232h.PullDownEnable);
					ft_PROGRAM_DATA.SerNumEnable7 = Convert.ToByte(ee2232h.SerNumEnable);
					ft_PROGRAM_DATA.ALSlowSlew = Convert.ToByte(ee2232h.ALSlowSlew);
					ft_PROGRAM_DATA.ALSchmittInput = Convert.ToByte(ee2232h.ALSchmittInput);
					ft_PROGRAM_DATA.ALDriveCurrent = ee2232h.ALDriveCurrent;
					ft_PROGRAM_DATA.AHSlowSlew = Convert.ToByte(ee2232h.AHSlowSlew);
					ft_PROGRAM_DATA.AHSchmittInput = Convert.ToByte(ee2232h.AHSchmittInput);
					ft_PROGRAM_DATA.AHDriveCurrent = ee2232h.AHDriveCurrent;
					ft_PROGRAM_DATA.BLSlowSlew = Convert.ToByte(ee2232h.BLSlowSlew);
					ft_PROGRAM_DATA.BLSchmittInput = Convert.ToByte(ee2232h.BLSchmittInput);
					ft_PROGRAM_DATA.BLDriveCurrent = ee2232h.BLDriveCurrent;
					ft_PROGRAM_DATA.BHSlowSlew = Convert.ToByte(ee2232h.BHSlowSlew);
					ft_PROGRAM_DATA.BHSchmittInput = Convert.ToByte(ee2232h.BHSchmittInput);
					ft_PROGRAM_DATA.BHDriveCurrent = ee2232h.BHDriveCurrent;
					ft_PROGRAM_DATA.IFAIsFifo7 = Convert.ToByte(ee2232h.IFAIsFifo);
					ft_PROGRAM_DATA.IFAIsFifoTar7 = Convert.ToByte(ee2232h.IFAIsFifoTar);
					ft_PROGRAM_DATA.IFAIsFastSer7 = Convert.ToByte(ee2232h.IFAIsFastSer);
					ft_PROGRAM_DATA.AIsVCP7 = Convert.ToByte(ee2232h.AIsVCP);
					ft_PROGRAM_DATA.IFBIsFifo7 = Convert.ToByte(ee2232h.IFBIsFifo);
					ft_PROGRAM_DATA.IFBIsFifoTar7 = Convert.ToByte(ee2232h.IFBIsFifoTar);
					ft_PROGRAM_DATA.IFBIsFastSer7 = Convert.ToByte(ee2232h.IFBIsFastSer);
					ft_PROGRAM_DATA.BIsVCP7 = Convert.ToByte(ee2232h.BIsVCP);
					ft_PROGRAM_DATA.PowerSaveEnable = Convert.ToByte(ee2232h.PowerSaveEnable);
					ft_STATUS = tFT_EE_Program(this.ftHandle, ft_PROGRAM_DATA);
					Marshal.FreeHGlobal(ft_PROGRAM_DATA.Manufacturer);
					Marshal.FreeHGlobal(ft_PROGRAM_DATA.ManufacturerID);
					Marshal.FreeHGlobal(ft_PROGRAM_DATA.Description);
					Marshal.FreeHGlobal(ft_PROGRAM_DATA.SerialNumber);
				}
			}
			else if (this.pFT_EE_Program == IntPtr.Zero)
			{
				Console.WriteLine("Failed to load function FT_EE_Program.");
			}
			return ft_STATUS;
		}

		public FT_STATUS WriteFT232BEEPROM(FT232B_EEPROM_STRUCTURE ee232b)
		{
			FT_STATUS ft_STATUS = FT_STATUS.FT_OTHER_ERROR;
			if (this.hFTD2XXDLL == IntPtr.Zero)
			{
				return ft_STATUS;
			}
			if (this.pFT_EE_Program != IntPtr.Zero)
			{
				FTDI.tFT_EE_Program tFT_EE_Program = (FTDI.tFT_EE_Program)Marshal.GetDelegateForFunctionPointer(this.pFT_EE_Program, typeof(FTDI.tFT_EE_Program));
				if (this.ftHandle != IntPtr.Zero)
				{
					FT_DEVICE ft_DEVICE = FT_DEVICE.FT_DEVICE_UNKNOWN;
					this.GetDeviceType(ref ft_DEVICE);
					if (ft_DEVICE != FT_DEVICE.FT_DEVICE_BM)
					{
						FT_ERROR ftErrorCondition = FT_ERROR.FT_INCORRECT_DEVICE;
						this.ErrorHandler(ft_STATUS, ftErrorCondition);
					}
					if (ee232b.VendorID == 0 | ee232b.ProductID == 0)
					{
						return FT_STATUS.FT_INVALID_PARAMETER;
					}
					FT_PROGRAM_DATA ft_PROGRAM_DATA = new FT_PROGRAM_DATA();
					ft_PROGRAM_DATA.Signature1 = 0U;
					ft_PROGRAM_DATA.Signature2 = uint.MaxValue;
					ft_PROGRAM_DATA.Version = 2U;
					ft_PROGRAM_DATA.Manufacturer = Marshal.AllocHGlobal(32);
					ft_PROGRAM_DATA.ManufacturerID = Marshal.AllocHGlobal(16);
					ft_PROGRAM_DATA.Description = Marshal.AllocHGlobal(64);
					ft_PROGRAM_DATA.SerialNumber = Marshal.AllocHGlobal(16);
					if (ee232b.Manufacturer.Length > 32)
					{
						ee232b.Manufacturer = ee232b.Manufacturer.Substring(0, 32);
					}
					if (ee232b.ManufacturerID.Length > 16)
					{
						ee232b.ManufacturerID = ee232b.ManufacturerID.Substring(0, 16);
					}
					if (ee232b.Description.Length > 64)
					{
						ee232b.Description = ee232b.Description.Substring(0, 64);
					}
					if (ee232b.SerialNumber.Length > 16)
					{
						ee232b.SerialNumber = ee232b.SerialNumber.Substring(0, 16);
					}
					ft_PROGRAM_DATA.Manufacturer = Marshal.StringToHGlobalAnsi(ee232b.Manufacturer);
					ft_PROGRAM_DATA.ManufacturerID = Marshal.StringToHGlobalAnsi(ee232b.ManufacturerID);
					ft_PROGRAM_DATA.Description = Marshal.StringToHGlobalAnsi(ee232b.Description);
					ft_PROGRAM_DATA.SerialNumber = Marshal.StringToHGlobalAnsi(ee232b.SerialNumber);
					ft_PROGRAM_DATA.VendorID = ee232b.VendorID;
					ft_PROGRAM_DATA.ProductID = ee232b.ProductID;
					ft_PROGRAM_DATA.MaxPower = ee232b.MaxPower;
					ft_PROGRAM_DATA.SelfPowered = Convert.ToUInt16(ee232b.SelfPowered);
					ft_PROGRAM_DATA.RemoteWakeup = Convert.ToUInt16(ee232b.RemoteWakeup);
					ft_PROGRAM_DATA.Rev4 = Convert.ToByte(true);
					ft_PROGRAM_DATA.PullDownEnable = Convert.ToByte(ee232b.PullDownEnable);
					ft_PROGRAM_DATA.SerNumEnable = Convert.ToByte(ee232b.SerNumEnable);
					ft_PROGRAM_DATA.USBVersionEnable = Convert.ToByte(ee232b.USBVersionEnable);
					ft_PROGRAM_DATA.USBVersion = ee232b.USBVersion;
					ft_STATUS = tFT_EE_Program(this.ftHandle, ft_PROGRAM_DATA);
					Marshal.FreeHGlobal(ft_PROGRAM_DATA.Manufacturer);
					Marshal.FreeHGlobal(ft_PROGRAM_DATA.ManufacturerID);
					Marshal.FreeHGlobal(ft_PROGRAM_DATA.Description);
					Marshal.FreeHGlobal(ft_PROGRAM_DATA.SerialNumber);
				}
			}
			else if (this.pFT_EE_Program == IntPtr.Zero)
			{
				Console.WriteLine("Failed to load function FT_EE_Program.");
			}
			return ft_STATUS;
		}

		public FT_STATUS WriteFT232HEEPROM(FT232H_EEPROM_STRUCTURE ee232h)
		{
			FT_STATUS ft_STATUS = FT_STATUS.FT_OTHER_ERROR;
			if (this.hFTD2XXDLL == IntPtr.Zero)
			{
				return ft_STATUS;
			}
			if (this.pFT_EE_Program != IntPtr.Zero)
			{
				FTDI.tFT_EE_Program tFT_EE_Program = (FTDI.tFT_EE_Program)Marshal.GetDelegateForFunctionPointer(this.pFT_EE_Program, typeof(FTDI.tFT_EE_Program));
				if (this.ftHandle != IntPtr.Zero)
				{
					FT_DEVICE ft_DEVICE = FT_DEVICE.FT_DEVICE_UNKNOWN;
					this.GetDeviceType(ref ft_DEVICE);
					if (ft_DEVICE != FT_DEVICE.FT_DEVICE_232H)
					{
						FT_ERROR ftErrorCondition = FT_ERROR.FT_INCORRECT_DEVICE;
						this.ErrorHandler(ft_STATUS, ftErrorCondition);
					}
					if (ee232h.VendorID == 0 | ee232h.ProductID == 0)
					{
						return FT_STATUS.FT_INVALID_PARAMETER;
					}
					FT_PROGRAM_DATA ft_PROGRAM_DATA = new FT_PROGRAM_DATA();
					ft_PROGRAM_DATA.Signature1 = 0U;
					ft_PROGRAM_DATA.Signature2 = uint.MaxValue;
					ft_PROGRAM_DATA.Version = 5U;
					ft_PROGRAM_DATA.Manufacturer = Marshal.AllocHGlobal(32);
					ft_PROGRAM_DATA.ManufacturerID = Marshal.AllocHGlobal(16);
					ft_PROGRAM_DATA.Description = Marshal.AllocHGlobal(64);
					ft_PROGRAM_DATA.SerialNumber = Marshal.AllocHGlobal(16);
					if (ee232h.Manufacturer.Length > 32)
					{
						ee232h.Manufacturer = ee232h.Manufacturer.Substring(0, 32);
					}
					if (ee232h.ManufacturerID.Length > 16)
					{
						ee232h.ManufacturerID = ee232h.ManufacturerID.Substring(0, 16);
					}
					if (ee232h.Description.Length > 64)
					{
						ee232h.Description = ee232h.Description.Substring(0, 64);
					}
					if (ee232h.SerialNumber.Length > 16)
					{
						ee232h.SerialNumber = ee232h.SerialNumber.Substring(0, 16);
					}
					ft_PROGRAM_DATA.Manufacturer = Marshal.StringToHGlobalAnsi(ee232h.Manufacturer);
					ft_PROGRAM_DATA.ManufacturerID = Marshal.StringToHGlobalAnsi(ee232h.ManufacturerID);
					ft_PROGRAM_DATA.Description = Marshal.StringToHGlobalAnsi(ee232h.Description);
					ft_PROGRAM_DATA.SerialNumber = Marshal.StringToHGlobalAnsi(ee232h.SerialNumber);
					ft_PROGRAM_DATA.VendorID = ee232h.VendorID;
					ft_PROGRAM_DATA.ProductID = ee232h.ProductID;
					ft_PROGRAM_DATA.MaxPower = ee232h.MaxPower;
					ft_PROGRAM_DATA.SelfPowered = Convert.ToUInt16(ee232h.SelfPowered);
					ft_PROGRAM_DATA.RemoteWakeup = Convert.ToUInt16(ee232h.RemoteWakeup);
					ft_PROGRAM_DATA.PullDownEnableH = Convert.ToByte(ee232h.PullDownEnable);
					ft_PROGRAM_DATA.SerNumEnableH = Convert.ToByte(ee232h.SerNumEnable);
					ft_PROGRAM_DATA.ACSlowSlewH = Convert.ToByte(ee232h.ACSlowSlew);
					ft_PROGRAM_DATA.ACSchmittInputH = Convert.ToByte(ee232h.ACSchmittInput);
					ft_PROGRAM_DATA.ACDriveCurrentH = Convert.ToByte(ee232h.ACDriveCurrent);
					ft_PROGRAM_DATA.ADSlowSlewH = Convert.ToByte(ee232h.ADSlowSlew);
					ft_PROGRAM_DATA.ADSchmittInputH = Convert.ToByte(ee232h.ADSchmittInput);
					ft_PROGRAM_DATA.ADDriveCurrentH = Convert.ToByte(ee232h.ADDriveCurrent);
					ft_PROGRAM_DATA.Cbus0H = Convert.ToByte(ee232h.Cbus0);
					ft_PROGRAM_DATA.Cbus1H = Convert.ToByte(ee232h.Cbus1);
					ft_PROGRAM_DATA.Cbus2H = Convert.ToByte(ee232h.Cbus2);
					ft_PROGRAM_DATA.Cbus3H = Convert.ToByte(ee232h.Cbus3);
					ft_PROGRAM_DATA.Cbus4H = Convert.ToByte(ee232h.Cbus4);
					ft_PROGRAM_DATA.Cbus5H = Convert.ToByte(ee232h.Cbus5);
					ft_PROGRAM_DATA.Cbus6H = Convert.ToByte(ee232h.Cbus6);
					ft_PROGRAM_DATA.Cbus7H = Convert.ToByte(ee232h.Cbus7);
					ft_PROGRAM_DATA.Cbus8H = Convert.ToByte(ee232h.Cbus8);
					ft_PROGRAM_DATA.Cbus9H = Convert.ToByte(ee232h.Cbus9);
					ft_PROGRAM_DATA.IsFifoH = Convert.ToByte(ee232h.IsFifo);
					ft_PROGRAM_DATA.IsFifoTarH = Convert.ToByte(ee232h.IsFifoTar);
					ft_PROGRAM_DATA.IsFastSerH = Convert.ToByte(ee232h.IsFastSer);
					ft_PROGRAM_DATA.IsFT1248H = Convert.ToByte(ee232h.IsFT1248);
					ft_PROGRAM_DATA.FT1248CpolH = Convert.ToByte(ee232h.FT1248Cpol);
					ft_PROGRAM_DATA.FT1248LsbH = Convert.ToByte(ee232h.FT1248Lsb);
					ft_PROGRAM_DATA.FT1248FlowControlH = Convert.ToByte(ee232h.FT1248FlowControl);
					ft_PROGRAM_DATA.IsVCPH = Convert.ToByte(ee232h.IsVCP);
					ft_PROGRAM_DATA.PowerSaveEnableH = Convert.ToByte(ee232h.PowerSaveEnable);
					ft_STATUS = tFT_EE_Program(this.ftHandle, ft_PROGRAM_DATA);
					Marshal.FreeHGlobal(ft_PROGRAM_DATA.Manufacturer);
					Marshal.FreeHGlobal(ft_PROGRAM_DATA.ManufacturerID);
					Marshal.FreeHGlobal(ft_PROGRAM_DATA.Description);
					Marshal.FreeHGlobal(ft_PROGRAM_DATA.SerialNumber);
				}
			}
			else if (this.pFT_EE_Program == IntPtr.Zero)
			{
				Console.WriteLine("Failed to load function FT_EE_Program.");
			}
			return ft_STATUS;
		}

		public FT_STATUS WriteFT232REEPROM(FT232R_EEPROM_STRUCTURE ee232r)
		{
			FT_STATUS ft_STATUS = FT_STATUS.FT_OTHER_ERROR;
			if (this.hFTD2XXDLL == IntPtr.Zero)
			{
				return ft_STATUS;
			}
			if (this.pFT_EE_Program != IntPtr.Zero)
			{
				FTDI.tFT_EE_Program tFT_EE_Program = (FTDI.tFT_EE_Program)Marshal.GetDelegateForFunctionPointer(this.pFT_EE_Program, typeof(FTDI.tFT_EE_Program));
				if (this.ftHandle != IntPtr.Zero)
				{
					FT_DEVICE ft_DEVICE = FT_DEVICE.FT_DEVICE_UNKNOWN;
					this.GetDeviceType(ref ft_DEVICE);
					if (ft_DEVICE != FT_DEVICE.FT_DEVICE_232R)
					{
						FT_ERROR ftErrorCondition = FT_ERROR.FT_INCORRECT_DEVICE;
						this.ErrorHandler(ft_STATUS, ftErrorCondition);
					}
					if (ee232r.VendorID == 0 | ee232r.ProductID == 0)
					{
						return FT_STATUS.FT_INVALID_PARAMETER;
					}
					FT_PROGRAM_DATA ft_PROGRAM_DATA = new FT_PROGRAM_DATA();
					ft_PROGRAM_DATA.Signature1 = 0U;
					ft_PROGRAM_DATA.Signature2 = uint.MaxValue;
					ft_PROGRAM_DATA.Version = 2U;
					ft_PROGRAM_DATA.Manufacturer = Marshal.AllocHGlobal(32);
					ft_PROGRAM_DATA.ManufacturerID = Marshal.AllocHGlobal(16);
					ft_PROGRAM_DATA.Description = Marshal.AllocHGlobal(64);
					ft_PROGRAM_DATA.SerialNumber = Marshal.AllocHGlobal(16);
					if (ee232r.Manufacturer.Length > 32)
					{
						ee232r.Manufacturer = ee232r.Manufacturer.Substring(0, 32);
					}
					if (ee232r.ManufacturerID.Length > 16)
					{
						ee232r.ManufacturerID = ee232r.ManufacturerID.Substring(0, 16);
					}
					if (ee232r.Description.Length > 64)
					{
						ee232r.Description = ee232r.Description.Substring(0, 64);
					}
					if (ee232r.SerialNumber.Length > 16)
					{
						ee232r.SerialNumber = ee232r.SerialNumber.Substring(0, 16);
					}
					ft_PROGRAM_DATA.Manufacturer = Marshal.StringToHGlobalAnsi(ee232r.Manufacturer);
					ft_PROGRAM_DATA.ManufacturerID = Marshal.StringToHGlobalAnsi(ee232r.ManufacturerID);
					ft_PROGRAM_DATA.Description = Marshal.StringToHGlobalAnsi(ee232r.Description);
					ft_PROGRAM_DATA.SerialNumber = Marshal.StringToHGlobalAnsi(ee232r.SerialNumber);
					ft_PROGRAM_DATA.VendorID = ee232r.VendorID;
					ft_PROGRAM_DATA.ProductID = ee232r.ProductID;
					ft_PROGRAM_DATA.MaxPower = ee232r.MaxPower;
					ft_PROGRAM_DATA.SelfPowered = Convert.ToUInt16(ee232r.SelfPowered);
					ft_PROGRAM_DATA.RemoteWakeup = Convert.ToUInt16(ee232r.RemoteWakeup);
					ft_PROGRAM_DATA.PullDownEnableR = Convert.ToByte(ee232r.PullDownEnable);
					ft_PROGRAM_DATA.SerNumEnableR = Convert.ToByte(ee232r.SerNumEnable);
					ft_PROGRAM_DATA.UseExtOsc = Convert.ToByte(ee232r.UseExtOsc);
					ft_PROGRAM_DATA.HighDriveIOs = Convert.ToByte(ee232r.HighDriveIOs);
					ft_PROGRAM_DATA.EndpointSize = 64;
					ft_PROGRAM_DATA.PullDownEnableR = Convert.ToByte(ee232r.PullDownEnable);
					ft_PROGRAM_DATA.SerNumEnableR = Convert.ToByte(ee232r.SerNumEnable);
					ft_PROGRAM_DATA.InvertTXD = Convert.ToByte(ee232r.InvertTXD);
					ft_PROGRAM_DATA.InvertRXD = Convert.ToByte(ee232r.InvertRXD);
					ft_PROGRAM_DATA.InvertRTS = Convert.ToByte(ee232r.InvertRTS);
					ft_PROGRAM_DATA.InvertCTS = Convert.ToByte(ee232r.InvertCTS);
					ft_PROGRAM_DATA.InvertDTR = Convert.ToByte(ee232r.InvertDTR);
					ft_PROGRAM_DATA.InvertDSR = Convert.ToByte(ee232r.InvertDSR);
					ft_PROGRAM_DATA.InvertDCD = Convert.ToByte(ee232r.InvertDCD);
					ft_PROGRAM_DATA.InvertRI = Convert.ToByte(ee232r.InvertRI);
					ft_PROGRAM_DATA.Cbus0 = ee232r.Cbus0;
					ft_PROGRAM_DATA.Cbus1 = ee232r.Cbus1;
					ft_PROGRAM_DATA.Cbus2 = ee232r.Cbus2;
					ft_PROGRAM_DATA.Cbus3 = ee232r.Cbus3;
					ft_PROGRAM_DATA.Cbus4 = ee232r.Cbus4;
					ft_PROGRAM_DATA.RIsD2XX = Convert.ToByte(ee232r.RIsD2XX);
					ft_STATUS = tFT_EE_Program(this.ftHandle, ft_PROGRAM_DATA);
					Marshal.FreeHGlobal(ft_PROGRAM_DATA.Manufacturer);
					Marshal.FreeHGlobal(ft_PROGRAM_DATA.ManufacturerID);
					Marshal.FreeHGlobal(ft_PROGRAM_DATA.Description);
					Marshal.FreeHGlobal(ft_PROGRAM_DATA.SerialNumber);
				}
			}
			else if (this.pFT_EE_Program == IntPtr.Zero)
			{
				Console.WriteLine("Failed to load function FT_EE_Program.");
			}
			return ft_STATUS;
		}

		public FT_STATUS WriteFT4232HEEPROM(FT4232H_EEPROM_STRUCTURE ee4232h)
		{
			FT_STATUS ft_STATUS = FT_STATUS.FT_OTHER_ERROR;
			if (this.hFTD2XXDLL == IntPtr.Zero)
			{
				return ft_STATUS;
			}
			if (this.pFT_EE_Program != IntPtr.Zero)
			{
				FTDI.tFT_EE_Program tFT_EE_Program = (FTDI.tFT_EE_Program)Marshal.GetDelegateForFunctionPointer(this.pFT_EE_Program, typeof(FTDI.tFT_EE_Program));
				if (this.ftHandle != IntPtr.Zero)
				{
					FT_DEVICE ft_DEVICE = FT_DEVICE.FT_DEVICE_UNKNOWN;
					this.GetDeviceType(ref ft_DEVICE);
					if (ft_DEVICE != FT_DEVICE.FT_DEVICE_4232H)
					{
						FT_ERROR ftErrorCondition = FT_ERROR.FT_INCORRECT_DEVICE;
						this.ErrorHandler(ft_STATUS, ftErrorCondition);
					}
					if (ee4232h.VendorID == 0 | ee4232h.ProductID == 0)
					{
						return FT_STATUS.FT_INVALID_PARAMETER;
					}
					FT_PROGRAM_DATA ft_PROGRAM_DATA = new FT_PROGRAM_DATA();
					ft_PROGRAM_DATA.Signature1 = 0U;
					ft_PROGRAM_DATA.Signature2 = uint.MaxValue;
					ft_PROGRAM_DATA.Version = 4U;
					ft_PROGRAM_DATA.Manufacturer = Marshal.AllocHGlobal(32);
					ft_PROGRAM_DATA.ManufacturerID = Marshal.AllocHGlobal(16);
					ft_PROGRAM_DATA.Description = Marshal.AllocHGlobal(64);
					ft_PROGRAM_DATA.SerialNumber = Marshal.AllocHGlobal(16);
					if (ee4232h.Manufacturer.Length > 32)
					{
						ee4232h.Manufacturer = ee4232h.Manufacturer.Substring(0, 32);
					}
					if (ee4232h.ManufacturerID.Length > 16)
					{
						ee4232h.ManufacturerID = ee4232h.ManufacturerID.Substring(0, 16);
					}
					if (ee4232h.Description.Length > 64)
					{
						ee4232h.Description = ee4232h.Description.Substring(0, 64);
					}
					if (ee4232h.SerialNumber.Length > 16)
					{
						ee4232h.SerialNumber = ee4232h.SerialNumber.Substring(0, 16);
					}
					ft_PROGRAM_DATA.Manufacturer = Marshal.StringToHGlobalAnsi(ee4232h.Manufacturer);
					ft_PROGRAM_DATA.ManufacturerID = Marshal.StringToHGlobalAnsi(ee4232h.ManufacturerID);
					ft_PROGRAM_DATA.Description = Marshal.StringToHGlobalAnsi(ee4232h.Description);
					ft_PROGRAM_DATA.SerialNumber = Marshal.StringToHGlobalAnsi(ee4232h.SerialNumber);
					ft_PROGRAM_DATA.VendorID = ee4232h.VendorID;
					ft_PROGRAM_DATA.ProductID = ee4232h.ProductID;
					ft_PROGRAM_DATA.MaxPower = ee4232h.MaxPower;
					ft_PROGRAM_DATA.SelfPowered = Convert.ToUInt16(ee4232h.SelfPowered);
					ft_PROGRAM_DATA.RemoteWakeup = Convert.ToUInt16(ee4232h.RemoteWakeup);
					ft_PROGRAM_DATA.PullDownEnable8 = Convert.ToByte(ee4232h.PullDownEnable);
					ft_PROGRAM_DATA.SerNumEnable8 = Convert.ToByte(ee4232h.SerNumEnable);
					ft_PROGRAM_DATA.ASlowSlew = Convert.ToByte(ee4232h.ASlowSlew);
					ft_PROGRAM_DATA.ASchmittInput = Convert.ToByte(ee4232h.ASchmittInput);
					ft_PROGRAM_DATA.ADriveCurrent = ee4232h.ADriveCurrent;
					ft_PROGRAM_DATA.BSlowSlew = Convert.ToByte(ee4232h.BSlowSlew);
					ft_PROGRAM_DATA.BSchmittInput = Convert.ToByte(ee4232h.BSchmittInput);
					ft_PROGRAM_DATA.BDriveCurrent = ee4232h.BDriveCurrent;
					ft_PROGRAM_DATA.CSlowSlew = Convert.ToByte(ee4232h.CSlowSlew);
					ft_PROGRAM_DATA.CSchmittInput = Convert.ToByte(ee4232h.CSchmittInput);
					ft_PROGRAM_DATA.CDriveCurrent = ee4232h.CDriveCurrent;
					ft_PROGRAM_DATA.DSlowSlew = Convert.ToByte(ee4232h.DSlowSlew);
					ft_PROGRAM_DATA.DSchmittInput = Convert.ToByte(ee4232h.DSchmittInput);
					ft_PROGRAM_DATA.DDriveCurrent = ee4232h.DDriveCurrent;
					ft_PROGRAM_DATA.ARIIsTXDEN = Convert.ToByte(ee4232h.ARIIsTXDEN);
					ft_PROGRAM_DATA.BRIIsTXDEN = Convert.ToByte(ee4232h.BRIIsTXDEN);
					ft_PROGRAM_DATA.CRIIsTXDEN = Convert.ToByte(ee4232h.CRIIsTXDEN);
					ft_PROGRAM_DATA.DRIIsTXDEN = Convert.ToByte(ee4232h.DRIIsTXDEN);
					ft_PROGRAM_DATA.AIsVCP8 = Convert.ToByte(ee4232h.AIsVCP);
					ft_PROGRAM_DATA.BIsVCP8 = Convert.ToByte(ee4232h.BIsVCP);
					ft_PROGRAM_DATA.CIsVCP8 = Convert.ToByte(ee4232h.CIsVCP);
					ft_PROGRAM_DATA.DIsVCP8 = Convert.ToByte(ee4232h.DIsVCP);
					ft_STATUS = tFT_EE_Program(this.ftHandle, ft_PROGRAM_DATA);
					Marshal.FreeHGlobal(ft_PROGRAM_DATA.Manufacturer);
					Marshal.FreeHGlobal(ft_PROGRAM_DATA.ManufacturerID);
					Marshal.FreeHGlobal(ft_PROGRAM_DATA.Description);
					Marshal.FreeHGlobal(ft_PROGRAM_DATA.SerialNumber);
				}
			}
			else if (this.pFT_EE_Program == IntPtr.Zero)
			{
				Console.WriteLine("Failed to load function FT_EE_Program.");
			}
			return ft_STATUS;
		}

		public FT_STATUS WriteXSeriesEEPROM(FT_XSERIES_EEPROM_STRUCTURE eeX)
		{
			FT_STATUS ft_STATUS = FT_STATUS.FT_OTHER_ERROR;
			if (this.hFTD2XXDLL == IntPtr.Zero)
			{
				return ft_STATUS;
			}
			if (this.pFT_EEPROM_Program != IntPtr.Zero)
			{
				FTDI.tFT_EEPROM_Program tFT_EEPROM_Program = (FTDI.tFT_EEPROM_Program)Marshal.GetDelegateForFunctionPointer(this.pFT_EEPROM_Program, typeof(FTDI.tFT_EEPROM_Program));
				if (this.ftHandle != IntPtr.Zero)
				{
					FT_DEVICE ft_DEVICE = FT_DEVICE.FT_DEVICE_UNKNOWN;
					this.GetDeviceType(ref ft_DEVICE);
					if (ft_DEVICE != FT_DEVICE.FT_DEVICE_X_SERIES)
					{
						FT_ERROR ftErrorCondition = FT_ERROR.FT_INCORRECT_DEVICE;
						this.ErrorHandler(ft_STATUS, ftErrorCondition);
					}
					if (eeX.VendorID == 0 | eeX.ProductID == 0)
					{
						return FT_STATUS.FT_INVALID_PARAMETER;
					}
					FT_XSERIES_DATA ft_XSERIES_DATA = default(FT_XSERIES_DATA);
					byte[] manufacturer = new byte[32];
					byte[] manufacturerID = new byte[16];
					byte[] description = new byte[64];
					byte[] serialnumber = new byte[16];
					if (eeX.Manufacturer.Length > 32)
					{
						eeX.Manufacturer = eeX.Manufacturer.Substring(0, 32);
					}
					if (eeX.ManufacturerID.Length > 16)
					{
						eeX.ManufacturerID = eeX.ManufacturerID.Substring(0, 16);
					}
					if (eeX.Description.Length > 64)
					{
						eeX.Description = eeX.Description.Substring(0, 64);
					}
					if (eeX.SerialNumber.Length > 16)
					{
						eeX.SerialNumber = eeX.SerialNumber.Substring(0, 16);
					}
					UTF8Encoding utf8Encoding = new UTF8Encoding();
					manufacturer = utf8Encoding.GetBytes(eeX.Manufacturer);
					manufacturerID = utf8Encoding.GetBytes(eeX.ManufacturerID);
					description = utf8Encoding.GetBytes(eeX.Description);
					serialnumber = utf8Encoding.GetBytes(eeX.SerialNumber);
					ft_XSERIES_DATA.common.deviceType = 9U;
					ft_XSERIES_DATA.common.VendorId = eeX.VendorID;
					ft_XSERIES_DATA.common.ProductId = eeX.ProductID;
					ft_XSERIES_DATA.common.MaxPower = eeX.MaxPower;
					ft_XSERIES_DATA.common.SelfPowered = Convert.ToByte(eeX.SelfPowered);
					ft_XSERIES_DATA.common.RemoteWakeup = Convert.ToByte(eeX.RemoteWakeup);
					ft_XSERIES_DATA.common.SerNumEnable = Convert.ToByte(eeX.SerNumEnable);
					ft_XSERIES_DATA.common.PullDownEnable = Convert.ToByte(eeX.PullDownEnable);
					ft_XSERIES_DATA.Cbus0 = eeX.Cbus0;
					ft_XSERIES_DATA.Cbus1 = eeX.Cbus1;
					ft_XSERIES_DATA.Cbus2 = eeX.Cbus2;
					ft_XSERIES_DATA.Cbus3 = eeX.Cbus3;
					ft_XSERIES_DATA.Cbus4 = eeX.Cbus4;
					ft_XSERIES_DATA.Cbus5 = eeX.Cbus5;
					ft_XSERIES_DATA.Cbus6 = eeX.Cbus6;
					ft_XSERIES_DATA.ACDriveCurrent = eeX.ACDriveCurrent;
					ft_XSERIES_DATA.ACSchmittInput = eeX.ACSchmittInput;
					ft_XSERIES_DATA.ACSlowSlew = eeX.ACSlowSlew;
					ft_XSERIES_DATA.ADDriveCurrent = eeX.ADDriveCurrent;
					ft_XSERIES_DATA.ADSchmittInput = eeX.ADSchmittInput;
					ft_XSERIES_DATA.ADSlowSlew = eeX.ADSlowSlew;
					ft_XSERIES_DATA.BCDDisableSleep = eeX.BCDDisableSleep;
					ft_XSERIES_DATA.BCDEnable = eeX.BCDEnable;
					ft_XSERIES_DATA.BCDForceCbusPWREN = eeX.BCDForceCbusPWREN;
					ft_XSERIES_DATA.FT1248Cpol = eeX.FT1248Cpol;
					ft_XSERIES_DATA.FT1248FlowControl = eeX.FT1248FlowControl;
					ft_XSERIES_DATA.FT1248Lsb = eeX.FT1248Lsb;
					ft_XSERIES_DATA.I2CDeviceId = eeX.I2CDeviceId;
					ft_XSERIES_DATA.I2CDisableSchmitt = eeX.I2CDisableSchmitt;
					ft_XSERIES_DATA.I2CSlaveAddress = eeX.I2CSlaveAddress;
					ft_XSERIES_DATA.InvertCTS = eeX.InvertCTS;
					ft_XSERIES_DATA.InvertDCD = eeX.InvertDCD;
					ft_XSERIES_DATA.InvertDSR = eeX.InvertDSR;
					ft_XSERIES_DATA.InvertDTR = eeX.InvertDTR;
					ft_XSERIES_DATA.InvertRI = eeX.InvertRI;
					ft_XSERIES_DATA.InvertRTS = eeX.InvertRTS;
					ft_XSERIES_DATA.InvertRXD = eeX.InvertRXD;
					ft_XSERIES_DATA.InvertTXD = eeX.InvertTXD;
					ft_XSERIES_DATA.PowerSaveEnable = eeX.PowerSaveEnable;
					ft_XSERIES_DATA.RS485EchoSuppress = eeX.RS485EchoSuppress;
					ft_XSERIES_DATA.DriverType = eeX.IsVCP;
					int num = Marshal.SizeOf(ft_XSERIES_DATA);
					IntPtr intPtr = Marshal.AllocHGlobal(num);
					Marshal.StructureToPtr(ft_XSERIES_DATA, intPtr, false);
					ft_STATUS = tFT_EEPROM_Program(this.ftHandle, intPtr, (uint)num, manufacturer, manufacturerID, description, serialnumber);
				}
			}
			return ft_STATUS;
		}



	}
}
