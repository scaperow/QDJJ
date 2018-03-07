using System;
using System.Runtime.InteropServices;
using System.Text;
namespace JJSOFT.LIVING
{
	public class LivingDog
	{
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct LIV_hardware_info
		{
			public int developerNumber;
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
			public byte[] serialNumber;
			public int setDate;
			public int reservation;
			public int RetCode;
		}
		public struct LIV_software_info
		{
			public int version;
			public int reservation;
		}
		public static uint LIV_SUCCESS = 0u;
		public static uint LIV_OPEN_DEVICE_FAILED = 1u;
		public static uint LIV_FIND_DEVICE_FAILED = 2u;
		public static uint LIV_INVALID_PARAMETER = 3u;
		public static uint LIV_INVALID_BLOCK_NUMBER = 4u;
		public static uint LIV_HARDWARE_COMMUNICATE_ERROR = 5u;
		public static uint LIV_INVALID_PASSWORD = 6u;
		public static uint LIV_ACCESS_DENIED = 7u;
		public static uint LIV_ALREADY_OPENED = 8u;
		public static uint LIV_ALLOCATE_MEMORY_FAILED = 9u;
		public static uint LIV_INVALID_UPDATE_PACKAGE = 10u;
		public static uint LIV_SYN_ERROR = 11u;
		public static uint LIV_OTHER_ERROR = 12u;
		public int RetCode;
		public int ulDogHandle;
		public int Grand_OpenDog(int vendor, int index)
		{
			this.RetCode = LivingDog.LIV_open(vendor, index, ref this.ulDogHandle);
			return this.RetCode;
		}
		public int Grand_CloseDog()
		{
			this.RetCode = LivingDog.LIV_close(this.ulDogHandle);
			return this.RetCode;
		}
		public LivingDog.LIV_hardware_info Grand_GetHardware_info()
		{
			LivingDog.LIV_hardware_info lIV_hardware_info = default(LivingDog.LIV_hardware_info);
			this.RetCode = LivingDog.LIV_get_hardware_info(this.ulDogHandle, ref lIV_hardware_info);
			LivingDog.LIV_hardware_info result;
			if ((long)this.RetCode == (long)((ulong)LivingDog.LIV_SUCCESS))
			{
				result = lIV_hardware_info;
			}
			else
			{
				lIV_hardware_info.RetCode = this.RetCode;
				result = lIV_hardware_info;
			}
			return result;
		}
		public int Grand_Passwd(int p_UserType, string p_Pwd)
		{
			byte[] bytes = Encoding.Default.GetBytes(p_Pwd);
			this.RetCode = LivingDog.LIV_passwd(this.ulDogHandle, p_UserType, bytes);
			return this.RetCode;
		}
		public int Grand_Read(int p_Bloker, byte[] p_byte)
		{
			this.RetCode = LivingDog.LIV_read(this.ulDogHandle, p_Bloker, p_byte);
			return this.RetCode;
		}
		public int Grand_Write(int p_Bloker, byte[] p_byte)
		{
			this.RetCode = LivingDog.LIV_write(this.ulDogHandle, p_Bloker, p_byte);
			return this.RetCode;
		}
		public int Grand_ChangePwd(int p_UserType, string p_NewPwd)
		{
			this.RetCode = LivingDog.LIV_set_passwd(this.ulDogHandle, p_UserType, Encoding.Default.GetBytes(p_NewPwd), -1);
			return this.RetCode;
		}
		[DllImport("living1.dll", CharSet = CharSet.Ansi)]
		private static extern int LIV_open(int vendor, int index, ref int handle);
		[DllImport("living1.dll", CharSet = CharSet.Ansi)]
		private static extern int LIV_close(int handle);
		[DllImport("living1.dll", CharSet = CharSet.Ansi)]
		private static extern int LIV_passwd(int handle, int type, byte[] passwd);
		[DllImport("living1.dll", CharSet = CharSet.Ansi)]
		private static extern int LIV_read(int handle, int block, byte[] buffer);
		[DllImport("living1.dll", CharSet = CharSet.Ansi)]
		private static extern int LIV_write(int handle, int block, byte[] buffer);
		[DllImport("living1.dll", CharSet = CharSet.Ansi)]
		private static extern int LIV_encrypt(int handle, byte[] plaintext, byte[] ciphertext);
		[DllImport("living1.dll", CharSet = CharSet.Ansi)]
		private static extern int LIV_decrypt(int handle, byte[] ciphertext, byte[] plaintext);
		[DllImport("living1.dll", CharSet = CharSet.Ansi)]
		private static extern int LIV_set_passwd(int handle, int type, byte[] newpasswd, int retries);
		[DllImport("living1.dll", CharSet = CharSet.Ansi)]
		private static extern int LIV_change_passwd(int handle, int type, byte[] oldpasswd, byte[] newpasswd);
		[DllImport("living1.dll", CharSet = CharSet.Ansi)]
		private static extern int LIV_get_hardware_info(int handle, ref LivingDog.LIV_hardware_info info);
		[DllImport("living1.dll", CharSet = CharSet.Ansi)]
		private static extern int LIV_get_software_info(ref LivingDog.LIV_software_info info);
		[DllImport("living1.dll", CharSet = CharSet.Ansi)]
		private static extern int LIV_hmac(int handle, byte[] text, int textlen, byte[] digest);
		[DllImport("living1.dll", CharSet = CharSet.Ansi)]
		private static extern int LIV_hmac_software(byte[] text, int textlen, byte[] key, byte[] digest);
		[DllImport("living1.dll", CharSet = CharSet.Ansi)]
		private static extern int LIV_update(int handle, byte[] buffer);
	}
}
