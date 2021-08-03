//using Microsoft.Extensions.DependencyInjection;
//using DItest.Data;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace DItest.Managers
//{
//	public static class RoleManager
//	{

//		private static DB _DB;
//		private static DatabaseSeeder _databaseSeeder;

//		public static void Init(DB dB, DatabaseSeeder databaseSeeder) // принимаем DatabaseSeeder databaseSeede в статическом калссе
//		{
//			//Che
//			// LogManager._NLog.Debug("UserLocalesManager Init");
//			_databaseSeeder = databaseSeeder; // передаем databaseSeeder в статическую переменную и теперь по идее думать над цыклом жизни DatabaseSeeder нам не надо
//			_DB = dB;
//		}


//		public static async Task MyClass()
//		{
//			await _databaseSeeder.SeedAsync(); // юзаем в свое удовольствие	}
//		}



//		//public static bool CheckIfAdminExists()
//		//{

//		//	//_databaseSeeder.
//		//	return true;
//		//}


//	}
//}
